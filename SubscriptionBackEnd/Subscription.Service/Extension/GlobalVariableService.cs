using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using CoreWeb.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Identity;
using Subscription.Business;
using System.Configuration;
using Subscription.Business.Common;
using Subscription.Business.Enums;
using System.Security.Claims;
using System.Web;

namespace Subscription.Service
{
    public class GlobalVariableService : AbstractGlobalVariables<GlobalVariableService>
    {
        private Microsoft.Owin.IOwinContext owinContext;

        private GlobalVariableService(ISessionStorage sessionStorage, Microsoft.Owin.IOwinContext owinContext)
            : base(sessionStorage)
        {
            this.SessionStorage = sessionStorage;
            this.owinContext = owinContext;
        }

        public static bool IsInstanceInitialized()
        {
            return instance != null;
        }

        public static GlobalVariableService GetInstance(ISessionStorage sessionStorage, Microsoft.Owin.IOwinContext owinContext)
        {
            if (instance == null)
                instance = new GlobalVariableService(sessionStorage, owinContext);
            return instance;
        }

        public Business.Identity.User UserLogged
        {
            get
            {
                return SessionStorage[SessionStorageItem.UserLogged] == null ? null : (Business.Identity.User)SessionStorage[SessionStorageItem.UserLogged];
            }
            set
            {
                SessionStorage[SessionStorageItem.UserLogged] = value;
            }
        }
        public Business.User UserLoggedWithDetail
        {
            get
            {
                return SessionStorage[SessionStorageItem.UserLoggedWithDetail] == null ? null : (Business.User)SessionStorage[SessionStorageItem.UserLoggedWithDetail];
            }
            set
            {
                SessionStorage[SessionStorageItem.UserLoggedWithDetail] = value;
            }
        }
        public List<Business.Role> RolesForUserLogged
        {
            get
            {
                return SessionStorage[SessionStorageItem.RolesForUserLogged] == null ? null : (List<Business.Role>)SessionStorage[SessionStorageItem.RolesForUserLogged];
            }
            set
            {
                SessionStorage[SessionStorageItem.RolesForUserLogged] = value;
            }
        }

        public string PasswordUnlockCode
        {
            get
            {
                return SessionStorage[SessionStorageItem.PasswordUnlockCode] == null ? null : (string)SessionStorage[SessionStorageItem.PasswordUnlockCode];
            }
            set
            {
                SessionStorage[SessionStorageItem.PasswordUnlockCode] = value;
            }
        }

        public string ResetToken
        {
            get
            {
                return SessionStorage[SessionStorageItem.ResetToken] == null ? null : (string)SessionStorage[SessionStorageItem.ResetToken];
            }
            set
            {
                SessionStorage[SessionStorageItem.ResetToken] = value;
            }
        }

        public List<CombinedPermission> CombinedPermission
        {
            get
            {
                return SessionStorage[SessionStorageItem.UserPermissionCodes] == null ? null : (List<CombinedPermission>)SessionStorage[SessionStorageItem.UserPermissionCodes];
            }
            set
            {
                SessionStorage[SessionStorageItem.UserPermissionCodes] = value;
            }
        }

        public bool ShouldSignInAfterRegistration
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings.Get(SessionStorageItem.ShouldSignInAfterRegistration));
            }
            set
            {
                SessionStorage[SessionStorageItem.ShouldSignInAfterRegistration] = value;
            }
        }

        public Nullable<long> IdHostedDomain
        {
            get
            {
                if (SessionStorage[SessionStorageItem.IdHostedDomain] != null)
                {
                    return (long)SessionStorage[SessionStorageItem.IdHostedDomain];
                }
                return null;
            }
            set
            {
                SessionStorage[SessionStorageItem.IdHostedDomain] = value;
            }
        }

        public AreaEnum Area
        {
            get
            {
                return SessionStorage[SessionStorageItem.AreaEnum] == null ? AreaEnum.GENERAL : (AreaEnum)SessionStorage[SessionStorageItem.AreaEnum];
            }
            set
            {
                SessionStorage[SessionStorageItem.AreaEnum] = value;
            }
        }

        public String SignalRUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["SignalRUrl"].ToString();
            }
        }
        public String ApplicationName
        {
            get
            {
                return ConfigurationManager.AppSettings["ApplicationName"].ToString();
            }
        }
        public String CDNUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["CDNUrl"].ToString();
            }
        }
    }
}
