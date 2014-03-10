using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysConfig = System.Configuration;

namespace Lync.Archiver
{
    public static class Configuration
    {
        static Configuration()
        {
            Configuration.ShouldArchiveInFileSystem = Convert.ToBoolean(SysConfig.ConfigurationManager.AppSettings["ShouldArchiveInFileSystem"]);
            //As people are changing the configuration, I am hardcoding this to be true untill, I add other archiving methods.
            Configuration.ShouldArchiveInFileSystem = true;
            if (Configuration.ShouldArchiveInFileSystem)
            {
                Configuration.FileArchivePath = SysConfig.ConfigurationManager.AppSettings["FileArchivePath"];
                Configuration.FileExtension = SysConfig.ConfigurationManager.AppSettings["FileExtension"];
            }
            Configuration.ShouldArchiveInOutlookInbox = Convert.ToBoolean(SysConfig.ConfigurationManager.AppSettings["ShouldArchiveInOutlookInbox"]);
            Configuration.ShouldArchiveInGoogleDocuments = Convert.ToBoolean(SysConfig.ConfigurationManager.AppSettings["ShouldArchiveInGoogleDocuments"]);
        }

        public static string FileArchivePath { get; private set; }
        public static bool ShouldArchiveInFileSystem { get; private set; }
        public static bool ShouldArchiveInOutlookInbox { get; private set; }
        public static bool ShouldArchiveInGoogleDocuments { get; private set; }
        public static string FileExtension { get; private set; }
    }
}
