namespace MultiRDP
{
    partial class Form1
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
            this.mComputerNameTextBox = new System.Windows.Forms.TextBox();
            this.mStartConnectionButton = new System.Windows.Forms.Button();
            this.mCreateCredentialsButton = new System.Windows.Forms.Button();
            this.mUserNameTextBox = new System.Windows.Forms.TextBox();
            this.mPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mExitButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartComputersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debuggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreRemoteCDrivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getRDPWindowHandlesADVANCEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pushBit9InstallerFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBit9InstallerFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mRemotePowerStateButton = new System.Windows.Forms.Button();
            this.mRemoteManageButton = new System.Windows.Forms.Button();
            this.mDebugTextBox = new System.Windows.Forms.RichTextBox();
            this.mShutDownButton = new System.Windows.Forms.Button();
            this.mRestartButton = new System.Windows.Forms.Button();
            this.mLogoffButton = new System.Windows.Forms.Button();
            this.mWmiQueryButton = new System.Windows.Forms.Button();
            this.mBit9Check = new System.Windows.Forms.CheckBox();
            this.mTimeParameterBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mComputerNameTextBox
            // 
            this.mComputerNameTextBox.Location = new System.Drawing.Point(12, 52);
            this.mComputerNameTextBox.Multiline = true;
            this.mComputerNameTextBox.Name = "mComputerNameTextBox";
            this.mComputerNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mComputerNameTextBox.Size = new System.Drawing.Size(147, 230);
            this.mComputerNameTextBox.TabIndex = 1;
            this.mComputerNameTextBox.Text = "Please input hosts here, with a newline seperating each host. For example:\r\n<ComputerNameOne>\r\n<ComputerNameTwo>";
            this.mComputerNameTextBox.Enter += new System.EventHandler(this.computerNameTextBox_Enter);
            this.mComputerNameTextBox.Leave += new System.EventHandler(this.computerNameTextBox_Leave);
            // 
            // mStartConnectionButton
            // 
            this.mStartConnectionButton.Location = new System.Drawing.Point(165, 52);
            this.mStartConnectionButton.Name = "mStartConnectionButton";
            this.mStartConnectionButton.Size = new System.Drawing.Size(237, 29);
            this.mStartConnectionButton.TabIndex = 0;
            this.mStartConnectionButton.Text = "Multi-RDP";
            this.mStartConnectionButton.UseVisualStyleBackColor = true;
            this.mStartConnectionButton.Click += new System.EventHandler(this.startConnectionButton_Click);
            // 
            // mCreateCredentialsButton
            // 
            this.mCreateCredentialsButton.Location = new System.Drawing.Point(165, 87);
            this.mCreateCredentialsButton.Name = "mCreateCredentialsButton";
            this.mCreateCredentialsButton.Size = new System.Drawing.Size(237, 29);
            this.mCreateCredentialsButton.TabIndex = 5;
            this.mCreateCredentialsButton.Text = "Store credentials for systems";
            this.mCreateCredentialsButton.UseVisualStyleBackColor = true;
            this.mCreateCredentialsButton.Click += new System.EventHandler(this.createCredentialsButton_Click);
            this.mCreateCredentialsButton.MouseHover += new System.EventHandler(this.createCredentialsButton_MouseHover);
            // 
            // mUserNameTextBox
            // 
            this.mUserNameTextBox.Location = new System.Drawing.Point(0, 288);
            this.mUserNameTextBox.Name = "mUserNameTextBox";
            this.mUserNameTextBox.Size = new System.Drawing.Size(236, 20);
            this.mUserNameTextBox.TabIndex = 6;
            this.mUserNameTextBox.Text = "Domain\\UserName";
            this.mUserNameTextBox.Enter += new System.EventHandler(this.userNameTextBox_Enter);
            this.mUserNameTextBox.Leave += new System.EventHandler(this.userNameTextBox_Leave);
            // 
            // mPasswordTextBox
            // 
            this.mPasswordTextBox.Location = new System.Drawing.Point(0, 314);
            this.mPasswordTextBox.Name = "mPasswordTextBox";
            this.mPasswordTextBox.Size = new System.Drawing.Size(236, 20);
            this.mPasswordTextBox.TabIndex = 7;
            this.mPasswordTextBox.Text = "Password";
            this.mPasswordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            this.mPasswordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Remote Hosts";
            // 
            // mExitButton
            // 
            this.mExitButton.Location = new System.Drawing.Point(165, 231);
            this.mExitButton.Name = "mExitButton";
            this.mExitButton.Size = new System.Drawing.Size(237, 37);
            this.mExitButton.TabIndex = 11;
            this.mExitButton.Text = "Exit";
            this.mExitButton.UseVisualStyleBackColor = true;
            this.mExitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(411, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rDPToolStripMenuItem,
            this.createCredentialsToolStripMenuItem,
            this.manageUsersToolStripMenuItem,
            this.restartComputersToolStripMenuItem,
            this.debuggerToolStripMenuItem,
            this.exploreRemoteCDrivesToolStripMenuItem,
            this.getRDPWindowHandlesADVANCEDToolStripMenuItem,
            this.pushBit9InstallerFilesToolStripMenuItem,
            this.deleteBit9InstallerFilesToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // rDPToolStripMenuItem
            // 
            this.rDPToolStripMenuItem.Name = "rDPToolStripMenuItem";
            this.rDPToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.rDPToolStripMenuItem.Text = "RDP";
            this.rDPToolStripMenuItem.Click += new System.EventHandler(this.rDPToolStripMenuItem_Click);
            // 
            // createCredentialsToolStripMenuItem
            // 
            this.createCredentialsToolStripMenuItem.Name = "createCredentialsToolStripMenuItem";
            this.createCredentialsToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.createCredentialsToolStripMenuItem.Text = "Store Credentials";
            this.createCredentialsToolStripMenuItem.Click += new System.EventHandler(this.createCredentialsToolStripMenuItem_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // restartComputersToolStripMenuItem
            // 
            this.restartComputersToolStripMenuItem.Name = "restartComputersToolStripMenuItem";
            this.restartComputersToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.restartComputersToolStripMenuItem.Text = "Manage Remote State";
            this.restartComputersToolStripMenuItem.Click += new System.EventHandler(this.restartComputersToolStripMenuItem_Click);
            // 
            // debuggerToolStripMenuItem
            // 
            this.debuggerToolStripMenuItem.Name = "debuggerToolStripMenuItem";
            this.debuggerToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.debuggerToolStripMenuItem.Text = "Debugger";
            this.debuggerToolStripMenuItem.Click += new System.EventHandler(this.debuggerToolStripMenuItem_Click);
            // 
            // exploreRemoteCDrivesToolStripMenuItem
            // 
            this.exploreRemoteCDrivesToolStripMenuItem.Name = "exploreRemoteCDrivesToolStripMenuItem";
            this.exploreRemoteCDrivesToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.exploreRemoteCDrivesToolStripMenuItem.Text = "Explore Remote C Drives";
            this.exploreRemoteCDrivesToolStripMenuItem.Click += new System.EventHandler(this.exploreRemoteCDrivesToolStripMenuItem_Click);
            // 
            // getRDPWindowHandlesADVANCEDToolStripMenuItem
            // 
            this.getRDPWindowHandlesADVANCEDToolStripMenuItem.Name = "getRDPWindowHandlesADVANCEDToolStripMenuItem";
            this.getRDPWindowHandlesADVANCEDToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.getRDPWindowHandlesADVANCEDToolStripMenuItem.Text = "Get RDP Window Handles (ADVANCED)";
            this.getRDPWindowHandlesADVANCEDToolStripMenuItem.Click += new System.EventHandler(this.getRDPWindowHandlesADVANCEDToolStripMenuItem_Click);
            // 
            // pushBit9InstallerFilesToolStripMenuItem
            // 
            this.pushBit9InstallerFilesToolStripMenuItem.Name = "pushBit9InstallerFilesToolStripMenuItem";
            this.pushBit9InstallerFilesToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.pushBit9InstallerFilesToolStripMenuItem.Text = "Push Bit9 Installer Files";
            this.pushBit9InstallerFilesToolStripMenuItem.Click += new System.EventHandler(this.pushBit9InstallerFilesToolStripMenuItem_Click);
            // 
            // deleteBit9InstallerFilesToolStripMenuItem
            // 
            this.deleteBit9InstallerFilesToolStripMenuItem.Name = "deleteBit9InstallerFilesToolStripMenuItem";
            this.deleteBit9InstallerFilesToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.deleteBit9InstallerFilesToolStripMenuItem.Text = "Delete Bit9 Installer Files";
            this.deleteBit9InstallerFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteBit9InstallerFilesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mRemotePowerStateButton
            // 
            this.mRemotePowerStateButton.Location = new System.Drawing.Point(165, 157);
            this.mRemotePowerStateButton.Name = "mRemotePowerStateButton";
            this.mRemotePowerStateButton.Size = new System.Drawing.Size(237, 29);
            this.mRemotePowerStateButton.TabIndex = 13;
            this.mRemotePowerStateButton.Text = "Shutdown/Restart/Logoff Remote System";
            this.mRemotePowerStateButton.UseVisualStyleBackColor = true;
            this.mRemotePowerStateButton.Click += new System.EventHandler(this.remotePowerStateButton_Click);
            this.mRemotePowerStateButton.MouseHover += new System.EventHandler(this.mRemotePowerStateButton_MouseHover);
            // 
            // mRemoteManageButton
            // 
            this.mRemoteManageButton.Location = new System.Drawing.Point(165, 122);
            this.mRemoteManageButton.Name = "mRemoteManageButton";
            this.mRemoteManageButton.Size = new System.Drawing.Size(237, 29);
            this.mRemoteManageButton.TabIndex = 14;
            this.mRemoteManageButton.Text = "Remotely Manage Systems";
            this.mRemoteManageButton.UseVisualStyleBackColor = true;
            this.mRemoteManageButton.Click += new System.EventHandler(this.remoteManageButton_Click);
            // 
            // mDebugTextBox
            // 
            this.mDebugTextBox.Enabled = false;
            this.mDebugTextBox.Location = new System.Drawing.Point(418, 36);
            this.mDebugTextBox.Name = "mDebugTextBox";
            this.mDebugTextBox.Size = new System.Drawing.Size(491, 288);
            this.mDebugTextBox.TabIndex = 15;
            this.mDebugTextBox.Text = "";
            this.mDebugTextBox.Visible = false;
            // 
            // mShutDownButton
            // 
            this.mShutDownButton.Location = new System.Drawing.Point(166, 193);
            this.mShutDownButton.Name = "mShutDownButton";
            this.mShutDownButton.Size = new System.Drawing.Size(75, 23);
            this.mShutDownButton.TabIndex = 16;
            this.mShutDownButton.Text = "ShutDown";
            this.mShutDownButton.UseVisualStyleBackColor = true;
            this.mShutDownButton.Visible = false;
            this.mShutDownButton.Click += new System.EventHandler(this.shutDownButton_Click);
            // 
            // mRestartButton
            // 
            this.mRestartButton.Location = new System.Drawing.Point(248, 193);
            this.mRestartButton.Name = "mRestartButton";
            this.mRestartButton.Size = new System.Drawing.Size(75, 23);
            this.mRestartButton.TabIndex = 17;
            this.mRestartButton.Text = "Restart";
            this.mRestartButton.UseVisualStyleBackColor = true;
            this.mRestartButton.Visible = false;
            this.mRestartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // mLogoffButton
            // 
            this.mLogoffButton.Location = new System.Drawing.Point(330, 193);
            this.mLogoffButton.Name = "mLogoffButton";
            this.mLogoffButton.Size = new System.Drawing.Size(75, 23);
            this.mLogoffButton.TabIndex = 18;
            this.mLogoffButton.Text = "LogOff";
            this.mLogoffButton.UseVisualStyleBackColor = true;
            this.mLogoffButton.Visible = false;
            this.mLogoffButton.Click += new System.EventHandler(this.logOffButton_Click);
            // 
            // mWmiQueryButton
            // 
            this.mWmiQueryButton.Location = new System.Drawing.Point(165, 193);
            this.mWmiQueryButton.Name = "mWmiQueryButton";
            this.mWmiQueryButton.Size = new System.Drawing.Size(237, 32);
            this.mWmiQueryButton.TabIndex = 19;
            this.mWmiQueryButton.Text = "Remote WMI Query";
            this.mWmiQueryButton.UseVisualStyleBackColor = true;
            this.mWmiQueryButton.Click += new System.EventHandler(this.mWmiQueryButton_Click);
            // 
            // mBit9Check
            // 
            this.mBit9Check.AutoSize = true;
            this.mBit9Check.Location = new System.Drawing.Point(213, 32);
            this.mBit9Check.Name = "mBit9Check";
            this.mBit9Check.Size = new System.Drawing.Size(139, 17);
            this.mBit9Check.TabIndex = 20;
            this.mBit9Check.Text = "Lab Bit9 Policy In Effect";
            this.mBit9Check.UseVisualStyleBackColor = true;
            this.mBit9Check.MouseHover += new System.EventHandler(this.mBit9Check_MouseHover);
            // 
            // mTimeParameterBox
            // 
            this.mTimeParameterBox.Location = new System.Drawing.Point(232, 262);
            this.mTimeParameterBox.Name = "mTimeParameterBox";
            this.mTimeParameterBox.Size = new System.Drawing.Size(100, 20);
            this.mTimeParameterBox.TabIndex = 21;
            this.mTimeParameterBox.Text = "<Time>";
            this.mTimeParameterBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mTimeParameterBox.Visible = false;
            this.mTimeParameterBox.TextChanged += new System.EventHandler(this.mTimeParameterBox_TextChanged);
            this.mTimeParameterBox.Enter += new System.EventHandler(this.mTimeParameterBox_Enter);
            this.mTimeParameterBox.Leave += new System.EventHandler(this.mTimeParameterBox_Leave);
            this.mTimeParameterBox.MouseHover += new System.EventHandler(this.mTimeParameterBox_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 336);
            this.Controls.Add(this.mTimeParameterBox);
            this.Controls.Add(this.mBit9Check);
            this.Controls.Add(this.mWmiQueryButton);
            this.Controls.Add(this.mLogoffButton);
            this.Controls.Add(this.mRestartButton);
            this.Controls.Add(this.mShutDownButton);
            this.Controls.Add(this.mDebugTextBox);
            this.Controls.Add(this.mRemoteManageButton);
            this.Controls.Add(this.mRemotePowerStateButton);
            this.Controls.Add(this.mExitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mPasswordTextBox);
            this.Controls.Add(this.mUserNameTextBox);
            this.Controls.Add(this.mCreateCredentialsButton);
            this.Controls.Add(this.mStartConnectionButton);
            this.Controls.Add(this.mComputerNameTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Voya Lab RDP";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mComputerNameTextBox;
        private System.Windows.Forms.Button mStartConnectionButton;
        private System.Windows.Forms.Button mCreateCredentialsButton;
        private System.Windows.Forms.TextBox mUserNameTextBox;
        private System.Windows.Forms.TextBox mPasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button mExitButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rDPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCredentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartComputersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button mRemotePowerStateButton;
        private System.Windows.Forms.Button mRemoteManageButton;
        private System.Windows.Forms.ToolStripMenuItem debuggerToolStripMenuItem;
        private System.Windows.Forms.RichTextBox mDebugTextBox;
        private System.Windows.Forms.Button mShutDownButton;
        private System.Windows.Forms.Button mRestartButton;
        private System.Windows.Forms.Button mLogoffButton;
        private System.Windows.Forms.Button mWmiQueryButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox mBit9Check;
        private System.Windows.Forms.ToolStripMenuItem exploreRemoteCDrivesToolStripMenuItem;
        private System.Windows.Forms.TextBox mTimeParameterBox;
        private System.Windows.Forms.ToolStripMenuItem getRDPWindowHandlesADVANCEDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pushBit9InstallerFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBit9InstallerFilesToolStripMenuItem;
    }
}

