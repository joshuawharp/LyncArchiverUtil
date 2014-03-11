using System;
using SysConfig = System.Configuration;

namespace Lync.Archiver
{
    public static class Configuration
    {
        static Configuration()
        {
            ShouldArchiveInFileSystem =
                Convert.ToBoolean(SysConfig.ConfigurationManager.AppSettings["ShouldArchiveInFileSystem"]);
            //As people are changing the configuration, I am hardcoding this to be true untill, I add other archiving methods.
            ShouldArchiveInFileSystem = true;
            if (ShouldArchiveInFileSystem)
            {
                FileArchivePath = SysConfig.ConfigurationManager.AppSettings["FileArchivePath"];
                FileExtension = SysConfig.ConfigurationManager.AppSettings["FileExtension"];
            }
            ShouldArchiveInOutlookInbox =
                Convert.ToBoolean(SysConfig.ConfigurationManager.AppSettings["ShouldArchiveInOutlookInbox"]);
            ShouldArchiveInGoogleDocuments =
                Convert.ToBoolean(SysConfig.ConfigurationManager.AppSettings["ShouldArchiveInGoogleDocuments"]);
        }

        public static string FileArchivePath { get; private set; }
        public static bool ShouldArchiveInFileSystem { get; private set; }
        public static bool ShouldArchiveInOutlookInbox { get; private set; }
        public static bool ShouldArchiveInGoogleDocuments { get; private set; }
        public static string FileExtension { get; private set; }
    }
}