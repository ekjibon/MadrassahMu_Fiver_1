using CoreWeb.Business.Common;
using CoreWeb.Ui.Common.Mvc;
using Subscription.Business.Common;
using Subscription.Business.Dto.Subscription;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Ui.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subscription.Business.Dto;

namespace Subscription.Ui.Mvc.Areas.Administration.Controllers
{
    public class AdministrationProductController : BaseController
    {
        // GET: Administration/AdministrationProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdministrationProductListing()
        {
            return View();
        }

        public ActionResult AdministrationProduct()
        {
            return View();
        }

        public ActionResult AdministrationNewProduct()
        {
            return View();
        }


        public ActionResult SaveAdministrationProduct(SaveAdministrationProductDto saveAdministrationProductDto)
        {
            BaseReturnType<SaveAdministrationProductReturnType> response = new BaseReturnType<SaveAdministrationProductReturnType>();
            try
            {
                BusinessResponse<SaveAdministrationProductReturnType> businessResponse = serviceFactory.ProductService.SaveAdministrationProduct(saveAdministrationProductDto);
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

        public ActionResult GetAdministrationProduct(GetAdministrationProductDto getAdministrationProductDto)
        {
            BaseReturnType<GetAdministrationProductReturnType> response = new BaseReturnType<GetAdministrationProductReturnType>();
            try
            {
                BusinessResponse<GetAdministrationProductReturnType> businessResponse = serviceFactory.ProductService.GetAdministrationProduct(getAdministrationProductDto.IdProduct);
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


        public ActionResult LoadList(ProductListSortingPagingInfo sortingPagingInfo)
        {
            BaseReturnType<BaseListReturnType<Business.Product>> response = new BaseReturnType<BaseListReturnType<Business.Product>>();
            try
            {
                BusinessResponse<BaseListReturnType<Business.Product>> businessResponse = serviceFactory.ProductService.LoadProductList(sortingPagingInfo);
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