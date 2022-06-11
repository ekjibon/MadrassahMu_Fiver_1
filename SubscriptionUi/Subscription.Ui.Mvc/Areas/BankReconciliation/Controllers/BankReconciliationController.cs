using CoreWeb.Business.Common;
using CoreWeb.Ui.Common.Mvc;
using Subscription.Business.Common;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Ui.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subscription.Service;
using Subscription.Business;
using Subscription.Business.Dto;
using Subscription.Business.Report.Transaction;
using System.IO;
using System.IO.Compression;
using Subscription.Business.ReturnType.BankReconciliation;
using Subscription.Business.Dto.BankReconciliation;

namespace Subscription.Ui.Mvc.Areas.BankReconciliation.Controllers
{
    public class BankReconciliationController : BaseController
    {
        // GET: BankReconciliation/BankReconciliation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BankReconciliationListing()
        {
            return View();
        }

        public ActionResult LoadList(BankReconciliationSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<BankReconciliationListReturnType>> response = new BaseReturnType<BaseListReturnType<BankReconciliationListReturnType>>();
            try
            {
                BusinessResponse<BaseListReturnType<BankReconciliationListReturnType>> businessResponse = serviceFactory.BankReconciliationService.LoadList(sortingPagingInfo);
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



        public ActionResult GetBankReconciliationScreenConstant()
        {
            BaseReturnType<BankReconciliationScreenConstantReturnType> response = new BaseReturnType<BankReconciliationScreenConstantReturnType>();
            try
            {
                BusinessResponse<BankReconciliationScreenConstantReturnType> businessResponse = serviceFactory.BankReconciliationService.GetBankReconciliationScreenConstant();
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

        public ActionResult LoadBankReconciliationContent(LoadBankReconciliationContentDto loadBankReconciliationContentDto)
        {
            BaseReturnType<LoadBankReconciliationContentReturnType> response = new BaseReturnType<LoadBankReconciliationContentReturnType>();
            try
            {
                BusinessResponse<LoadBankReconciliationContentReturnType> businessResponse = serviceFactory.BankReconciliationService.LoadBankReconciliationContent(loadBankReconciliationContentDto);
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

        public ActionResult AnalyseBankReconciliationFile(AnalyseBankReconciliationFileDto analyseBankReconciliationFileDto)
        {
            BaseReturnType<AnalyseBankReconciliationFileReturnType> response = new BaseReturnType<AnalyseBankReconciliationFileReturnType>();
            try
            {
                BusinessResponse<AnalyseBankReconciliationFileReturnType> businessResponse = serviceFactory.BankReconciliationService.PrintBankReconciliationFileForBatch(analyseBankReconciliationFileDto);
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



        public ActionResult LoadBankStatementStagingDetailBatch(LoadBankStatementStagingDetailBatchDto loadBankStatementStagingDetailBatchDto)
        {
            BaseReturnType<LoadBankStatementStagingDetailBatchReturnType> response = new BaseReturnType<LoadBankStatementStagingDetailBatchReturnType>();
            try
            {
                BusinessResponse<LoadBankStatementStagingDetailBatchReturnType> businessResponse = serviceFactory.BankReconciliationService.LoadBankStatementStagingDetailBatch(loadBankStatementStagingDetailBatchDto);
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

        public ActionResult AnalyseBankReconciliationFileForBatch(AnalyseBankReconciliationFileForBatchDto analyseBankReconciliationFileForBatchDto)
        {
            BaseReturnType<AnalyseBankReconciliationFileForBatchReturnType> response = new BaseReturnType<AnalyseBankReconciliationFileForBatchReturnType>();
            try
            {
                BusinessResponse<AnalyseBankReconciliationFileForBatchReturnType> businessResponse = serviceFactory.BankReconciliationService.AnalyseBankReconciliationFileForBatch(analyseBankReconciliationFileForBatchDto);
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


        public ActionResult SaveBankReconciliationFile(SaveBankReconciliationFileDto saveBankReconciliationFileDto)
        {
            BaseReturnType<SaveBankReconciliationFileReturnType> response = new BaseReturnType<SaveBankReconciliationFileReturnType>();
            try
            {
                BusinessResponse<SaveBankReconciliationFileReturnType> businessResponse = serviceFactory.BankReconciliationService.SaveBankReconciliationFile(saveBankReconciliationFileDto);
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

        public ActionResult PrintTransactionReceiptsForBatch(AnalyseBankReconciliationFileForBatchDto analyseBankReconciliationFileForBatchDto)
        {
            try
            {
                BaseReturnType<PrintTransactionReceiptsForBatchReturnType> response = new BaseReturnType<PrintTransactionReceiptsForBatchReturnType>();
                BusinessResponse<PrintTransactionReceiptsForBatchReturnType> businessResponse = serviceFactory.BankReconciliationService.PrintTransactionReceiptsForBatch(analyseBankReconciliationFileForBatchDto);
                if (businessResponse.HasException())
                {
                    throw new Exception("Could not generate report");
                }

                FileStream fs = new FileStream(businessResponse.Result.BatchFilePath, FileMode.Open, FileAccess.Read);
                return File(fs, "application/zip", businessResponse.Result.FileNameWithExtension);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Error", new { area = "Public" });
            }
        }

        public ActionResult DeleteBankReconciliationStagingDetail(DeleteBankReconciliationStagingDetailDto deleteBankReconciliationStagingDetailDto)
        {
            BaseReturnType<bool> response = new BaseReturnType<bool>();
            try
            {
                BusinessResponse<bool> businessResponse = serviceFactory.BankReconciliationService.DeleteBankReconciliationStagingDetail(deleteBankReconciliationStagingDetailDto);
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

        public ActionResult ReconcileBankOrderPopup()
        {
            return View();
        }

        public ActionResult ReconcileBankOrder(ReconcileBankOrderDto reconcileBankOrderReturnType)
        {
            BaseReturnType<ReconcileBankOrderReturnType> response = new BaseReturnType<ReconcileBankOrderReturnType>();
            try
            {
                BusinessResponse<ReconcileBankOrderReturnType> businessResponse = serviceFactory.BankReconciliationService.ReconcileBankOrder(reconcileBankOrderReturnType);
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

        public ActionResult SaveReconcileBankOrder(SaveReconcileBankOrderDto saveReconcileBankOrderDto)
        {
            BaseReturnType<bool> response = new BaseReturnType<bool>();
            try
            {
                BusinessResponse<bool> businessResponse = serviceFactory.BankReconciliationService.SaveReconcileBankOrder(saveReconcileBankOrderDto);
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
        

    }
}