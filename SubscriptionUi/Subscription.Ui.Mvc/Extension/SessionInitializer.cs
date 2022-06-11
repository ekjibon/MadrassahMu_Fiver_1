using System;
using System.Diagnostics;
using System.Web.Mvc;

using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Subscription.Service;
using Subscription.Service.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Subscription.Business;
using System.Configuration;
using Subscription.Business.Common;

namespace Subscription.Ui.Mvc
{
    public class SessionInitializer : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication httpApplication)
        {
            httpApplication.BeginRequest += new EventHandler(OnBeginRequest);
            httpApplication.PreRequestHandlerExecute += PreRequestHandlerExecute;
        }

        public void PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //var context = ((HttpApplication)sender).Context;

            //if (ServiceFactory.Instance.GlobalVariableService.UserLogged == null)
            //{
                //    string token = null;
                //    List<Claim> claims = ClaimsPrincipal.Current.Claims.ToList();

                //    if (HttpContext.Current.Request.Headers["Authorization"] != null)
                //    {
                //        token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                //    }
                //    else if (HttpContext.Current.Request.Headers["Token"] != null)
                //    {
                //        token = HttpContext.Current.Request.Headers["Token"].ToString();
                //    }

                //    if (token != null)
                //    {
                //        var accessToken = Startup.OAuthOptions.AccessTokenFormat.Unprotect(token);
                //        if (accessToken.Identity.IsAuthenticated)
                //        {
                //            claims = accessToken.Identity.Claims.ToList();
                //        }
                //    }

                //    try
                //    {
                //        bool areAuthenticationClaimsAvailable = claims.Where(p => p.Type == ClaimsItem.Bundle).FirstOrDefault() != null;

                //        if (areAuthenticationClaimsAvailable)
                //        {
                //            ClaimsItem claimsItem = JsonConvert.DeserializeObject<ClaimsItem>(claims.Where(p => p.Type == ClaimsItem.Bundle).First().Value);
                //            ServiceFactory.Instance.GlobalVariableService.LoginProvider = claimsItem.LoginProvider;
                //            ServiceFactory.Instance.GlobalVariableService.UserLogged = claimsItem.UserLogged;
                //            ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail = claimsItem.UserLoggedWithDetail;
                //            ServiceFactory.Instance.GlobalVariableService.RolesForUserLogged = claimsItem.RolesForUserLogged;
                //            ServiceFactory.Instance.GlobalVariableService.CombinedPermission = claimsItem.CombinedPermission; ;
                //        }
                //    }
                //    catch (Exception exception)
                //    {
                //    }
            //}
        }
        public void OnBeginRequest(Object sender, EventArgs e)
        {

        }
    }
}