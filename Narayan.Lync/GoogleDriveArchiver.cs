using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

//using Google.Apis.Drive.v2;
//using Google.Apis.Drive.v2.Data;
//using Google.Apis.Requests;

namespace Narayan.Lync
{
    public class GoogleDriveArchiver:IArchiver
    {
        public void Save(string convKey, ConversationContext convContext)
        {
            throw new NotImplementedException();
        }

        //private static File insertFile(DriveService service, String title, String description, String parentId, String mimeType, String filename)
        //{
        //    // File's metadata.
        //    File body = new File();
        //    body.Title = title;
        //    body.Description = description;
        //    body.MimeType = mimeType;

        //    // Set the parent folder.
        //    if (!String.IsNullOrEmpty(parentId))
        //    {
        //        body.Parents = new List<ParentReference>() { new ParentReference() { Id = parentId } };
        //    }

        //    // File's content.
        //    byte[] byteArray = System.IO.File.ReadAllBytes(filename);
        //    var stream = new System.IO.MemoryStream(byteArray);

        //    try
        //    {
        //        FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, mimeType);
        //        request.Upload();

        //        File file = request.ResponseBody;

        //        // Uncomment the following line to print the File ID.
        //        // Console.WriteLine("File ID: " + file.Id);

        //        return file;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("An error occurred: " + e.Message);
        //        return null;
        //    }
        //}
    }
}
