using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MultiRDP.WMI_Tools
{
    public partial class WMIQueryForm : Form
    {

        #region privateVars
        WmiInformationGatherer WmiQueryTool;
        string mPreviousHostScavenged;
        Form mResultsForm;
        TextBox resultsTextBox;
        #endregion

        public WMIQueryForm()
        {
            InitializeComponent();
        }       

        private void mScavengeButton_Click(object sender, EventArgs e)
        {
            if (!CheckForValidState(false)) return;
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (WmiQueryTool == null)
            {
                mScavengedNSResultTreeView.Nodes.Clear();
                for (int i = 0; i < computerNames.Length; i++)
                {
                    mPreviousHostScavenged = computerNames[i];
                    WmiQueryTool = new WmiInformationGatherer(computerNames[i]);
                    if (WmiQueryTool.RemoteHostError != null)
                    {
                        FireError(computerNames[i]);
                        mScavengedNSResultTreeView.Nodes.Add(computerNames[i]);
                        mScavengedNSResultTreeView.Nodes[i].BackColor = Color.Red;
                        continue;
                    }
                    else
                    {
                        mScavengedNSResultTreeView.Nodes.Add(computerNames[i]);
                        foreach (string Namespace in WmiQueryTool.AvailableWMINamespaces)
                        {
                            mScavengedNSResultTreeView.Nodes[i].Nodes.Add(Namespace);
                        }
                        ScavengeStatus(WmiQueryTool.ConnectedHost, true);
                        WmiQueryTool = null;
                    }
                }
            }
        }

        private bool CheckForValidState(bool pNeedsUserPass)
        {
            string computerTextBoxDefault = "Please input hosts here, with a newline seperating each host. For example:\r\n<ComputerNameOne>\r\n<ComputerNameTwo>";
            switch (pNeedsUserPass)
            {
                case true:
                    if (mComputerNameTextBox.Text == computerTextBoxDefault)
                    {
                        MessageBox.Show("You didn't enter any remote hosts!");
                        return false;
                    }
                    else { return true; } //remove if below block is uncommented
                //else if (mUserNameTextBox.Text == "Domain\\UserName" || mPasswordTextBox.Text == "Password")
                //{
                //    MessageBox.Show("You need to input a user/password in order to proceed!");
                //    return false;
                //}
                //else { return true; }
                case false:
                    if (mComputerNameTextBox.Text == computerTextBoxDefault)
                    {
                        MessageBox.Show("You didn't enter any remote hosts!");
                        return false;
                    }
                    else { return true; }
                default:
                    return false;
            }
        }       

        private void ScavengeStatus(string pScavengedHost, bool pSuccess)
        {
            if (pSuccess)
            {
                mScavengeLabel.Visible = true;
                mScavengeLabel.Text = "Remote host " + pScavengedHost + " has been scavenged";
            }
            else
            {
                mScavengeLabel.Visible = true;
                mScavengeLabel.Text = "Remote host " + pScavengedHost + " has failed to be scavenged. Please see error log";
            }
            
        }        

        private void FireError(string pHost)
        {
            string error = "Something went wrong";
            switch (WmiQueryTool.RemoteHostError.HResult)
            {
                case -2147023174:
                    error = pHost + " " + WmiQueryTool.RemoteHostError.Message.ToString() + "\r\n\r\nThe remote host is likely offline or having issues. Check remote IP and try again";
                    WmiQueryTool = null;
                    ScavengeStatus(pHost, false);
                    break;
                case -2147023838:
                    error = pHost + " " + WmiQueryTool.RemoteHostError.Message.ToString() + "\r\n\r\nThe Remote host appears to not be WMI capable. This can be caused by the WMI service being disabled, or the remote host not being a Windows system. Please validate remote host settings and try again";
                    WmiQueryTool = null;
                    ScavengeStatus(pHost, false);
                    break;
                case -2147024891:
                    error = pHost + " " + WmiQueryTool.RemoteHostError.Message.ToString() + "\r\n\r\nYour currently logged on user does not appear to have rights on the remote system. Please check your rights and try again. Your user may need to be added to the RDP group first";
                    WmiQueryTool = null;
                    ScavengeStatus(pHost, false);
                    break;
                default:
                    error = pHost + " " + WmiQueryTool.RemoteHostError.Message.ToString() + "\r\n\r\nSomething went horribly wrong. There's an error code here. Report it to the developer, along with what you were doing so he can replicate the issue";
                    break;
            }

            if (mResultsForm == null)
            {
                mResultsForm = new Form();
                mResultsForm.FormClosed += mResultsForm_FormClosed;
                resultsTextBox = new TextBox();
                mResultsForm.Width = 615;
                mResultsForm.Height = 433;
                mResultsForm.Controls.Add(resultsTextBox);
                mResultsForm.Text = "Error Window";
                mResultsForm.MaximumSize = new Size(615, 433);
                mResultsForm.MinimumSize = new Size(615, 433);
                mResultsForm.SetDesktopLocation(0, 0);
                resultsTextBox.Location = new Point(0, 0);
                resultsTextBox.Size = new Size(600, 399);
                resultsTextBox.Multiline = true;
                resultsTextBox.ScrollBars = ScrollBars.Vertical;
                resultsTextBox.Visible = true;
                resultsTextBox.Enabled = true;
                resultsTextBox.AppendText(error + "\r\n\r\n");
            }
            else
            {
                resultsTextBox.AppendText(error + "\r\n\r\n");
            }
            
        }

        #region controlevents 
        
        private void label2_MouseHover(object sender, EventArgs e)
        {
            mRemoteHostHelpBox.Show("If this box has a host name entered, the Available WMI namespaces on that host will be displayed in the tree view to the right", label2);
        }

        private void mResultsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mResultsForm = null;
            if (mDisplayErrorsCheckBox.Checked)
            {
                mDisplayErrorsCheckBox.Checked = false;
            }
        }

        private void mNamespaceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mNamespaceSelector_Click(object sender, EventArgs e)
        {
            WmiQueryTool = new WmiInformationGatherer("localhost");
            mNamespaceSelector.Items.Clear();
            foreach (string Namespace in WmiQueryTool.AvailableWMINamespaces)
            {
                mNamespaceSelector.Items.Add(Namespace);
            }
            WmiQueryTool = null;
        }

        private void mDisplayErrorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mDisplayErrorsCheckBox.Checked)
            {
                if (mResultsForm != null)
                {
                    mResultsForm.Visible = true;
                }
            }
            else
            {
                if (mResultsForm != null)
                {
                    mResultsForm.Visible = false;
                }
            }
        }        

        private void mComputerNameTextBox_Enter(object sender, EventArgs e)
        {
            string defaultComputerNameText = "Please input hosts here, with a newline seperating each host. For example:" + Environment.NewLine + "<ComputerNameOne>" + Environment.NewLine + "<ComputerNameTwo>";
            if (mComputerNameTextBox.Text == defaultComputerNameText)
            {
                mComputerNameTextBox.Text = String.Empty;
            }            
        }

        private void mComputerNameTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(mComputerNameTextBox.Text) || String.IsNullOrEmpty(mComputerNameTextBox.Text))
            {
                mComputerNameTextBox.Text = "Please input hosts here, with a newline seperating each host. For example:" + Environment.NewLine + "<ComputerNameOne>" + Environment.NewLine + "<ComputerNameTwo>";
            }
        }

        private void mScavengedNSResultTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Node.Parent == null)
            //{
            //    return;
            //}
            //else
            //{
            //    WmiQueryTool = new WmiInformationGatherer(
            //}
        }
       

        #endregion

       



    }
}
