using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Lync.Archiver
{
    public class FileArchiver : IArchiver
    {
        private const int MaxPath = 259;

        public void Save(string convKey, ConversationContext convContext)
        {
            StreamWriter streamWriter = null;
                            var fileNameShortened = false;
                var fileName = convKey.Replace(',', '_');
                fileName = fileName.Replace('(', '_');
                fileName = fileName.Replace(')', '_');
                fileName = fileName.Replace(' ', '_');

                fileName = fileName.Replace(':', '.');
                fileName = fileName.Replace("__", "_");
                fileName = fileName.Trim(new[] {'_'});

                var path = Configuration.FileArchivePath + fileName + Configuration.FileExtension;
                //Check for max path
                if (path.Length > MaxPath)
                {
                    path = Configuration.FileArchivePath +
                           fileName.Substring(0, (fileName.Length - (path.Length - MaxPath))) +
                           Configuration.FileExtension;
                    fileNameShortened = true;
                }

                var conversationText = convContext.GetConversation();


            try
            {

                var newFile = false;
                if (!File.Exists(path))
                {
                    streamWriter = File.CreateText(path);
                    newFile = true;
                }
                else
                {
                    streamWriter = File.AppendText(path);
                }

                var fileInfo = new FileInfo(path);
                if (!fileInfo.LastWriteTime.Date.Equals(DateTime.Now.Date) || newFile)
                {
                    streamWriter.WriteLine(
                        "--------------------------------------------------------------------------------");
                    streamWriter.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    streamWriter.WriteLine(
                        "--------------------------------------------------------------------------------");
                }
                if (fileNameShortened)
                    streamWriter.WriteLine("File Name Shortened. Actual participants in the conversation : "+fileName);

                conversationText = Regex.Replace(conversationText, @"(\r?\n)\1+", "$1");
                streamWriter.Write(conversationText);
            }
            finally
            {
                if(streamWriter!=null)
                    streamWriter.Dispose();
            }
        }
    }
}