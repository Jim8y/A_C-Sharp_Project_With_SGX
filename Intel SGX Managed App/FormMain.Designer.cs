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

namespace Intel_SGX_Managed_App
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxEDX = new System.Windows.Forms.TextBox();
            this.textBoxECX = new System.Windows.Forms.TextBox();
            this.textBoxEBX = new System.Windows.Forms.TextBox();
            this.textBoxEAX = new System.Windows.Forms.TextBox();
            this.labelEDX = new System.Windows.Forms.Label();
            this.labelECX = new System.Windows.Forms.Label();
            this.labelEBX = new System.Windows.Forms.Label();
            this.labelEAX = new System.Windows.Forms.Label();
            this.buttonCPUID = new System.Windows.Forms.Button();
            this.textBoxLeaf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRandom1 = new System.Windows.Forms.Button();
            this.textBoxRandom1 = new System.Windows.Forms.TextBox();
            this.numericMB = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRandom2 = new System.Windows.Forms.TextBox();
            this.buttonRandom2 = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMB)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(328, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBoxEDX
            // 
            this.textBoxEDX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEDX.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxEDX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEDX.Location = new System.Drawing.Point(79, 117);
            this.textBoxEDX.Name = "textBoxEDX";
            this.textBoxEDX.ReadOnly = true;
            this.textBoxEDX.Size = new System.Drawing.Size(202, 20);
            this.textBoxEDX.TabIndex = 22;
            // 
            // textBoxECX
            // 
            this.textBoxECX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxECX.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxECX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxECX.Location = new System.Drawing.Point(79, 91);
            this.textBoxECX.Name = "textBoxECX";
            this.textBoxECX.ReadOnly = true;
            this.textBoxECX.Size = new System.Drawing.Size(202, 20);
            this.textBoxECX.TabIndex = 21;
            // 
            // textBoxEBX
            // 
            this.textBoxEBX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEBX.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxEBX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEBX.Location = new System.Drawing.Point(79, 65);
            this.textBoxEBX.Name = "textBoxEBX";
            this.textBoxEBX.ReadOnly = true;
            this.textBoxEBX.Size = new System.Drawing.Size(202, 20);
            this.textBoxEBX.TabIndex = 20;
            // 
            // textBoxEAX
            // 
            this.textBoxEAX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEAX.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxEAX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEAX.Location = new System.Drawing.Point(79, 39);
            this.textBoxEAX.Name = "textBoxEAX";
            this.textBoxEAX.ReadOnly = true;
            this.textBoxEAX.Size = new System.Drawing.Size(202, 20);
            this.textBoxEAX.TabIndex = 19;
            // 
            // labelEDX
            // 
            this.labelEDX.AutoSize = true;
            this.labelEDX.Location = new System.Drawing.Point(45, 119);
            this.labelEDX.Name = "labelEDX";
            this.labelEDX.Size = new System.Drawing.Size(29, 13);
            this.labelEDX.TabIndex = 18;
            this.labelEDX.Text = "EDX";
            // 
            // labelECX
            // 
            this.labelECX.AutoSize = true;
            this.labelECX.Location = new System.Drawing.Point(46, 93);
            this.labelECX.Name = "labelECX";
            this.labelECX.Size = new System.Drawing.Size(28, 13);
            this.labelECX.TabIndex = 17;
            this.labelECX.Text = "ECX";
            // 
            // labelEBX
            // 
            this.labelEBX.AutoSize = true;
            this.labelEBX.Location = new System.Drawing.Point(46, 67);
            this.labelEBX.Name = "labelEBX";
            this.labelEBX.Size = new System.Drawing.Size(28, 13);
            this.labelEBX.TabIndex = 16;
            this.labelEBX.Text = "EBX";
            // 
            // labelEAX
            // 
            this.labelEAX.AutoSize = true;
            this.labelEAX.Location = new System.Drawing.Point(45, 41);
            this.labelEAX.Name = "labelEAX";
            this.labelEAX.Size = new System.Drawing.Size(28, 13);
            this.labelEAX.TabIndex = 15;
            this.labelEAX.Text = "EAX";
            // 
            // buttonCPUID
            // 
            this.buttonCPUID.Location = new System.Drawing.Point(152, 9);
            this.buttonCPUID.Name = "buttonCPUID";
            this.buttonCPUID.Size = new System.Drawing.Size(75, 23);
            this.buttonCPUID.TabIndex = 14;
            this.buttonCPUID.Text = "Query";
            this.buttonCPUID.UseVisualStyleBackColor = true;
            this.buttonCPUID.Click += new System.EventHandler(this.buttonCPUID_Click);
            // 
            // textBoxLeaf
            // 
            this.textBoxLeaf.Location = new System.Drawing.Point(71, 11);
            this.textBoxLeaf.MaxLength = 8;
            this.textBoxLeaf.Name = "textBoxLeaf";
            this.textBoxLeaf.Size = new System.Drawing.Size(75, 20);
            this.textBoxLeaf.TabIndex = 13;
            this.textBoxLeaf.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "EAX = 0x";
            // 
            // buttonRandom1
            // 
            this.buttonRandom1.Location = new System.Drawing.Point(172, 45);
            this.buttonRandom1.Name = "buttonRandom1";
            this.buttonRandom1.Size = new System.Drawing.Size(118, 23);
            this.buttonRandom1.TabIndex = 3;
            this.buttonRandom1.Text = "Generate Thread 1";
            this.buttonRandom1.UseVisualStyleBackColor = true;
            this.buttonRandom1.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // textBoxRandom1
            // 
            this.textBoxRandom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRandom1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxRandom1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRandom1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRandom1.Location = new System.Drawing.Point(9, 74);
            this.textBoxRandom1.Multiline = true;
            this.textBoxRandom1.Name = "textBoxRandom1";
            this.textBoxRandom1.ReadOnly = true;
            this.textBoxRandom1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRandom1.Size = new System.Drawing.Size(279, 119);
            this.textBoxRandom1.TabIndex = 2;
            // 
            // numericMB
            // 
            this.numericMB.Location = new System.Drawing.Point(86, 19);
            this.numericMB.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMB.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericMB.Name = "numericMB";
            this.numericMB.Size = new System.Drawing.Size(60, 20);
            this.numericMB.TabIndex = 1;
            this.numericMB.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Random MBs:";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(234, 415);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(304, 382);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxEDX);
            this.tabPage1.Controls.Add(this.textBoxECX);
            this.tabPage1.Controls.Add(this.textBoxEAX);
            this.tabPage1.Controls.Add(this.textBoxEBX);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxLeaf);
            this.tabPage1.Controls.Add(this.labelEDX);
            this.tabPage1.Controls.Add(this.buttonCPUID);
            this.tabPage1.Controls.Add(this.labelECX);
            this.tabPage1.Controls.Add(this.labelEAX);
            this.tabPage1.Controls.Add(this.labelEBX);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(296, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CPUID";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBoxRandom2);
            this.tabPage2.Controls.Add(this.buttonRandom2);
            this.tabPage2.Controls.Add(this.textBoxRandom1);
            this.tabPage2.Controls.Add(this.buttonRandom1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.numericMB);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(296, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RDRAND";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Final 1KB block:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Final 1KB block:";
            // 
            // textBoxRandom2
            // 
            this.textBoxRandom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRandom2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxRandom2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRandom2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRandom2.Location = new System.Drawing.Point(11, 228);
            this.textBoxRandom2.Multiline = true;
            this.textBoxRandom2.Name = "textBoxRandom2";
            this.textBoxRandom2.ReadOnly = true;
            this.textBoxRandom2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRandom2.Size = new System.Drawing.Size(279, 119);
            this.textBoxRandom2.TabIndex = 5;
            // 
            // buttonRandom2
            // 
            this.buttonRandom2.Location = new System.Drawing.Point(172, 199);
            this.buttonRandom2.Name = "buttonRandom2";
            this.buttonRandom2.Size = new System.Drawing.Size(118, 23);
            this.buttonRandom2.TabIndex = 4;
            this.buttonRandom2.Text = "Generate Thread 2";
            this.buttonRandom2.UseVisualStyleBackColor = true;
            this.buttonRandom2.Click += new System.EventHandler(this.buttonRandom2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.menuStripMain);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(344, 489);
            this.Name = "FormMain";
            this.Text = "Intel SGX Managed App";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMB)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxEDX;
        private System.Windows.Forms.TextBox textBoxECX;
        private System.Windows.Forms.TextBox textBoxEBX;
        private System.Windows.Forms.TextBox textBoxEAX;
        private System.Windows.Forms.Label labelEDX;
        private System.Windows.Forms.Label labelECX;
        private System.Windows.Forms.Label labelEBX;
        private System.Windows.Forms.Label labelEAX;
        private System.Windows.Forms.Button buttonCPUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonRandom1;
        private System.Windows.Forms.TextBox textBoxRandom1;
        private System.Windows.Forms.NumericUpDown numericMB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLeaf;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonRandom2;
        private System.Windows.Forms.TextBox textBoxRandom2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

