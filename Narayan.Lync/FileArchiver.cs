using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lync.Archiver
{
    public class FileArchiver:IArchiver
    {
        public void Save(string convKey,ConversationContext convContext)
        {
            try
            {
                var fileName = convKey.Replace(',', '_');
                fileName = fileName.Replace('(', '_');
                fileName = fileName.Replace(')', '_');
                fileName = fileName.Replace(' ', '_');

                fileName = fileName.Replace(':', '.');
                fileName = fileName.Replace("__", "_");
                fileName = fileName.Trim(new char[] { '_' });

                var path = Configuration.FileArchivePath + fileName + Configuration.FileExtension;
                var conversationText = convContext.GetConversation();
                
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("--------------------------------------------------------------------------------");
                        sw.WriteLine(DateTime.Now.ToString());
                        sw.WriteLine("--------------------------------------------------------------------------------");
                        sw.Write(conversationText);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        var fileInfo = new FileInfo(path);
                        if (!fileInfo.LastWriteTime.Date.Equals(DateTime.Now.Date))
                        {
                            sw.WriteLine("--------------------------------------------------------------------------------");
                            sw.WriteLine(DateTime.Now.ToString());
                            sw.WriteLine("--------------------------------------------------------------------------------");
                        }
                        sw.Write(conversationText);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
