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

#include "stdafx.h"

#include "EnclaveLink.h"
#include "EnclaveLinkNative.h"
#include <Windows.h>

#using <System.dll>

using namespace System;
using namespace System::ComponentModel;

public delegate int progress_callback(int, int);

public ref class EnclaveLinkManaged
{
	array<BYTE> ^rand;
	EnclaveLinkNative *native;

public:
	progress_callback ^callback;

	EnclaveLinkManaged();
	~EnclaveLinkManaged();

	static void init_enclave();
	static void close_enclave();

	int cpuid(int leaf, array<UINT32>^ flags);
	String ^genrand(int mb, progress_callback ^cb);

	// C++/CLI doesn't support friend classes, so this is exposed publicly even though 
	// it's only intended to be used by the EnclaveLinkNative class.

	int genrand_update(int generated, int target);
};
