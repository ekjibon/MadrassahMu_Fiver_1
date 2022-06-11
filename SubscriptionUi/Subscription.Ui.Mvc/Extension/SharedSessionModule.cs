using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Not being used, removed from web.config, using http cookie
namespace Subscription.Ui.Mvc
{
    using System.Configuration;
    using System.Reflection;
    using System.Web;
    using System.Web.SessionState;

    /// <summary>class used for sharing the session between app domains</summary>
    public class SharedSessionModule : IHttpModule
    {
        protected static string applicationName = ConfigurationManager.AppSettings["ApplicationName"];
        protected static string rootDomain = ConfigurationManager.AppSettings["RootDomain"];

        #region IHttpModule Members
        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/>
        /// that provides access to the methods,
        /// properties, and events common to all application objects within an ASP.NET
        /// application</param>
        /// <created date="5/31/2008" by="Peter Femiani"/>
        public void Init(HttpApplication context)
        {
            FieldInfo runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            HttpRuntime theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
            FieldInfo appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
            appNameInfo.SetValue(theRuntime, applicationName);

            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
        }

        /// <summary>
        /// Disposes of the resources (other than memory) used by the module that
        /// implements <see cref="T:System.Web.IHttpModule"/>.
        /// </summary>
        /// <created date="5/31/2008" by="Peter Femiani"/>
        public void Dispose()
        {
        }
        #endregion

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            var context = System.Web.HttpContext.Current;
            if (context.Handler is IRequiresSessionState || context.Handler is IReadOnlySessionState)
            {
                /// Ensure ASP.NET Session Cookies are accessible throughout the subdomains.
                if (context.Response.Cookies["ASP.NET_SessionId"] != null && context.Session != null && context.Session.SessionID != null)
                {
                    context.Response.Cookies["ASP.NET_SessionId"].Value = context.Session.SessionID;
                    context.Response.Cookies["ASP.NET_SessionId"].Domain = rootDomain; // the full stop prefix denotes all sub domains
                    context.Response.Cookies["ASP.NET_SessionId"].Path = "/"; //default session cookie path root         
                }
            }
            //HttpApplication context = (HttpApplication)sender;
            //HttpCookie cookie = context.Response.Cookies["ASP.NET_SessionId"];

            //if (context.Session != null && !string.IsNullOrEmpty(context.Session.SessionID))
            //{
            //    cookie.Value = context.Session.SessionID;
            //    cookie.Domain = rootDomain;
            //    cookie.Path = "/";
            //}

        }
    }
}