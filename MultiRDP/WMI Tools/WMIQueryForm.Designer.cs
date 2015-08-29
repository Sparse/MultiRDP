using System;
namespace MultiRDP.WMI_Tools
{
    partial class WMIQueryForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mScavengeButton = new System.Windows.Forms.Button();
            this.mScavengedNSResultTreeView = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.mComputerNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mNamespaceSelector = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mRemoteHostHelpBox = new System.Windows.Forms.ToolTip(this.components);
            this.mScavengeLabel = new System.Windows.Forms.Label();
            this.mDisplayErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.mNamespaceClassesTreeView = new System.Windows.Forms.TreeView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1136, 424);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mNamespaceClassesTreeView);
            this.tabPage1.Controls.Add(this.mScavengeButton);
            this.tabPage1.Controls.Add(this.mScavengedNSResultTreeView);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.mComputerNameTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.mNamespaceSelector);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1128, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informational Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mScavengeButton
            // 
            this.mScavengeButton.Location = new System.Drawing.Point(7, 368);
            this.mScavengeButton.Name = "mScavengeButton";
            this.mScavengeButton.Size = new System.Drawing.Size(152, 23);
            this.mScavengeButton.TabIndex = 5;
            this.mScavengeButton.Text = "Scavenge!";
            this.mScavengeButton.UseVisualStyleBackColor = true;
            this.mScavengeButton.Click += new System.EventHandler(this.mScavengeButton_Click);
            // 
            // mScavengedNSResultTreeView
            // 
            this.mScavengedNSResultTreeView.Location = new System.Drawing.Point(175, 19);
            this.mScavengedNSResultTreeView.Name = "mScavengedNSResultTreeView";
            this.mScavengedNSResultTreeView.Size = new System.Drawing.Size(166, 342);
            this.mScavengedNSResultTreeView.TabIndex = 4;
            this.mScavengedNSResultTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mScavengedNSResultTreeView_NodeMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Remote Host";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // mComputerNameTextBox
            // 
            this.mComputerNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.mComputerNameTextBox.Multiline = true;
            this.mComputerNameTextBox.Name = "mComputerNameTextBox";
            this.mComputerNameTextBox.Size = new System.Drawing.Size(153, 342);
            this.mComputerNameTextBox.TabIndex = 2;
            this.mComputerNameTextBox.Text = "Please input hosts here, with a newline seperating each host. For example:\r\n<Comp" +
    "uterNameOne>\r\n<ComputerNameTwo>";
            this.mComputerNameTextBox.Enter += new System.EventHandler(this.mComputerNameTextBox_Enter);
            this.mComputerNameTextBox.Leave += new System.EventHandler(this.mComputerNameTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1013, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "All WMI Namespaces";
            // 
            // mNamespaceSelector
            // 
            this.mNamespaceSelector.FormattingEnabled = true;
            this.mNamespaceSelector.Location = new System.Drawing.Point(1004, 19);
            this.mNamespaceSelector.Name = "mNamespaceSelector";
            this.mNamespaceSelector.Size = new System.Drawing.Size(121, 21);
            this.mNamespaceSelector.TabIndex = 0;
            this.mNamespaceSelector.SelectedIndexChanged += new System.EventHandler(this.mNamespaceSelector_SelectedIndexChanged);
            this.mNamespaceSelector.Click += new System.EventHandler(this.mNamespaceSelector_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1128, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Object Method Executor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mScavengeLabel
            // 
            this.mScavengeLabel.AutoSize = true;
            this.mScavengeLabel.Location = new System.Drawing.Point(9, 435);
            this.mScavengeLabel.Name = "mScavengeLabel";
            this.mScavengeLabel.Size = new System.Drawing.Size(143, 13);
            this.mScavengeLabel.TabIndex = 4;
            this.mScavengeLabel.Text = "No Scavenge performed yet!";
            // 
            // mDisplayErrorsCheckBox
            // 
            this.mDisplayErrorsCheckBox.AutoSize = true;
            this.mDisplayErrorsCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.mDisplayErrorsCheckBox.Location = new System.Drawing.Point(1067, 435);
            this.mDisplayErrorsCheckBox.Name = "mDisplayErrorsCheckBox";
            this.mDisplayErrorsCheckBox.Size = new System.Drawing.Size(90, 17);
            this.mDisplayErrorsCheckBox.TabIndex = 5;
            this.mDisplayErrorsCheckBox.Text = "Display Errors";
            this.mDisplayErrorsCheckBox.UseVisualStyleBackColor = true;
            this.mDisplayErrorsCheckBox.CheckedChanged += new System.EventHandler(this.mDisplayErrorsCheckBox_CheckedChanged);
            // 
            // mNamespaceClassesTreeView
            // 
            this.mNamespaceClassesTreeView.Location = new System.Drawing.Point(361, 19);
            this.mNamespaceClassesTreeView.Name = "mNamespaceClassesTreeView";
            this.mNamespaceClassesTreeView.Size = new System.Drawing.Size(181, 342);
            this.mNamespaceClassesTreeView.TabIndex = 6;
            this.mRemoteHostHelpBox.SetToolTip(this.mNamespaceClassesTreeView, "All available classes from the namespace selected on the left will appear here");
            // 
            // WMIQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 454);
            this.Controls.Add(this.mDisplayErrorsCheckBox);
            this.Controls.Add(this.mScavengeLabel);
            this.Controls.Add(this.tabControl1);
            this.Name = "WMIQueryForm";
            this.Text = "WMIQueryForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox mNamespaceSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mComputerNameTextBox;
        private System.Windows.Forms.ToolTip mRemoteHostHelpBox;
        private System.Windows.Forms.Label mScavengeLabel;
        private System.Windows.Forms.TreeView mScavengedNSResultTreeView;
        private System.Windows.Forms.Button mScavengeButton;
        private System.Windows.Forms.CheckBox mDisplayErrorsCheckBox;
        private System.Windows.Forms.TreeView mNamespaceClassesTreeView;
    }
}