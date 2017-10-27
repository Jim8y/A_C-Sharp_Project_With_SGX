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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Intel_SGX_Managed_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            SGXWrapper sgx = new SGXWrapper();
            
            // Check SGX support first.

            if (sgx.is_supported() == 1)
            {
                if (sgx.is_enabled() == 1)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                }
                else if (sgx.reboot_required() == 1)
                {
                    MessageBox.Show("A reboot is required to enable Intel® Software Guard Extensions." + 
                        Environment.NewLine + "Reboot your system and then re-run this application.",
                        "Reboot Required", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Intel® Software Guard Extensions are not enabled on your system." +
                        Environment.NewLine + "Reboot and enter your BIOS setup to manually enable the feature.",
                        "BIOS Enabling Required", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("This system does not support Intel® Software Guard Extensions.", "Not supported",
                    MessageBoxButtons.OK);
            }


        }
    }
}
