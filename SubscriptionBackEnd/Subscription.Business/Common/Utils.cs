using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Subscription.Business.ReturnType;

namespace Subscription.Business.Common
{
    public class Utils
    {
        public static List<UploadFileInternalReturnType> UploadFiles(HttpFileCollection files, string physicalFilePath)
        {
            List<UploadFileInternalReturnType> uploadFileInternalReturnTypes = new List<UploadFileInternalReturnType>();
            var fileUrls = new List<string>();
            for (int i = 0; i < files.Count; i++)
            {
                uploadFileInternalReturnTypes.Add(new UploadFileInternalReturnType() { FilePath = UploadFile(files[i], physicalFilePath), OriginalFileName = files[i].FileName });
            }

            return uploadFileInternalReturnTypes;
        }

        public static string UploadFile(HttpPostedFile file, string physicalFilePath)
        {
            var docfile = new List<string>();

            var fileExtension = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);
            string fileNameWithoutExtension = Guid.NewGuid().ToString();
            var newFileName = String.Format("{0}.{1}", fileNameWithoutExtension, fileExtension);
            string filePath = Path.Combine(physicalFilePath, newFileName);

            file.SaveAs(filePath);

            return newFileName;
        }

    }
}
