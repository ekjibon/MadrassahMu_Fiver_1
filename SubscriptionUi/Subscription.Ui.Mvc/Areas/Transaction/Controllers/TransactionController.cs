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
using Subscription.Business.Dto.Subscription;
using Subscription.Business.ReturnType.Subscription;
using Subscription.Business.Dto;
using Subscription.Business;
using Subscription.Business.ReturnType;
using System.IO;
using Subscription.Service;
using Subscription.Business.Report.Transaction;

namespace Subscription.Ui.Mvc.Areas.Transaction.Controllers
{
    public class TransactionController : BaseController
    {
        // GET: Transaction/Transaction
        public ActionResult TransactionSale()
        {
            return View();
        }

        public ActionResult TransactionSaleListing()
        {
            return View();
        }

        public ActionResult CreditTransactionSaleListing()
        {
            return View();
        }

        public ActionResult TransactionSaleSignature()
        {
            return View();
        }

        public ActionResult TransactionSalePrint()
        {
            try
            {
                var id = RouteData.Values["idTransaction"];
                long idTransaction;
                if (id == null || !long.TryParse(id.ToString(), out idTransaction))
                    throw new Exception("Transaction id not specified");

                BusinessResponse<GetTransactionSaleForPrintReturnType> getTransactionSaleForPrintReturnType = serviceFactory.TransactionService.GetTransactionSaleForPrint(idTransaction);
                if (getTransactionSaleForPrintReturnType.HasException())
                {
                    throw new Exception("Could not fetch detail for transaction");
                }

                BusinessResponse<BaseReportReturnType> response = new ReportService().GenerateReport(new TransactionReceiptDto()
                {
                    ReportCode = "5015d08d-8d55-4657-b06c-aed1a56274ce",
                    ReportFormat = "PDF",
                    IdTransaction = idTransaction,
                    GetTransactionSaleForPrintReturnType = getTransactionSaleForPrintReturnType.Result
                });

                if (getTransactionSaleForPrintReturnType.HasException())
                {
                    throw new Exception("Could not generate receipt");
                }

                FileStream fs = new FileStream(response.Result.FilePath, FileMode.Open, FileAccess.Read);
                return File(fs, "application/pdf");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("TransactionSaleListing", "Transaction", new { area = "Transaction" }); ///To do, handle exception properly
            }
        }

        public ActionResult GetTransactionTotalForDate()
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                BusinessResponse<BaseReportReturnType> response = new ReportService().GenerateReport(new GetTransactionTotalForDateDto()
                {
                    ReportCode = "8092807d-065b-40be-9693-955bfd5698be",
                    ReportFormat = "PDF",
                    IdUser = GlobalVariableService.Instance.UserLoggedWithDetail.IdUser.Value,
                    Date = dateTime
                });

                if (response.HasException())
                {
                    throw new Exception("Could not generate report");
                }

                FileStream fs = new FileStream(response.Result.FilePath, FileMode.Open, FileAccess.Read);
                return File(fs, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", String.Format("Transaction Total For {0}.xlsx", dateTime.ToString("dd/MM/yyyy")));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Error", new { area = "Public" });
            }
        }

        public ActionResult SaveScheduledTransaction(SaveScheduledTransactionDto saveScheduledTransactionDto)
        {
            BaseReturnType<SaveScheduledTransactionReturnType> response = new BaseReturnType<SaveScheduledTransactionReturnType>();
            try
            {
                BusinessResponse<SaveScheduledTransactionReturnType> businessResponse = new BusinessResponse<SaveScheduledTransactionReturnType>();
                businessResponse = serviceFactory.TransactionService.SaveScheduledTransaction(saveScheduledTransactionDto);
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

        public ActionResult SaveTemporaryTransaction(SaveTemporaryTransactionDto saveTemporaryTransactionDto)
        {
            BaseReturnType<SaveTemporaryTransactionReturnType> response = new BaseReturnType<SaveTemporaryTransactionReturnType>();
            try
            {
                BusinessResponse<SaveTemporaryTransactionReturnType> businessResponse = serviceFactory.TemporaryTransactionOrderService.SaveTemporaryTransaction(saveTemporaryTransactionDto);
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

        /*public ActionResult SavePaymentForTransactionDue(SavePaymentForTransactionDueDto savePaymentForTransactionDueDto)
        {
            BaseReturnType<SavePaymentForTransactionDueReturnType> response = new BaseReturnType<SavePaymentForTransactionDueReturnType>();
            try
            {
                BusinessResponse<SavePaymentForTransactionDueReturnType> businessResponse = new BusinessResponse<SavePaymentForTransactionDueReturnType>();
                businessResponse = serviceFactory.PaymentService.SavePaymentForTransactionDue(savePaymentForTransactionDueDto);
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
        }*/

        public ActionResult SaveTransactionPayment(SaveTransactionPaymentDto saveTransactionPaymentDto)
        {
            BaseReturnType<SaveTransactionPaymentReturnType> response = new BaseReturnType<SaveTransactionPaymentReturnType>();
            try
            {
                BusinessResponse<SaveTransactionPaymentReturnType> businessResponse = new BusinessResponse<SaveTransactionPaymentReturnType>();
                businessResponse = serviceFactory.PaymentService.SaveTransactionPayment(saveTransactionPaymentDto);
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

        public ActionResult GetAllTransactionsPerCustomer(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Business.Transaction>> response = new BaseReturnType<BaseListReturnType<Business.Transaction>>();
            try
            {
                BusinessResponse<BaseListReturnType<Business.Transaction>> businessResponse = serviceFactory.TransactionService.GetAllTransactionsPerCustomer(sortingPagingInfo.IdCustomer);
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

            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet); //response
        }

        public ActionResult GetAllScheduledTransactionsPerCustomer(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Business.Transaction>> response = new BaseReturnType<BaseListReturnType<Business.Transaction>>();
            try
            {
                BusinessResponse<BaseListReturnType<Business.Transaction>> businessResponse = serviceFactory.TransactionService.GetAllScheduledTransactionsPerCustomer(sortingPagingInfo.IdCustomer);
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

            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet); //response
        }


        public ActionResult GetAllScheduledTransactionList(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Business.Transaction>> response = new BaseReturnType<BaseListReturnType<Business.Transaction>>();
            try
            {
                BusinessResponse<BaseListReturnType<Business.Transaction>> businessResponse = serviceFactory.TransactionService.GetAllScheduledTransactionList(sortingPagingInfo);
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

            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet); //response
        }

        public ActionResult GetScheduledTransaction(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<GetScheduledTransactionReturnType> response = new BaseReturnType<GetScheduledTransactionReturnType>();
            try
            {
                BusinessResponse<GetScheduledTransactionReturnType> businessResponse = serviceFactory.TransactionService.GetScheduledTransaction(sortingPagingInfo);
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

            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet); //response
        }

        public ActionResult GetScheduledTransactionPayments(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<Business.Transaction> response = new BaseReturnType<Business.Transaction>();
            try
            {
                BusinessResponse<Business.Transaction> businessResponse = serviceFactory.TransactionService.GetScheduledTransactionPayments(sortingPagingInfo);
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

            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet); //response
        }

        public ActionResult GetTemporaryTransactionOrderForWorkstation(GetTemporaryTransactionOrderForWorkstationDto getTemporaryTransactionOrderForWorkstationDto)
        {
            BaseReturnType<GetTemporaryTransactionOrderForWorkstationReturnType> response = new BaseReturnType<GetTemporaryTransactionOrderForWorkstationReturnType>();
            try
            {
                BusinessResponse<GetTemporaryTransactionOrderForWorkstationReturnType> businessResponse = serviceFactory.TemporaryTransactionOrderService.GetTemporaryTransactionOrderForWorkstation(getTemporaryTransactionOrderForWorkstationDto);
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

        public ActionResult GetSignatureForTemporaryTransactionSignature(GetSignatureForTemporaryTransactionSignatureDto getSignatureForTemporaryTransactionSignatureDto)
        {
            BaseReturnType<GetSignatureForTemporaryTransactionSignatureReturnType> response = new BaseReturnType<GetSignatureForTemporaryTransactionSignatureReturnType>();
            try
            {
                BusinessResponse<GetSignatureForTemporaryTransactionSignatureReturnType> businessResponse = serviceFactory.TemporaryTransactionOrderService.GetSignatureForTemporaryTransactionSignature(getSignatureForTemporaryTransactionSignatureDto);
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

        public ActionResult SendEmailToClient(SendEmailToClientDto sendEmailToClientDto)
        {
            BaseReturnType<bool> response = new BaseReturnType<bool>();
            try
            {
                BusinessResponse<bool> businessResponse = serviceFactory.TransactionService.SendEmailToClient(sendEmailToClientDto);
                if (businessResponse.HasException())
                {
                    response.Status = RequestStatusEnum.FAILURE;
                    response.ErrorMessage = businessResponse.Exception.Message;
                    return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
                }
                response.Status = RequestStatusEnum.SUCCESS;
                response.Result = true;
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500);
            }
            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmailForTransaction(GetEmailForTransactionDto getEmailForTransactionDto)
        {
            BaseReturnType<GetEmailForTransactionReturnType> response = new BaseReturnType<GetEmailForTransactionReturnType>();
            try
            {
                BusinessResponse<GetEmailForTransactionReturnType> businessResponse = serviceFactory.TransactionService.GetEmailForTransaction(getEmailForTransactionDto);
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

        public ActionResult SaveEmailForTransaction(SaveEmailForTransactionDto saveEmailForTransactionDto)
        {
            BaseReturnType<SaveEmailForTransactionReturnType> response = new BaseReturnType<SaveEmailForTransactionReturnType>();
            try
            {
                BusinessResponse<SaveEmailForTransactionReturnType> businessResponse = serviceFactory.TransactionService.SaveEmailForTransaction(saveEmailForTransactionDto);
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