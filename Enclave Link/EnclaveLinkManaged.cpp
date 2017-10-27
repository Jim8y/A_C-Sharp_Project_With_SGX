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

#include "stdafx.h"

#include "EnclaveLink.h"
#include "EnclaveLinkManaged.h"
#include <Windows.h>
#include <string>

using namespace System;
using namespace System::Runtime::InteropServices;

EnclaveLinkManaged::EnclaveLinkManaged ()
{
	native = new EnclaveLinkNative();
}

EnclaveLinkManaged::~EnclaveLinkManaged ()
{
}

void EnclaveLinkManaged::init_enclave()
{
	EnclaveLinkNative::init_enclave();
}

void EnclaveLinkManaged::close_enclave()
{
	EnclaveLinkNative::close_enclave();
}

int EnclaveLinkManaged::cpuid (int leaf, array<UINT32>^ flags)
{
	UINT32 nflags[4];
	int rv;
	
	rv= native->cpuid(leaf, nflags);
	
	System::Runtime::InteropServices::Marshal::Copy((System::IntPtr) nflags, (array<int>^) flags, 0, 4);

	return rv;
}

// Returns an empty string on failure or user cancel. In this example we don't try and
// differentiate between the two.

String ^EnclaveLinkManaged::genrand(int mb, progress_callback ^cb)
{
	UInt32 rv;
	int kb= 1024*mb;
	String ^mshex = gcnew String("");
	unsigned char *block;
	// Marshal a handle to the managed object to a system pointer that
	// the native layer can use.
	GCHandle handle= GCHandle::Alloc(this);
	IntPtr pointer= GCHandle::ToIntPtr(handle);
	
	callback = cb;
	block = new unsigned char[1024];
	if (block == NULL) return mshex;

	// Call into the native layer. This will make the ECALL, which executes
	// callbacks via the OCALL.

	rv= (UInt32) native->genrand(kb, pointer.ToPointer(), block);
	if (rv) {
		int i;
		array<Byte> ^mblock;
		
		// Marshal the array.

		try {
			mblock = gcnew array<Byte>(1024);

			System::Runtime::InteropServices::Marshal::Copy(IntPtr(block), mblock, 0, 1024);
			for (i = 0; i < 1024; ++i) mshex += String::Format("{0:x2} ", mblock[i]);
		}
		catch (...) {}
	}
	
	// Don't leak memory
	delete[] block;

	return mshex;
}

// The callback function. %done = generated/target

int EnclaveLinkManaged::genrand_update(int generated, int target)
{
	return callback(generated, target);
}
