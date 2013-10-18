using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lync.Archiver
{
    public static class ArchiveHelper
    {
        static List<IArchiver> configuredArchivers;
        static ArchiveHelper()
        {
            configuredArchivers = new List<IArchiver>();
            if (Configuration.ShouldArchiveInFileSystem)
            {
                configuredArchivers.Add(new FileArchiver());
            }
            if (Configuration.ShouldArchiveInGoogleDocuments)
            {
                configuredArchivers.Add(new GoogleDriveArchiver());
            }
            if (Configuration.ShouldArchiveInOutlookInbox)
            {
                configuredArchivers.Add(new OutlookArchiver());
            }
        }

        public static List<IArchiver> GetArchivers()
        {
            return configuredArchivers;
        }
    }
}
