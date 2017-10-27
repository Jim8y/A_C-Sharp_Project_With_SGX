// Copyright 2016 Intel Corporation.

// The source code, information and material ("Material") contained herein is
// owned by Intel Corporation or its suppliers or licensors, and title to such
// Material remains with Intel Corporation or its suppliers or licensors. The
// Material contains proprietary information of Intel or its suppliers and
// licensors. The Material is protected by worldwide copyright laws and treaty
// provisions. No part of the Material may be used, copied, reproduced, modified,
// published, uploaded, posted, transmitted, distributed or disclosed in any way
// without Intel's prior express written permission. No license under any patent,
// copyright or other intellectual property rights in the Material is granted to
// or conferred upon you, either expressly, by implication, inducement, estoppel
// or otherwise. Any license under such intellectual property rights must be
// express and approved by Intel in writing.

// Include any supplier copyright notices as supplier requires Intel to use.

// Include supplier trademarks or logos as supplier requires Intel to use,
// preceded by an asterisk. An asterisked footnote can be added as follows:
// *Third Party trademarks are the property of their respective owners.

// Unless otherwise agreed by Intel in writing, you may not remove or alter this
// notice or any other notice embedded in Materials by Intel or Intel's suppliers
// or licensors in any way.

#define ENCLAVELINK_EXPORTS 1

#include "stdafx.h"
#include "EnclaveLink.h"
#include "EnclaveLinkNative.h"
#include <sgx_urts.h>
#include "EnclaveBridge.h"
#include "EnclaveLinkManaged.h"
#include <functional>

using namespace System;
using namespace System::Threading;
using namespace System::Runtime::InteropServices;
using namespace std;

#define MUTEX L"Enclave"

// Globals since we only want ONE enclave instance.
// Use a mutex so multiple threads dont mess things up.

static sgx_enclave_id_t eid = 0;
static sgx_launch_token_t token = { 0 };
static HANDLE hmutex;
int launched = 0;

EnclaveLinkNative::EnclaveLinkNative(void)
{
}

EnclaveLinkNative::~EnclaveLinkNative(void)
{
}

// Static method called by the launch thread to create globals we'll need
// later, such as our mutex.

void EnclaveLinkNative::init_enclave()
{
	hmutex = CreateMutex(NULL, FALSE, MUTEX);
}

// Close the enclave

void EnclaveLinkNative::close_enclave()
{
	if (WaitForSingleObject(hmutex, INFINITE) != WAIT_OBJECT_0) return;

	if (launched) en_destroy_enclave(eid);
	eid = 0;
	launched = 0;

	ReleaseMutex(hmutex);
}

int EnclaveLinkNative::get_enclave(sgx_enclave_id_t *id)
{
	int rv = 1;
	int updated = 0;

	// The first thread to run launches the enclave. We don't currently
	// keep track of whether or not the enclave is still in use, but
	// that could be added here, too. This would let us be polite and
	// close the enclave after an idle period using a timer.

	if (WaitForSingleObject(hmutex, INFINITE) != WAIT_OBJECT_0) return 0;

	if (launched) *id = eid;
	else {
		sgx_status_t status;

		status= en_create_enclave(&token, &eid, &updated);
		if (status == SGX_SUCCESS) {
			*id = eid;
			rv = 1;
			launched = 1;
		} else {
			rv= 0;
			launched = 0;
		}
	}
	ReleaseMutex(hmutex);

	return rv;
}

int EnclaveLinkNative::cpuid (int leaf, UINT32 flags[4])
{
	int rv= 0;
	sgx_status_t status;
	sgx_enclave_id_t thiseid;

	if (!get_enclave(&thiseid)) return 0;

	// Retry if we lose the enclave due to a power transition
again:
	status= en_cpuid(thiseid, &rv, leaf, flags);
	switch (status) {
	case SGX_SUCCESS:
		return rv;
	case SGX_ERROR_ENCLAVE_LOST:
		if ( get_enclave(&thiseid) ) goto again;
	}
	
	return 0;
}

DWORD EnclaveLinkNative::genrand (int mkb, void *obj, unsigned char rbuffer[1024])
{
	using namespace std::placeholders;
	auto callback= std::bind(&EnclaveLinkNative::genrand_progress, this, _1, _2);
	sgx_status_t status;
	int rv;
	sgx_enclave_id_t thiseid;

	if (!get_enclave(&thiseid)) return 0;

	// Store the pointer to our managed object as a (void *). We'll Marshall this later.

	managed = obj;

	// Retry if we lose the enclave due to a power transition
again:
	status= en_genrand(thiseid, &rv, mkb, callback, rbuffer);
	switch (status) {
	case SGX_SUCCESS:
		break;
	case SGX_ERROR_ENCLAVE_LOST:
		if (get_enclave(&thiseid)) goto again;
	default:
		return 0;
	}

	if (rv != mkb) return 0;

	return 1;
}

int __cdecl EnclaveLinkNative::genrand_progress (int generated, int target)
{
	// Marshal a pointer to a managed object to native code and convert it to an object pointer we can use
	// from CLI code

	EnclaveLinkManaged ^mobj;
	IntPtr pointer(managed);
	GCHandle mhandle;

	mhandle= GCHandle::FromIntPtr(pointer);
	mobj= (EnclaveLinkManaged ^)mhandle.Target;

	// Call the progress update function in the Managed version of the object. A retval of 0 means
	// we should cancel our operation.

	return mobj->genrand_update(generated, target);	
}
