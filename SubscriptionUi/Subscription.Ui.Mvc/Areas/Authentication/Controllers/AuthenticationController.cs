using CoreWeb.Business.Common;
using CoreWeb.Ui.Common.Mvc;
using Subscription.Business;
using Subscription.Business.Dto;
using Subscription.Business.Dto.Security;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Business.ReturnType.Security;
using Subscription.Service;
using Subscription.Ui.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Subscription.Ui.Mvc.Areas.Authentication.Controllers
{
    public class AuthenticationController : BaseController
    {
        public ActionResult Logout()
        {
            BaseReturnType<bool> response = new BaseReturnType<bool>();
            try
            {
                serviceFactory.AuthenticationService.LogOff(SignInManager);

                response.Status = RequestStatusEnum.SUCCESS;
                response.Result = true;
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500);
            }
            return new JsonCamelCaseResult(response, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Authentication()
        {
            ViewData["token"] = Request.QueryString["token"];
            ViewData["action"] = Request.QueryString["action"];
            if (ViewData["token"] == null && ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail != null)
            {
                return RedirectToAction("TransactionSaleListing", "Transaction", new { area = "Transaction" });
            }
            return View();
        }

        public ActionResult GetLoggedUser()
        {
            BaseReturnType<UserWithoutConfidentialInfo> response = new BaseReturnType<UserWithoutConfidentialInfo>();

            try
            {
                BusinessResponse<UserWithoutConfidentialInfo> businessResponse = serviceFactory.AuthenticationService.GetLoggedUser();

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

        public async Task<ActionResult> LoginWithCredential(AuthenticateUserDto authenticateUserDto)
        {
            BaseReturnType<OAuthAuthenticateUserReturnType> response = new BaseReturnType<OAuthAuthenticateUserReturnType>();

            try
            {
                BusinessResponse<OAuthAuthenticateUserReturnType> businessResponse = await LoginWithCredentialRaw(authenticateUserDto);

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

        private async Task<BusinessResponse<OAuthAuthenticateUserReturnType>> LoginWithCredentialRaw(AuthenticateUserDto authenticateUserDto)
        {
            return await serviceFactory.AuthenticationService.LoginWithCredential(authenticateUserDto);
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult> LoginOAuthJson(AuthenticateUserDto authenticateUserDto)
        {
            BaseReturnType<OAuthAuthenticateUserReturnType> response = new BaseReturnType<OAuthAuthenticateUserReturnType>();

            try
            {
                BusinessResponse<OAuthAuthenticateUserReturnType> businessResponse = await LoginOAuth(authenticateUserDto);

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

        private async Task<BusinessResponse<OAuthAuthenticateUserReturnType>> LoginOAuth(AuthenticateUserDto authenticateUserDto)
        {
            return await serviceFactory.AuthenticationService.AuthenticateUserOAuth(authenticateUserDto);
        }

        public async Task<ActionResult> RegisterWithCredential(AuthenticateUserDto authenticateUserDto)
        {
            BaseReturnType<OAuthAuthenticateUserReturnType> response = new BaseReturnType<OAuthAuthenticateUserReturnType>();
            try
            {

                BusinessResponse<OAuthAuthenticateUserReturnType> businessResponse = await serviceFactory.AuthenticationService.RegisterUser(authenticateUserDto, new Person() { Firstname = authenticateUserDto.Firstname, Lastname = authenticateUserDto.Lastname });

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

        public async Task<ActionResult> RegisterWithCredentialOAuth(AuthenticateUserDto authenticateUserDto)
        {
            BaseReturnType<OAuthAuthenticateUserReturnType> response = new BaseReturnType<OAuthAuthenticateUserReturnType>();
            try
            {

                BusinessResponse<OAuthAuthenticateUserReturnType> businessResponse = await serviceFactory.AuthenticationService.RegisterUser(authenticateUserDto, new Person() { Firstname = authenticateUserDto.Firstname, Lastname = authenticateUserDto.Lastname }, true);

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

        public async Task<ActionResult> RegisterOrLoginWithSocial(AuthenticateUserDto authenticateUserDto)
        {
            BaseReturnType<OAuthAuthenticateUserReturnType> response = new BaseReturnType<OAuthAuthenticateUserReturnType>();

            try
            {
                BusinessResponse<OAuthAuthenticateUserReturnType> businessResponse = await serviceFactory.AuthenticationService.RegisterOrLoginWithSocial(authenticateUserDto);

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

        public async Task<ActionResult> RegisterOrLoginWithSocialOAuth(AuthenticateUserDto authenticateUserDto)
        {
            BaseReturnType<OAuthAuthenticateUserReturnType> response = new BaseReturnType<OAuthAuthenticateUserReturnType>();

            try
            {
                BusinessResponse<OAuthAuthenticateUserReturnType> businessResponse = await serviceFactory.AuthenticationService.RegisterOrLoginWithSocial(authenticateUserDto, true);

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


        public ActionResult ForgotPassword(AuthenticateUserDto authenticateUserDto)
        {
            BaseReturnType<ForgotPasswordReturnType> response = new BaseReturnType<ForgotPasswordReturnType>();

            try
            {
                BusinessResponse<ForgotPasswordReturnType> businessResponse = serviceFactory.AuthenticationService.ForgotPassword(SignInManager, UserManager, authenticateUserDto.Email);

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



        public async Task<ActionResult> ResetPasswordExternal(ResetPasswordExternalDto resetPasswordExternalDto)
        {
            BaseReturnType<ForgotPasswordReturnType> response = new BaseReturnType<ForgotPasswordReturnType>();

            try
            {
                BusinessResponse<ForgotPasswordReturnType> businessResponse = await ResetPasswordExternalRaw(resetPasswordExternalDto);

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

        public async Task<BusinessResponse<ForgotPasswordReturnType>> ResetPasswordExternalRaw(ResetPasswordExternalDto resetPasswordExternalDto)
        {
            return await serviceFactory.AuthenticationService.ResetPasswordExternal(SignInManager, resetPasswordExternalDto);
        }

        public ActionResult LinkedInCallback()
        {
            return View();
        }

        /*[HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult> GetLinkedInUserDetailFromCode(GetLinkedInUserDetailFromCodeDto getLinkedInUserDetailFromCodeDto)
        {
            BaseReturnType<GetLinkedInUserDetailFromCodeReturnType> response = new BaseReturnType<GetLinkedInUserDetailFromCodeReturnType>();

            try
            {
                BusinessResponse<GetLinkedInUserDetailFromCodeReturnType> businessResponse = await GetLinkedInUserDetailFromCodeRaw(getLinkedInUserDetailFromCodeDto);

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
        private async Task<BusinessResponse<GetLinkedInUserDetailFromCodeReturnType>> GetLinkedInUserDetailFromCodeRaw(GetLinkedInUserDetailFromCodeDto getLinkedInUserDetailFromCodeDto)
        {
            return await serviceFactory.AuthenticationService.GetLinkedInUserDetailFromCode(getLinkedInUserDetailFromCodeDto);
        }*/

    }
}