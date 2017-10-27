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

#define ENCLAVENATIVE_API_EXPORTING 1

#include <sgx_urts.h>
#include <tchar.h>
#include <string.h>
#include <Windows.h>
#include "EnclaveBridge.h"
#include "Enclave_u.h"

ENCLAVENATIVE_API sgx_status_t en_create_enclave (sgx_launch_token_t *token, sgx_enclave_id_t *eid, int *updated)
{
	return sgx_create_enclave(ENCLAVE_FILE, SGX_DEBUG_FLAG, token, updated, eid, NULL);
}

ENCLAVENATIVE_API sgx_status_t en_cpuid (sgx_enclave_id_t eid, int *rv, int leaf, uint32_t info[4])
{
	return e_cpuid(eid, rv, leaf, info);
}

ENCLAVENATIVE_API sgx_status_t en_genrand(sgx_enclave_id_t eid, int *rv, int kb, progress_callback_t callback, unsigned char *rbuffer)
{
	sgx_status_t status;
	size_t cbsize = sizeof(progress_callback_t);

	// Pass the callback pointer to the enclave as a 64-bit address value.
	status = e_genrand(eid, rv, kb, (void *)&callback, cbsize, rbuffer);

	return status;
}


ENCLAVENATIVE_API sgx_status_t en_destroy_enclave (sgx_enclave_id_t eid)
{
	return sgx_destroy_enclave(eid);
}

int o_genrand_progress(void *cbref, size_t sz, int progress, int target)
{
	progress_callback_t *callback = (progress_callback_t *) cbref;

	// Recast as a pointer to our callback function.

	if (callback == NULL) return 1;

	// Propogate the cancellation condition back up the stack.
	return (*callback)(progress, target);
}