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
        public ArchivingService()
        {
            InitializeComponent();

            if (!EventLog.SourceExists("LyncArchivingService"))
            {
                //An event log source should not be created and immediately used. 
                //There is a latency time to enable the source, it should be created 
                //prior to executing the application that uses the source. 
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("LyncArchivingService", "Lync Archiving Service");
                // The source is created.  Exit the application to allow it to be registered. 
            }

            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog();
            myLog.Source = "LyncArchivingService";
        }
        ConversationArchiver convArch;
        EventLog myLog = new EventLog();
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
