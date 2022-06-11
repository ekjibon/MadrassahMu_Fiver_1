using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Subscription.Business;
using Subscription.Business.Enums;

namespace Subscription.Ui.Mvc
{
    public class WildcardRoute : Route
    {
        public WildcardRoute(string domain, string url, RouteValueDictionary defaults)
            : this(domain, url, defaults, new MvcRouteHandler())
        {
        }

        public WildcardRoute(string domain, string url, object defaults)
            : this(domain, url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
        }

        public WildcardRoute(string domain, string url, object defaults, IRouteHandler routeHandler)
            : this(domain, url, new RouteValueDictionary(defaults), routeHandler)
        {
        }

        public WildcardRoute(string domain, string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
            this.Domain = domain;
        }

        public WildcardRoute(string domain, string url, object defaults, object dataTokens)
            : this(domain, url, new RouteValueDictionary(defaults), new RouteValueDictionary(dataTokens), new MvcRouteHandler())
        {
        }

        public WildcardRoute(string domain, string url, RouteValueDictionary defaults, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
        : base(url, defaults, new RouteValueDictionary(), dataTokens, routeHandler)
        {
            this.Domain = domain;
        }

        public string Domain { get; set; }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            // Redirect routes never generate an URL.
            return null;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);
            Uri uri = httpContext.Request.Url;
            string subdomainWithHost = uri.GetSubDomain();
            object controller = null;
            object area = null;
            object action = null;

            if (routeData != null)
            {
                controller = routeData.Values.Where(d => d.Key == "controller").FirstOrDefault().Value;
                action = routeData.Values.Where(d => d.Key == "action").FirstOrDefault().Value;
                area = routeData.Values.Where(d => d.Key == "area").FirstOrDefault().Value;
            }

            if (routeData != null && subdomainWithHost == null)
            {
                bool isAreaInitialized = routeData.Values.Where(d => d.Key == "area").Count() > 0;

                if (isAreaInitialized)
                {
                    area = routeData.Values.Where(d => d.Key == "area").FirstOrDefault().Value;
                    routeData.DataTokens.Remove("area");
                    routeData.DataTokens.Add("area", area);
                }
            }

            if (routeData != null && subdomainWithHost != null)
            {
                //routeData.Values.Add("client", subdomainWithHost.Split('.').First());

                //BusinessResponse<HostedDomain> hostedDomainResponse = new Service.HostedDomainService().GetHostedDomainFromFullUrl(subdomainWithHost);
                //routeData.DataTokens.Remove("area");
                //routeData.Values.Remove("controller");
                //routeData.Values.Remove("action");

                //if (hostedDomainResponse.HasException())
                //{
                //    routeData.DataTokens.Add("area", "Public");
                //    routeData.Values.Add("controller", "Error");
                //    routeData.Values.Add("action", "Index");
                //    routeData.Values["ErrorMessage"] = hostedDomainResponse.Exception.Message;
                //}
   
                //else if (hostedDomainResponse.Result == null && controller != null && action != null && area != null)
                //{
                //    routeData.DataTokens.Add("area", area);
                //    routeData.Values.Add("controller", controller);
                //    routeData.Values.Add("action", action);
                //}

                //else if (hostedDomainResponse.Result == null)
                //{
                //    routeData.DataTokens.Add("area", "Public");
                //    routeData.Values.Add("controller", "Error");
                //    routeData.Values.Add("action", "ProfileNotFound");
                //}
                //else if (hostedDomainResponse.Result.IdHostedDomainType == (long)HostedDomainTypeEnum.PERSON)
                //{
                //    routeData.DataTokens.Add("area", "Profile");
                //    routeData.Values.Add("controller", "ProfilePublic");
                //    routeData.Values.Add("action", "Index");
                //    routeData.Values.Add("idHostedDomain", hostedDomainResponse.Result.IdHostedDomain);
                //}
                //else if (hostedDomainResponse.Result.IdHostedDomainType == (long)HostedDomainTypeEnum.COMPANY)
                //{
                //    routeData.DataTokens.Add("area", "Company");
                //    routeData.Values.Add("controller", "CompanyPublic");
                //    routeData.Values.Add("action", "Index");
                //    routeData.Values.Add("idHostedDomain", hostedDomainResponse.Result.IdHostedDomain);
                //}
       
            }

            return routeData;
        }
    }
}