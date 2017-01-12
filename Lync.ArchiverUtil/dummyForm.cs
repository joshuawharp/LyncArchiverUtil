using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Lync.Archiver;
using Microsoft.Win32;
using System.IO;

namespace Lync.ArchiverUtil
{
    public partial class DummyForm : Form
    {
        private static EventLog _myLog;
        private ConversationArchiver convArch;
        private string notofyIconText = "Lync Archiver Utility";

        public DummyForm()
        {
            InitializeComponent();
        }

        private static EventLog myLog
        {
            get
            {
                if (_myLog == null)
                {
                    _myLog = new EventLog();
                    if (!EventLog.SourceExists("LyncArchivingService"))
                    {
                        EventLog.CreateEventSource("LyncArchivingService", "Lync Archiving Service");
                    }
                    _myLog.Source = "LyncArchivingService";
                }
                return _myLog;
            }
        }
 
        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void dummyForm_Load(object sender, EventArgs e)
        {
            try
            {
                var processName = String.Empty;
                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Office\\15.0\\Lync") != null)
                {
                    processName = "lync";
                }
                else if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Communicator") != null)
                {
                    processName = "communicator";
                }

                do
                {
                    var lyncList = Process.GetProcessesByName(processName);
                    if (lyncList.Length == 0)
                    {
                        Thread.Sleep(1000);
                        LyncArchiveUtilNotifyIcon.Text = notofyIconText + " is waiting for 'Lync/Skype for business' to be launched.";
                        //LyncArchiveUtilNotifyIcon.ShowBalloonTip(5000);
                        continue;
                    }

                    if (!lyncList[0].Responding)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    convArch = new ConversationArchiver();
                    LyncArchiveUtilNotifyIcon.Text = notofyIconText;
                    LyncArchiveUtilNotifyIcon.BalloonTipText = processName+" is running."+Environment.NewLine+"Conversations are now recording.";
                    LyncArchiveUtilNotifyIcon.ShowBalloonTip(5000);

                } while (convArch == null);


            }
            catch (Exception exp)
            {
                myLog.WriteEntry(exp.Message + Environment.NewLine + exp.StackTrace);
            }
        }

        private void dummyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (convArch != null)
                    convArch.Dispose();
            }
            catch (Exception exp)
            {
                myLog.WriteEntry(exp.Message + Environment.NewLine + exp.StackTrace);
            }
        }
        
        private void LyncArchiveUtilMenuItem_OpenConversationArchveFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Configuration.FileArchivePath))
                Process.Start(Configuration.FileArchivePath);
            else
                MessageBox.Show("Conversation archive folder is not yet created.","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void LyncArchiveUtilMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}