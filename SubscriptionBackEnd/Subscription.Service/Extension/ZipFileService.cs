using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.ReturnType;

namespace Subscription.Service
{
    public partial class ZipFileService : BaseService
    {

        public BusinessResponse<ZipFileReturnType> ZipFiles(ZipFileDto zipFileDto)
        {
            BusinessResponse<ZipFileReturnType> response = new BusinessResponse<ZipFileReturnType>();

            try
            {
                response.Result = ZipFilesRaw(zipFileDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal ZipFileReturnType ZipFilesRaw(ZipFileDto zipFileDto)
        {
            ZipFileReturnType zipFileReturnType = new ZipFileReturnType();


            using (MemoryStream zipMS = new MemoryStream())
            {
                using (ZipArchive zipArchive = new ZipArchive(zipMS, ZipArchiveMode.Create, true))
                {
                    //loop through files to add
                    foreach (FileToZipInfo fileToZip in zipFileDto.FilesToZip)
                    {
                        //exclude some files? -I don't want to ZIP other .zips in the folder.
                        if (fileToZip.FileExtension == "zip") continue;

                        //read the file bytes
                        byte[] fileToZipBytes = System.IO.File.ReadAllBytes(fileToZip.FilePath);

                        //create the entry - this is the zipped filename
                        //change slashes - now it's VALID
                        ZipArchiveEntry zipFileEntry = zipArchive.CreateEntry(fileToZip.ZipFileName);

                        //add the file contents
                        using (Stream zipEntryStream = zipFileEntry.Open())
                        using (BinaryWriter zipFileBinary = new BinaryWriter(zipEntryStream))
                        {
                            zipFileBinary.Write(fileToZipBytes);
                        }
                    }
                }

                zipFileReturnType.FullOutputPath = String.Format("{0}/{1}.zip", zipFileDto.OutputFilePath, Guid.NewGuid().ToString());

                using (FileStream finalZipFileStream = new FileStream(zipFileReturnType.FullOutputPath, FileMode.Create))
                {
                    zipMS.Seek(0, SeekOrigin.Begin);
                    zipMS.CopyTo(finalZipFileStream);
                }
            }


            return zipFileReturnType;
        }
    }
}
