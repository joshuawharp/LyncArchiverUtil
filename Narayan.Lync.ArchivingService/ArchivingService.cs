using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

using Narayan.Lync;

namespace Narayan.Lync.ArchivingService
{
    partial class ArchivingService : ServiceBase
    {
        ConversationArchiver convArch;
        EventLog myLog;

        public ArchivingService()
        {
            InitializeComponent();
            myLog = new EventLog();

            if (!EventLog.SourceExists("LyncArchivingService"))
            {
               EventLog.CreateEventSource("LyncArchivingService", "Lync Archiving Service");
            }
            
            myLog.Source = "LyncArchivingService";
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                convArch = new ConversationArchiver();
            }
            catch (System.Exception exp)
            {
                myLog.WriteEntry(exp.Message + Environment.NewLine + exp.StackTrace);
            }
        }

        protected override void OnStop()
        {
            convArch.Dispose();
        }
    }
}
