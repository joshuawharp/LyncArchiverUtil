using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Lync.Archiver;

namespace Lync.ArchiverUtil
{
    public partial class dummyForm : Form
    {
        public dummyForm()
        {
            InitializeComponent();
        }

        ConversationArchiver convArch;
        static EventLog _myLog;
        private EventLog myLog
        {
            get
            {
                if (myLog == null)
                {
                    _myLog = new EventLog();
                    if (!EventLog.SourceExists("LyncArchivingService"))
                    {
                        EventLog.CreateEventSource("LyncArchivingService", "Lync Archiving Service");
                    }

                    myLog.Source = "LyncArchivingService";
                }
                return _myLog;
            }
        }

        private void dummyForm_Load(object sender, EventArgs e)
        {
            try
            {
                convArch = new ConversationArchiver();
            }
            catch (System.Exception exp)
            {
                myLog.WriteEntry(exp.Message ?? String.Empty + Environment.NewLine + exp.StackTrace ?? String.Empty);
            }
        }

        private void dummyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            convArch.Dispose();
        }

        private void LyncArchiveUtilMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
    }
}
