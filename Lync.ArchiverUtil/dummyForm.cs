using System;
using System.Diagnostics;
using System.Windows.Forms;
using Lync.Archiver;

namespace Lync.ArchiverUtil
{
    public partial class DummyForm : Form
    {
        private static EventLog _myLog;
        private ConversationArchiver convArch;

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
                convArch = new ConversationArchiver();
            }
            catch (Exception exp)
            {
                myLog.WriteEntry(exp.Message + Environment.NewLine + exp.StackTrace);
            }
        }

        private void dummyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            convArch.Dispose();
        }

        private void LyncArchiveUtilMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}