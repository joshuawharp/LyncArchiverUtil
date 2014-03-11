using System;
using System.Globalization;
using System.IO;

namespace Lync.Archiver
{
    public class FileArchiver : IArchiver
    {
        public void Save(string convKey, ConversationContext convContext)
        {
            var fileName = convKey.Replace(',', '_');
            fileName = fileName.Replace('(', '_');
            fileName = fileName.Replace(')', '_');
            fileName = fileName.Replace(' ', '_');

            fileName = fileName.Replace(':', '.');
            fileName = fileName.Replace("__", "_");
            fileName = fileName.Trim(new[] {'_'});

            var path = Configuration.FileArchivePath + fileName + Configuration.FileExtension;
            var conversationText = convContext.GetConversation();

            if (!File.Exists(path))
            {
                using (var sw = File.CreateText(path))
                {
                    sw.WriteLine("--------------------------------------------------------------------------------");
                    sw.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    sw.WriteLine("--------------------------------------------------------------------------------");
                    sw.Write(conversationText);
                }
            }
            else
            {
                using (var sw = File.AppendText(path))
                {
                    var fileInfo = new FileInfo(path);
                    if (!fileInfo.LastWriteTime.Date.Equals(DateTime.Now.Date))
                    {
                        sw.WriteLine("--------------------------------------------------------------------------------");
                        sw.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        sw.WriteLine("--------------------------------------------------------------------------------");
                    }
                    sw.Write(conversationText);
                }
            }
        }
    }
}