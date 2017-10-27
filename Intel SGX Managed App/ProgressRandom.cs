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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intel_SGX_Managed_App
{
    public partial class ProgressRandom : Form
    {
        EnclaveLinkManaged enclave;
        int mb;
        Boolean cancel = false;
        progress_callback callback;
        TaskScheduler uicontext;
        int num;

        public ProgressRandom(int mb_in, int num_in)
        {
            enclave = new EnclaveLinkManaged();
            mb = mb_in;
            num = num_in;
            uicontext = TaskScheduler.FromCurrentSynchronizationContext();
            callback = new progress_callback(UpdateProgress);

            InitializeComponent();

            labelTask.Text = String.Format("Generating {0} MB of random data", mb);
        }

        // CPU-intensive operation that will freeze the UI, so make it
        // a Task.

        public Task<String> RunAsync()
        {
            this.Refresh();

            // Create a thread using Task.Run

            return Task.Run<String>(() =>
            {
                String data;

                data= enclave.genrand(mb, callback);

                return data;
            });
        }

        // Update our UI by creating a thread in the UI context.
        // This is much easier using Task.Factory.StartNew
        // than with Dispatcher.InvokeAsync, but the latter will
        // work too if you prefer not to use the former.
        //
        // Note that we only want to do this long enough to update
        // the progress bar.
        //
        // Even easier would be to use the BackgroundWorker widget
        // but we're trying to demonstrate the more general case.

        private int UpdateProgress(int received, int target)
        {
            Task.Factory.StartNew(() =>
            {
                progressBarRand.Value = 100 * received / target;
                this.Text = String.Format("Thread {0}: {1}% complete", num, progressBarRand.Value);                
            }, CancellationToken.None, TaskCreationOptions.None, uicontext);

            return (cancel) ? 0 : 1;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cancel = true;
        }
    }
}
