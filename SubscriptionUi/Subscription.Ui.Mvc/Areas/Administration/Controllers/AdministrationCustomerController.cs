using CoreWeb.Business.Common;
using CoreWeb.Ui.Common.Mvc;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Service;
using Subscription.Ui.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Subscription.Ui.Mvc.Areas.Administration.Controllers
{
    public class AdministrationCustomerController : BaseController
    {
        // GET: Administration/AdministrationCustomer
        public ActionResult Index()
        {
            return View(); 
        }

        public ActionResult AdministrationCustomerListing()
        {
            return View();
        }

        public ActionResult AdministrationCustomer()
        {
            return View();
        }

        public ActionResult AdministrationNewCustomer()
        {
            return View();
        }

        public ActionResult LoadList(CustomerSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Business.Customer>> response = new BaseReturnType<BaseListReturnType<Business.Customer>>();
            try
            {
                BusinessResponse<BaseListReturnType<Business.Customer>> businessResponse = serviceFactory.CustomerService.LoadList(sortingPagingInfo);
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
        public ActionResult LoadListByNameAndAddress(CustomerSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<LoadListByNameAndAddressReturnType>> response = new BaseReturnType<BaseListReturnType<LoadListByNameAndAddressReturnType>>();
            try
            {
                BusinessResponse<BaseListReturnType<LoadListByNameAndAddressReturnType>> businessResponse = serviceFactory.CustomerService.LoadListByNameAndAddress(sortingPagingInfo);
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

        public ActionResult LoadListByName(CustomerSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Business.Customer>> response = new BaseReturnType<BaseListReturnType<Business.Customer>>();
            try
            {
                BusinessResponse<BaseListReturnType<Business.Customer>> businessResponse = serviceFactory.CustomerService.LoadListByName(sortingPagingInfo);
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

        public ActionResult GetAdministrationCustomerScreenConstant()
        {
            BaseReturnType<AdministrationCustomerScreenConstantReturnType> response = new BaseReturnType<AdministrationCustomerScreenConstantReturnType>();
            try
            {
                response.Result = new AdministrationCustomerScreenConstantReturnType();
                response.Result.CustomerTypes = serviceFactory.CustomerTypeService.GetAllCustomerTypes(true).Result;
                response.Result.Countries = serviceFactory.CountryService.GetAllCountries(true).Result;
                response.Result.Titles = serviceFactory.TitleService.GetAllTitles(true).Result;
                response.Result.ContactTypes = ServiceFactory.Instance.ContactTypeService.GetAllContactTypes(true).Result;

                response.Status = RequestStatusEnum.SUCCESS;

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500);
            }
            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetAdministrationCustomer(GetAdministrationCustomerDto getAdministrationCustomerDto)
        {
            BaseReturnType<GetAdministrationCustomerReturnType> response = new BaseReturnType<GetAdministrationCustomerReturnType>();
            try
            {
                BusinessResponse<GetAdministrationCustomerReturnType> businessResponse = serviceFactory.CustomerService.GetAdministrationCustomer(getAdministrationCustomerDto.IdCustomer);
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
        public ActionResult SaveAdministrationCustomer(SaveAdministrationCustomerDto saveAdministrationCustomerDto)
        {
            BaseReturnType<SaveAdministrationCustomerReturnType> response = new BaseReturnType<SaveAdministrationCustomerReturnType>();
            try
            {
                BusinessResponse<SaveAdministrationCustomerReturnType> businessResponse = serviceFactory.CustomerService.SaveAdministrationCustomer(saveAdministrationCustomerDto);
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

        public ActionResult DeleteCustomer(Business.Customer customer)
        {
            BaseReturnType<Business.Customer> response = new BaseReturnType<Business.Customer>();
            try
            {
                BusinessResponse<bool> businessResponse = serviceFactory.CustomerService.DeleteCustomer(customer);
                if (businessResponse.HasException())
                {
                    response.Status = RequestStatusEnum.FAILURE;
                    response.ErrorMessage = businessResponse.Exception.Message;
                    return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
                }
                response.Status = RequestStatusEnum.SUCCESS;
                response.Result = customer;
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500);
            }
            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult GetDataToSync()
        //{
        //    BaseReturnType<List<CustomerSyncReturnType>> response = new BaseReturnType<List<CustomerSyncReturnType>>();
        //    try
        //    {
        //        BusinessResponse<List<CustomerSyncReturnType>> businessResponse = serviceFactory.CustomerService.GetDataToSync();
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

        public ActionResult GetCustomerByNid(GetCustomerByUniqueIdDto getCustomerByUniqueIdDto)
        {
            BaseReturnType<GetCustomerByNidReturnType> response = new BaseReturnType<GetCustomerByNidReturnType>();
            try
            {
                BusinessResponse<GetCustomerByNidReturnType> businessResponse = serviceFactory.CustomerService.GetCustomerByUniqueId(getCustomerByUniqueIdDto);
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