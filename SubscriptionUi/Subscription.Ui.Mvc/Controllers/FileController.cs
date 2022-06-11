using CoreWeb.Business.Common;
using CoreWeb.Ui.Common.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subscription.Business.Common;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Service;

namespace Subscription.Ui.Mvc.Controllers
{
    public class FileController : BaseController
    {
        public ActionResult UploadFiles()
        {
            BaseReturnType<FileReturnType> response = new BaseReturnType<FileReturnType>();
            try
            {
                HttpContext context = System.Web.HttpContext.Current;
                HttpFileCollection files = context.Request.Files;
                BusinessResponse<FileReturnType> businessResponse = ServiceFactory.Instance.FileService.UploadFiles(files);

                if (businessResponse.HasException())
                {
                    response.Status = RequestStatusEnum.FAILURE;
                    response.ErrorMessage = businessResponse.Exception.Message;
                    return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
                }
                response.Status = RequestStatusEnum.SUCCESS;
                response.Result = businessResponse.Result;
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500);
            }

            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadDocuments()
        {
            BaseReturnType<UploadDocumentReturnType> response = new BaseReturnType<UploadDocumentReturnType>();
            try
            {
                HttpContext context = System.Web.HttpContext.Current;
                HttpFileCollection files = context.Request.Files;
                BusinessResponse<UploadDocumentReturnType> businessResponse = ServiceFactory.Instance.FileService.UploadDocuments(files);

                if (businessResponse.HasException())
                {
                    response.Status = RequestStatusEnum.FAILURE;
                    response.ErrorMessage = businessResponse.Exception.Message;
                    return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
                }
                response.Status = RequestStatusEnum.SUCCESS;
                response.Result = businessResponse.Result;
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500);
            }

            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStreambleMedia(long id)
        {
            BaseReturnType<FileReturnType> response = new BaseReturnType<FileReturnType>();
            try
            {
                BusinessResponse<GetStreamableFileReturnType> businessResponse = serviceFactory.DocumentService.GetStreamableFile(id);
                if (businessResponse.HasException())
                {
                    response.Status = RequestStatusEnum.FAILURE;
                    response.ErrorMessage = businessResponse.Exception.Message;
                    return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
                }

                return File(new FileStream(businessResponse.Result.ServerFilePath, FileMode.Open), "application/octet-stream", businessResponse.Result.Filename);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        //public ActionResult GetFileType()
        //{
        //    BaseReturnType<List<FileTypeReturnType>> response = new BaseReturnType<List<FileTypeReturnType>>();
        //    try
        //    {
        //        BusinessResponse<List<FileTypeReturnType>> businessResponse = serviceFactory.DocumentService.GetFileType();
        //        if (businessResponse.HasException())
        //        {
        //            response.Status = RequestStatusEnum.FAILURE;
        //            response.ErrorMessage = businessResponse.Exception.Message;
        //            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        //        }
        //        response.Status = RequestStatusEnum.SUCCESS;
        //        response.Result = businessResponse.Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(500);
        //    }
        //    return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        //}

    }
}