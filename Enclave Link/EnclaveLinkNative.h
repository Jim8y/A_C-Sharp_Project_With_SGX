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

#pragma once

#include "EnclaveLink.h"
#include "EnclaveLinkManaged.h"
#include <sgx_urts.h>
#include <Windows.h>
#include <map>
#include <string>

using namespace std;

class ENCLAVELINK_API EnclaveLinkNative {
	friend ref class EnclaveLinkManaged;
	
	void *managed;

	int get_enclave(sgx_enclave_id_t *id);

protected:
	int cpuid(int leaf, UINT32 flags[4]);
	DWORD genrand(int kb, void *obj, unsigned char firstblock[1024]);
	string get_rand_data(DWORD thid);

	static void init_enclave();
	static void close_enclave();

public:
	EnclaveLinkNative(void);
	~EnclaveLinkNative(void);

	int __cdecl genrand_progress(int generated, int target);

};
