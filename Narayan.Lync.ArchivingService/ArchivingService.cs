using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

using Lync.Archiver;

namespace Lync.Archiver.Service
{
    partial class ArchivingService : ServiceBase
    {
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


        public ArchivingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                convArch = new ConversationArchiver();
            }
            catch (System.Exception exp)
            {
                myLog.WriteEntry(exp.Message??String.Empty + Environment.NewLine + exp.StackTrace??String.Empty);
            }
        }

        protected override void OnStop()
        {
            convArch.Dispose();
        }
    }
}
