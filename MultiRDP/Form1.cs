using System;
using System.IO;
using System.Drawing;
using System.Security;
using System.Management;
using MultiRDP.WMI_Tools;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MultiRDP
{
    public partial class Form1 : Form
    {
        private WmiClassMethodExecutor mWmiProcessExecutor;
        private WmiObjectMethodExecutor mWmiInstanceProcessExecutor;
        private ToolTip mButtonToolTip = new ToolTip();
        //private Process[] mStartedProcess; //Try to get information on each started process, in order to manipulate window positions on creation

        public Form1()
        {
            InitializeComponent();
        }

        private void StartRemoteConnection()
        {
            if (!CheckForValidState(false)) return;
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int startingPoint = 0;

            if (computerNames[0] == "ComputerName")
            {
                startingPoint = 1;
            }

            //Used for the Voya Lab only! If using for other projects, do NOT release this information. 
            if (mBit9Check.Checked)
            {
                string[] bitNineFiles = Directory.GetFiles(@"\\common.ecamericas\ing\lsdp\cs000778");
                string[] batch_jobsFiles = Directory.GetFiles(@"C:\Users\i703682\Documents\Lab Management\Tools\batch_jobs");

                for (int i = startingPoint; i < computerNames.Length; i++)
                {
                    if (!Directory.Exists(@"\\" + computerNames[i] + @"\c$\Bit9") || !Directory.Exists(@"\\" + computerNames[i] + @"\c$\batch_jobs"))
                    {
                        Directory.CreateDirectory(@"\\" + computerNames[i] + @"\c$\Bit9");
                        Directory.CreateDirectory(@"\\" + computerNames[i] + @"\c$\batch_jobs");
                        foreach (string file in bitNineFiles)
                        {
                            File.Copy(file, @"\\" + computerNames[i] + @"\c$\Bit9\" + (string)Path.GetFileName(file), true);
                        }
                        foreach (string files in batch_jobsFiles)
                        {
                            File.Copy(files, @"\\" + computerNames[i] + @"\c$\batch_jobs\" + (string)Path.GetFileName(files), true);
                        }
                    }
                   Process.Start("c:\\windows\\system32\\mstsc.exe", "/v:" + computerNames[i].ToString());
                }
            }
            else
            {
                for (int i = startingPoint; i < computerNames.Length; i++)
                {
                    Process.Start("c:\\windows\\system32\\mstsc.exe", "/v:" + computerNames[i].ToString());
                }
            }
        }

        private void CreateCredentials()
        {
            if (!CheckForValidState(true)) return;
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int startingPoint = 0;

            if (computerNames[0] == "ComputerName") startingPoint = 1;

            for (int i = startingPoint; i < computerNames.Length; i++)
            {
                Process.Start("c:\\windows\\system32\\cmdkey.exe", "/generic:TERMSRV/" + computerNames[i].ToString() + " /user:" + mUserNameTextBox.Text + " /pass:" + mPasswordTextBox.Text);
            }
        }

        private void ManageRemoteUsers()
        {
            if (!CheckForValidState(true)) return;

            SecureString password = CreateSecurePassword(mPasswordTextBox.Text);
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] userName = ParseUserName(mUserNameTextBox.Text);
            int startingPosition = 0;

            if (computerNames[0] == "ComputerName") startingPosition = 1;

            for (int i = startingPosition; i < computerNames.Length; i++)
            {
                try
                {
                    Process.Start("c:\\windows\\system32\\mmc.exe", "c:\\windows\\system32\\compmgmt.msc /computer:" + computerNames[i], userName[1], password, userName[0].ToString());
                }
                catch (Exception e)
                {
                    if (e.Message == "The directory name is invalid")
                    {
                        RightsViolation("admin");
                    }
                    else
                    {
                        RightsViolation(e.Message.ToString());
                    }
                }
            }
        }

        private void ManageRemotePowerState(string pPowerState, string pTime)
        {
            if (!CheckForValidState(true)) return;

            SecureString password = CreateSecurePassword(mPasswordTextBox.Text);
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] userName = mUserNameTextBox.Text.Split('\\');
            string action = String.Empty;
            int startingPosition = 0;
            string time = pTime;
            
            if (time == null)
            {
                time = "30";
            }

            switch (pPowerState)
            {
                case "shutdown":
                    action = "/s";
                    break;
                case "restart":
                    action = "/r";
                    break;
                default:
                    MessageBox.Show("A proper action wasn't selected! Cancelling");
                    return;
            }
            if (computerNames[0] == "ComputerName") startingPosition = 1;

            if (String.IsNullOrEmpty(action))
            {
                MessageBox.Show("An action wasn't selected to perform on the remote computer's power state. Cancelling");
                return;
            }
            for (int i = startingPosition; i < computerNames.Length; i++)
            {
                try
                {
                    Process.Start("c:\\windows\\system32\\shutdown.exe", " " + action + " /m \\\\" + computerNames[i] + " " + "/t " + time + " /c \"This computer is about to " + pPowerState + ". This was initated by " + userName[1] + "\"", userName[1].ToString(), password, userName[0].ToString());
                }
                catch (Exception e)
                {
                    if (e.Message == "The directory name is invalid")
                    {
                        RightsViolation("admin");
                    }
                    else RightsViolation(null);
                }
            }
        }

        private void RightsViolation(string pViolationType)
        {
            switch (pViolationType)
            {
                case "admin":
                    MessageBox.Show("The user you specified doesn't seem to have administrative rights on the system you are attempting to manage. Please input a user that has permissions. If you believe this is an error, contact your Domain administrator");
                    break;
                default:
                    MessageBox.Show(pViolationType);
                    break;
            }
        }

        private void LogOffRemoteUser()
        {
            if (!CheckForValidState(false)) return;

            int startingPosition = 0;
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (computerNames[0] == "ComputerName") startingPosition = 1;

            for (int i = startingPosition; i < computerNames.Length; i++)
            {
                mWmiInstanceProcessExecutor = new WmiObjectMethodExecutor(computerNames[i], "cimv2", "Win32_OperatingSystem=@");
                mWmiInstanceProcessExecutor.SetParamThenExecuteTargetMethodGen<int>("Win32Shutdown", "Flags", 0);
            }
        }


        private SecureString CreateSecurePassword(string pPassword)
        {
            if (pPassword.Contains("Password") || String.IsNullOrWhiteSpace(pPassword)) return null;

            SecureString securePassword = new SecureString();
            foreach (char c in pPassword)
            {
                securePassword.AppendChar(c);
            }

            return securePassword;
        }

        private string[] ParseUserName(string pUserName)
        {
            if (pUserName == "Domain\\UserName" || String.IsNullOrWhiteSpace(pUserName)) return null;
            string[] userName = pUserName.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            return userName;
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
                    else if (mUserNameTextBox.Text == "Domain\\UserName" || mPasswordTextBox.Text == "Password")
                    {
                        MessageBox.Show("You need to input a user/password in order to proceed!");
                        return false;
                    }
                    else { return true; }
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

        private void ChangeDrawState(bool pDrawDefaultState)
        {
            if (pDrawDefaultState)
            {
                this.Height = 374;
                mLogoffButton.Visible = false;
                mRestartButton.Visible = false;
                mShutDownButton.Visible = false;
                mTimeParameterBox.Visible = false;
                mExitButton.Size = new System.Drawing.Size(237, 37);
                mExitButton.Location = new System.Drawing.Point(165, 231);
                mUserNameTextBox.Location = new System.Drawing.Point(0, 288);
                mPasswordTextBox.Location = new System.Drawing.Point(0, 314);
                mWmiQueryButton.Location = new System.Drawing.Point(165, 193);
            }
            else
            {
                this.Height = 427;
                mLogoffButton.Visible = true;
                mRestartButton.Visible = true;
                mShutDownButton.Visible = true;
                mTimeParameterBox.Visible = true;
                mExitButton.Size = new System.Drawing.Size(390, 37);
                mExitButton.Location = new System.Drawing.Point(12, 299);
                mUserNameTextBox.Location = new System.Drawing.Point(0, 342);
                mPasswordTextBox.Location = new System.Drawing.Point(0, 368);
                mWmiQueryButton.Location = new System.Drawing.Point(165, 222);
            }
        }

        #region TheseAreMyFormEvents

        #region Menu Items

        private void exploreRemoteCDrivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForValidState(true)) return;
            string[] ComputerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int startingPoint = 0;
            if (ComputerNames[0] == "ComputerName") startingPoint = 1;
            SecureString securePassword = CreateSecurePassword(mPasswordTextBox.Text);
            string[] userName = ParseUserName(mUserNameTextBox.Text);

            for (int i = startingPoint; i < ComputerNames.Length; i++)
            {
                try
                {
                    Process.Start("c:\\windows\\explorer.exe", "\\\\" + ComputerNames[i].ToString() + "\\c$", userName[1], securePassword, userName[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    break;
                }
                
            }
        }

        private void createCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCredentials();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRemoteUsers();
        }

        private void rDPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartRemoteConnection();
        }

        private void debuggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mDebugTextBox.Enabled == false)
            {
                mDebugTextBox.Enabled = true;
                mDebugTextBox.Visible = true;
                this.Width = 1001;
                this.Height = 378;
            }
            else
            {
                mDebugTextBox.Enabled = false;
                mDebugTextBox.Visible = false;
                this.Height = 374;
                this.Width = 430;
            }
        }

        private void restartComputersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRemotePowerState("restart", mTimeParameterBox.Text);
        }

        private void getRDPWindowHandlesADVANCEDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Dynamic Events
        private void userNameTextBox_Enter(object sender, EventArgs e)
        {
            if (mUserNameTextBox.Text == "Domain\\UserName")
            {
                mUserNameTextBox.Text = String.Empty;
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (mPasswordTextBox.Text == "Password")
            {
                mPasswordTextBox.Text = String.Empty;
                mPasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(mUserNameTextBox.Text))
            {
                mUserNameTextBox.Text = "Domain\\UserName";
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(mPasswordTextBox.Text))
            {
                mPasswordTextBox.UseSystemPasswordChar = false;
                mPasswordTextBox.Text = "Password";
            }
        }

        private void computerNameTextBox_Enter(object sender, EventArgs e)
        {
            string defaultComputerNameText = "Please input hosts here, with a newline seperating each host. For example:\r\n<ComputerNameOne>\r\n<ComputerNameTwo>";
            if (mComputerNameTextBox.Text == defaultComputerNameText)
            {
                mComputerNameTextBox.Text = String.Empty;
            }
        }

        private void computerNameTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(mComputerNameTextBox.Text) || String.IsNullOrEmpty(mComputerNameTextBox.Text))
            {
                mComputerNameTextBox.Text = "Please input hosts here, with a newline seperating each host. For example:\r\n<ComputerNameOne>\r\n<ComputerNameTwo>";
            }
        }

        private void createCredentialsButton_MouseHover(object sender, EventArgs e)
        {
            mButtonToolTip.Show("This will create credentials for the remote system and store them in your\r\nCredentials Manager locally", this.mCreateCredentialsButton);
        }

        private void mRemotePowerStateButton_MouseHover(object sender, EventArgs e)
        {
            mButtonToolTip.Show("Perform an action on the remote systems by clicking a button below. The systems will get a 30 second warning before\r\nperforming the selected action", this.mRemotePowerStateButton);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently we don't have an about box.\r\nThat's kind of a bottom list priority for the time being.\r\nPlease see the changelog @ \\\\wpdmjbedxf.common.ecamericas\\labactivity\\vlmchglg.txt\r\nThis is Beta Version 2.0b");
        }

        private void mBit9Check_MouseHover(object sender, EventArgs e)
        {
            mButtonToolTip.Show("This will copy the Bit9 package onto the C: partition of the computer\r\nbeing remoted into. This will also\r\nput a link on every users desktop to run that package", this.mBit9Check);
        }

        private void mTimeParameterBox_TextChanged(object sender, EventArgs e)
        {
            //TODO: Implement Regex to prevent the input of alpha characters. For now, know that alpha characters will likely crash the program. Handle gracefully at
            //the called function for power management
        }

        private void mTimeParameterBox_MouseHover(object sender, EventArgs e)
        {
            mButtonToolTip.Show("This is for specifying a time paramater for logging off, rebooting, and shutting down\r\nremote systems. Leaving this blank will set a default time of 30 seconds.\r\nZero is a valid time paramater! (for instant results)", this.mTimeParameterBox);
        }

        private void mTimeParameterBox_Enter(object sender, EventArgs e)
        {
            if (mTimeParameterBox.Text == "<Time>") mTimeParameterBox.Text = string.Empty;
        }

        private void mTimeParameterBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mTimeParameterBox.Text))
            {
                mTimeParameterBox.Text = "<Time>";
            }
        }

        #endregion

        #region Buttons

        private void remotePowerStateButton_Click(object sender, EventArgs e)
        {
            if (mShutDownButton.Visible) ChangeDrawState(true);
            else ChangeDrawState(false);
        }
        private void shutDownButton_Click(object sender, EventArgs e)
        {
            ManageRemotePowerState("shutdown", mTimeParameterBox.Text);
            ChangeDrawState(true);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            ManageRemotePowerState("restart", mTimeParameterBox.Text);
            ChangeDrawState(true);
        }

        private void logOffButton_Click(object sender, EventArgs e)
        {
            LogOffRemoteUser();
            ChangeDrawState(true);
        }

        private void remoteManageButton_Click(object sender, EventArgs e)
        {
            ManageRemoteUsers();
        }

        private void startConnectionButton_Click(object sender, EventArgs e)
        {
            StartRemoteConnection();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void createCredentialsButton_Click(object sender, EventArgs e)
        {
            CreateCredentials();
        }

        private void mWmiQueryButton_Click(object sender, EventArgs e)
        {
            WMI_Tools.WMIQueryForm WMIQueryWindow = new WMIQueryForm();
            WMIQueryWindow.Show();
        }

        #endregion

        private void pushBit9InstallerFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForValidState(false)) return;
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int startingPoint = 0;

            if (computerNames[0] == "ComputerName")
            {
                startingPoint = 1;
            }

            string[] bitNineFiles = Directory.GetFiles(@"\\common.ecamericas\ing\lsdp\cs000778");
            string[] batch_jobsFiles = Directory.GetFiles(@"C:\Users\i703682\Documents\Lab Management\Tools\batch_jobs");

            for (int i = startingPoint; i < computerNames.Length; i++)
            {
                if (!Directory.Exists(@"\\" + computerNames[i] + @"\c$\Bit9") || !Directory.Exists(@"\\" + computerNames[i] + @"\c$\batch_jobs"))
                {
                    Directory.CreateDirectory(@"\\" + computerNames[i] + @"\c$\Bit9");
                    Directory.CreateDirectory(@"\\" + computerNames[i] + @"\c$\batch_jobs");
                    foreach (string file in bitNineFiles)
                    {
                        File.Copy(file, @"\\" + computerNames[i] + @"\c$\Bit9\" + (string)Path.GetFileName(file), true);
                    }
                    foreach (string files in batch_jobsFiles)
                    {
                        File.Copy(files, @"\\" + computerNames[i] + @"\c$\batch_jobs\" + (string)Path.GetFileName(files), true);
                    }
                    if (Directory.Exists(@"\\" + computerNames[i] + @"\c$\Documents and Settings"))
                    {
                        File.Copy(@"c:\bit9.bat", @"\\" + computerNames[i] + @"\c$\Documents and Settings\i703682\desktop\bit9.bat");
                    }
                    else
                    {
                        File.Copy(@"c:\bit9.bat", @"\\" + computerNames[i] + @"\c$\users\i703682\desktop\bit9.bat");
                    }
                    
                }
            }

        }

        #endregion

        private void deleteBit9InstallerFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckForValidState(false)) return;
            string[] computerNames = mComputerNameTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int startingPoint = 0;

            if (computerNames[0] == "ComputerName")
            {
                startingPoint = 1;
            }

            for (int i = startingPoint; i < computerNames.Length; i++)
            {
                if (Directory.Exists(@"\\" + computerNames[i] + @"\c$\Bit9") || Directory.Exists(@"\\" + computerNames[i] + @"\c$\batch_jobs"))
                {
                    Directory.Delete(@"\\" + computerNames[i] + @"\c$\Bit9", true);
                    Directory.Delete(@"\\" + computerNames[i] + @"\c$\batch_jobs", true);
                    if (Directory.Exists(@"\\" + computerNames[i] + @"\c$\Documents and Settings"))
                    {
                        File.Delete(@"\\" + computerNames[i] + @"\c$\Documents and Settings\i703682\desktop\bit9.bat");
                    }
                    else
                    {
                        File.Delete(@"\\" + computerNames[i] + @"\c$\users\i703682\desktop\bit9.bat");
                    }
                }
            }
        }
    }
}
