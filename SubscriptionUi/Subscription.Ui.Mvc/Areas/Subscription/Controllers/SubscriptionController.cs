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
using Subscription.Business.ReturnType.Subscription;
using Subscription.Business.Dto.Subscription;
using Subscription.Business.Dto;

namespace Subscription.Ui.Mvc.Areas.Subscription.Controllers
{
    public class SubscriptionController : BaseController
    {
        // GET: Subscription/Subscription
        public ActionResult ScheduleTransactionSale()
        {
            return View();
        }

        public ActionResult Edit() 
        { 
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSearchPopup()
        {
            return View();
        }

        public ActionResult ProductSearchPopup()
        {
            return View();
        }

        public ActionResult AddInstallmentPopup()
        {
            return View();
        }
        
        public ActionResult SelectCustomer()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult DefineFrequency()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult PaymentScheduledTransaction()
        {
            return View();
        }

        public ActionResult ScheduleDetail()
        {
            return View();
        }

        public ActionResult SelectTransaction()
        {
            return View();
        }

        public ActionResult ViewAllScheduledTransactions()
        {
            return View();
        }

        public ActionResult ViewScheduledTransaction()
        {
            return View();
        }

        public ActionResult UITEST()
        {
            return View();
        }


        public ActionResult GetCustomerList(CustomerListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Customer>> response = new BaseReturnType<BaseListReturnType<Customer>>();
            try
            {
                BusinessResponse<BaseListReturnType<Customer>> businessResponse = serviceFactory.CustomerService.LoadCustomerList(sortingPagingInfo);
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

        public ActionResult GetProductList(ProductListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Product>> response = new BaseReturnType<BaseListReturnType<Product>>();
            try
            {
                BusinessResponse<BaseListReturnType<Product>> businessResponse = serviceFactory.ProductService.LoadProductList(sortingPagingInfo);
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

        public ActionResult GetLastPaymentDateForCustomer(GetLastPaymentForCustomerDto sortingPagingInfo)
        {
            BaseReturnType<GetLastPaymentForCustomerReturnType> response = new BaseReturnType<GetLastPaymentForCustomerReturnType>();
            try
            {
                BusinessResponse<GetLastPaymentForCustomerReturnType> businessResponse = serviceFactory.PaymentService.GetLastPaymentDateForCustomer(sortingPagingInfo);
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

        /*public ActionResult GetPaymentDueDetail(GetScheduledTransactionDetailDto getScheduledTransactionDetailDto)
        {
            BaseReturnType<GetPaymentDueDetailReturnType> response = new BaseReturnType<GetPaymentDueDetailReturnType>();
            try
            {
                BusinessResponse<GetPaymentDueDetailReturnType> businessResponse = new BusinessResponse<GetPaymentDueDetailReturnType>();
                businessResponse = serviceFactory.PaymentDueService.GetPaymentDueDetail(getScheduledTransactionDetailDto);
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

    }
}