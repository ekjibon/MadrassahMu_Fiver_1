using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;

namespace Subscription.Service
{
    public class FileService : BaseService
    {
        public BusinessResponse<FileReturnType> UploadFiles(HttpFileCollection files)
        {
            BusinessResponse<FileReturnType> response = new BusinessResponse<FileReturnType>();
            try
            {
                List<UploadFileInternalReturnType> fileUrls = Utils.UploadFiles(files, ServiceFactory.Instance.DocumentService.GetPhysicalDocumentRepositoryPathRaw());
                response.Result = new FileReturnType() { FileUrls = fileUrls.Select(s=>s.FilePath).ToList() };
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        public BusinessResponse<UploadDocumentReturnType> UploadDocuments(HttpFileCollection files)
        {
            BusinessResponse<UploadDocumentReturnType> response = new BusinessResponse<UploadDocumentReturnType>();

            try
            {
                response.Result = UploadDocumentsRaw(files);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal UploadDocumentReturnType UploadDocumentsRaw(HttpFileCollection files)
        {
            ValidateFilesToBeUploaded(files);
            List<Document> documents = new List<Document>();
            UploadDocumentReturnType uploadDocumentReturnType = new UploadDocumentReturnType();
            Subscription.Business.Parameter physicalDocumentRepositoryPath = ServiceFactory.Instance.DocumentService.GetPhysicalDocumentRepositoryParameterRaw();
            Subscription.Business.Parameter documentServerParameterUrl = ServiceFactory.Instance.DocumentService.GetDocumentServerParameterUrlRaw();

            List<UploadFileInternalReturnType> fileUrls = Utils.UploadFiles(files, physicalDocumentRepositoryPath.ParamaterValue);
            fileUrls.ForEach(f =>
            {
                string fileName = f.OriginalFileName.Substring(0, f.OriginalFileName.LastIndexOf("."));
                string fileExtension = f.OriginalFileName.Substring(f.OriginalFileName.LastIndexOf(".") );
                Document document = new Document()
                {
                    FileExtension = fileExtension,
                    FileName = fileName,
                    IdParameterBasePhysicalFilePath = physicalDocumentRepositoryPath.IdParameter,
                    IdParameterBaseServerUrl = documentServerParameterUrl.IdParameter,
                    PhysicalFilePath = f.FilePath,
                    ServerFilePath = f.FilePath
                };
                document.Parameter1 = documentServerParameterUrl;
                documents.Add(document);
            });

            uploadDocumentReturnType.Documents = documents;

            return uploadDocumentReturnType;
        }

        internal void ValidateFilesToBeUploaded(HttpFileCollection files)
        {
            List<long> idParameters = new List<long>() { (long)ParameterEnum.MAX_DOC_UPLOAD_FILE_SIZE };
            List<Parameter> parameters = daoFactory.ParameterDao.GetParameterCustomList(p => idParameters.Contains(p.IdParameter.Value) && p.IsDeactivated != true).EntityList;

            int maxFileSize = int.Parse(parameters.Where(p => p.IdParameter == (long)ParameterEnum.MAX_DOC_UPLOAD_FILE_SIZE).First().ParamaterValue);

            int fileLength = 0;
            string[] fileNames = files.AllKeys;  // This will get names of all files into a string array.
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileLength += files[i].ContentLength;
            }
            if (fileLength > maxFileSize)
                throw new Exception(String.Format("Uploaded file size exceeds allowed size {0} MB", maxFileSize/(1024*1024)));

        }
    }
}
