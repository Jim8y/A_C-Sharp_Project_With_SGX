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

#include "Enclave_t.h"

#include "sgx_trts.h"
#include "sgx_cpuid.h"
#include <string.h>

#define RDRAND_BUFFER_SZ 1024*1024

int e_cpuid (int leaf, uint32_t info[4])
{
	int cpuinfo[4];
	sgx_status_t status;

	status= sgx_cpuid(cpuinfo, leaf);
	if ( status != SGX_SUCCESS ) return 0;

	memcpy(info, cpuinfo, 4*sizeof(int));

	return 1;
}

int e_genrand (int kb, void *callback, size_t sz, unsigned char *block)
{
	sgx_status_t status;
	int i, j, rv;
	unsigned char buffer[1024];

	// Initialize our block to zero.
	memset_s(block, 1024, 0, 1024);
	
	for (i= 0; i< kb; ++i) {
		// Read  1K block
		status= sgx_read_rand(buffer, 1024);
		if ( status != SGX_SUCCESS ) return i;
		
		// XOR the new block with our existing block
		for (j = 0; j < 1024; ++j) block[j] ^= buffer[j];

		// Make our callback. Be polite and only do this every MB.
		// (Assuming 1 KB = 1024 bytes, 1MB = 1024 KB)

		if (!(i % 1024)) {
			status = o_genrand_progress(&rv, callback, sz, i + 1, kb);
			// rv == 0 means we got a cancellation request
			if (status != SGX_SUCCESS || rv == 0) return i;
		}
	}

	return kb;
}