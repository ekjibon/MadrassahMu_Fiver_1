using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Data;

namespace Subscription.Service
{
    public partial class DocumentService : BaseService
    {
        public BusinessResponse<string> GetStreamablableUrl(Document document)
        {
            BusinessResponse<string> response = new BusinessResponse<string>();

            try
            {
                response.Result = GetStreamablableUrlRaw(document);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal string GetStreamablableUrlRaw(Document document)
        {
            return String.Format("{0}/File/GetStreambleMedia/{1}", ConfigurationManager.AppSettings["ServerUrl"], document.IdDocument);
        }

        public BusinessResponse<GetStreamableFileReturnType> GetStreamableFile(long idDocument)
        {
            BusinessResponse<GetStreamableFileReturnType> response = new BusinessResponse<GetStreamableFileReturnType>();

            try
            {
                response.Result = GetStreamableFileRaw(idDocument);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetStreamableFileReturnType GetStreamableFileRaw(long idDocument)
        {
            List<string> includes = new List<string>() {
                DocumentDatabaseReferences.PARAMETER,
                DocumentDatabaseReferences.PARAMETER1,
            };
            GetStreamableFileReturnType getStreamableFileReturnType = new GetStreamableFileReturnType();
            Document document = daoFactory.DocumentDao.GetDocumentCustom(p => p.IdDocument == idDocument && p.IsDeactivated != true, includes);
            string filePathOnserver = String.Format("{0}/{1}", document.Parameter.ParamaterValue, document.PhysicalFilePath);
            getStreamableFileReturnType.Filename = ServiceFactory.Instance.DocumentService.GetCompleteFileNameFromDocument(document);
            getStreamableFileReturnType.ServerFilePath = filePathOnserver;

            return getStreamableFileReturnType;
        }

        

        public BusinessResponse<string> GetPhysicalDocumentRepositoryPath()
        {
            BusinessResponse<string> response = new BusinessResponse<string>();

            try
            {
                response.Result = GetPhysicalDocumentRepositoryPathRaw();
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal string GetPhysicalDocumentRepositoryPathRaw()
        {
            return daoFactory.DocumentDao.GetPhysicalDocumentRepositoryPath()?.ParamaterValue;
        }

        internal Parameter GetPhysicalDocumentRepositoryParameterRaw()
        {
            return Mapper.MapParameterSingle(daoFactory.DocumentDao.GetPhysicalDocumentRepositoryPath(), true);
        }

        public BusinessResponse<string> GetDocumentServerUrl()
        {
            BusinessResponse<string> response = new BusinessResponse<string>();

            try
            {
                response.Result = GetDocumentServerUrlRaw();
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal string GetDocumentServerUrlRaw()
        {
            return daoFactory.DocumentDao.GetDocumentServerUrl()?.ParamaterValue;
        }

        internal Parameter GetDocumentServerParameterUrlRaw()
        {
            return Mapper.MapParameterSingle(daoFactory.DocumentDao.GetDocumentServerUrl(), true);
        }

        public BusinessResponse<string> GetReportDllPath()
        {
            BusinessResponse<string> response = new BusinessResponse<string>();

            try
            {
                response.Result = GetReportDllPathRaw();
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal string GetReportDllPathRaw()
        {
            return daoFactory.DocumentDao.GetReportDllPath()?.ParamaterValue;
        }

        public BusinessResponse<string> GetMefDllPath()
        {
            BusinessResponse<string> response = new BusinessResponse<string>();

            try
            {
                response.Result = GetMefDllPathRaw();
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal string GetMefDllPathRaw()
        {
            return daoFactory.DocumentDao.GetMefDllPath()?.ParamaterValue;
        }

        internal Document RemapDocument(Document document)
        {
            Document remappedDocument = Mapper.MapDocumentSingle(document, true);
            if (document.Parameter != null)
            {
                remappedDocument.Parameter = Mapper.MapParameterSingle(document.Parameter, true);
            }

            if (document.Parameter1 != null)
            {
                remappedDocument.Parameter1 = Mapper.MapParameterSingle(document.Parameter1, true);
            }
            return remappedDocument;
        }

        public BusinessResponse<string> GetServerUrlFromDocument(Document document)
        {
            BusinessResponse<string> response = new BusinessResponse<string>();

            try
            {
                response.Result = GetServerUrlFromDocumentRaw(document);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal string GetServerUrlFromDocumentRaw(Document document)
        {
            return String.Format("{0}/{1}", document?.Parameter1?.ParamaterValue, document?.ServerFilePath);
        }

        internal string GetDocumentPhysicalPath(Document document, Parameter physicalFilePathParameter = null)
        {
            if (physicalFilePathParameter == null)
            {
                List<long> idParameters = new List<long>() { document.IdParameterBasePhysicalFilePath.Value };
                List<Parameter> parameters = daoFactory.ParameterDao.GetParameterCustomList(p => idParameters.Contains(p.IdParameter.Value)).EntityList;
                physicalFilePathParameter = parameters.Where(p => p.IdParameter == document.IdParameterBasePhysicalFilePath).First();
            }

            string basePath = physicalFilePathParameter.ParamaterValue;
            return string.Format("{0}/{1}", basePath, document.PhysicalFilePath);
        }

        internal bool CheckIfDocumentExists(Document document)
        {
            if (document.IdParameterBasePhysicalFilePath == null || String.IsNullOrEmpty(document.PhysicalFilePath))
                return false;

            string fullPath = GetDocumentPhysicalPath(document);

            if (!File.Exists(fullPath))
                return false;

            return true;
        }

        public Document MapDocument(Document document)
        {
            Document remappedDocument = Mapper.MapDocumentSingle(document, true);
            if (document.DocumentType != null)
            {
                remappedDocument.DocumentType = Mapper.MapDocumentTypeSingle(document.DocumentType, true);
            }

            if (document.Parameter != null)
            {
                remappedDocument.Parameter = Mapper.MapParameterSingle(document.Parameter, true);
            }

            if (document.Parameter1 != null)
            {
                remappedDocument.Parameter1 = Mapper.MapParameterSingle(document.Parameter1, true);
            }

            return remappedDocument;
        }

        internal string GetCompleteFileNameFromDocument(Document document)
        {
            return string.Format("{0}{1}", document.FileName, document.FileExtension);
        }


     
        internal GetDefaultPictureReturnType GetDefaultPicture()
        {
            GetDefaultPictureReturnType getDefaultPictureReturnType = new GetDefaultPictureReturnType();
            List<long> parameterIds = new List<long>() { (long)ParameterEnum.DOCUMENT_SERVER_URL, (long)ParameterEnum.PROFILE_PICTURE, (long)ParameterEnum.COMPANY_PICTURE, (long)ParameterEnum.PROFILE_COVER_PICTURE, (long)ParameterEnum.COMPANY_COVER_PICTURE };
            List<Parameter> parameters = daoFactory.ParameterDao.GetParameterCustomList(p => parameterIds.Contains(p.IdParameter.Value)).EntityList;

            string serverUrl = parameters.Where(p => p.IdParameter == (long)ParameterEnum.DOCUMENT_SERVER_URL).First().ParamaterValue;
            getDefaultPictureReturnType.CompanyCoverPicture = String.Format("{0}/{1}", serverUrl, parameters.Where(p => p.IdParameter == (long)ParameterEnum.COMPANY_COVER_PICTURE).First().ParamaterValue);
            getDefaultPictureReturnType.CompanyPicture = String.Format("{0}/{1}", serverUrl, parameters.Where(p => p.IdParameter == (long)ParameterEnum.COMPANY_PICTURE).First().ParamaterValue);
            getDefaultPictureReturnType.ProfileCoverPicture = String.Format("{0}/{1}", serverUrl, parameters.Where(p => p.IdParameter == (long)ParameterEnum.PROFILE_COVER_PICTURE).First().ParamaterValue);
            getDefaultPictureReturnType.ProfilePicture = String.Format("{0}/{1}", serverUrl, parameters.Where(p => p.IdParameter == (long)ParameterEnum.PROFILE_PICTURE).First().ParamaterValue);

            return getDefaultPictureReturnType;
        }

        public string GetDocumentPhysicalPath(long idDocument)
        {
            List<string> includes = new List<string>() {
                    DocumentDatabaseReferences.PARAMETER,
                };
            Document document = daoFactory.DocumentDao.GetDocumentCustom(f => f.IsDeactivated != true && f.IdDocument == idDocument, includes);
            return GetDocumentPhysicalPath(document, document.Parameter);

        }
    }
}
