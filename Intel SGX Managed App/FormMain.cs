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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intel_SGX_Managed_App
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
            // This doesn't create the enclave, it just initializes what we need
            // to do so in an multithreaded environment.
            EnclaveLinkManaged.init_enclave();
        }

        ~FormMain()
        {
            // Destroy the enclave (if we created it).
            EnclaveLinkManaged.close_enclave();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            random_generate(buttonRandom1, textBoxRandom1, 1);
        }

        private void buttonCPUID_Click(object sender, EventArgs e)
        {
            int rv;
            UInt32[] flags = new UInt32[4];
            EnclaveLinkManaged enclave = new EnclaveLinkManaged();

            // Query CPUID and get back an array of 4 32-bit unsigned integers

            rv = enclave.cpuid(Convert.ToInt32(textBoxLeaf.Text), flags);
            if (rv == 1)
            {
                textBoxEAX.Text = String.Format("{0:X8}", flags[0]);
                textBoxEBX.Text = String.Format("{0:X8}", flags[1]);
                textBoxECX.Text = String.Format("{0:X8}", flags[2]);
                textBoxEDX.Text = String.Format("{0:X8}", flags[3]);
            }
            else
            {
                MessageBox.Show("CPUID query failed");
            }
        }

        private void buttonRandom2_Click(object sender, EventArgs e)
        {
            random_generate(buttonRandom2, textBoxRandom2, 2);
        }

        private async void random_generate (Button b, TextBox tb, int num)
        {
            ProgressRandom form;
            Task<string> task;

            b.Enabled = false;
            form = new ProgressRandom(Convert.ToInt32(numericMB.Value), num);
            form.Show();

            // Run this in a separate thread so we don't freeze the UI.

            task = form.RunAsync();
            tb.Text = await task;
            form.Close();
            b.Enabled = true;
        }
    }
}
