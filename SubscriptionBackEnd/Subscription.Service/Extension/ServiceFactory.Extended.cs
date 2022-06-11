using Subscription.Service;
using Subscription.Service.Authentication;
using CoreWeb.Business.Common;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Web;

namespace Subscription.Service
{
    public partial class ServiceFactory : IServiceFactory
    {
        private ISessionStorage sessionStorage;
        private IOwinContext owinContext;

        public static OAuthAuthorizationServerOptions OAuthOptions;
        public static ApplicationSignInManager SignInManager;
        public static ApplicationUserManager UserManager;
        public static IAuthenticationManager AuthenticationManager;
        private ServiceFactory()
        {

        }
        private static ServiceFactory instance;
        public static ServiceFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceFactory();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public static void SetSessionStorage(ISessionStorage sessionStorage)
        {
            Instance.sessionStorage = sessionStorage;
        }
        public static void SetOwinContext(IOwinContext owinContext)
        {
            Instance.owinContext = owinContext;

        }
        public GlobalVariableService GlobalVariableService
        {
            get
            {
                return GlobalVariableService.GetInstance(sessionStorage, owinContext);
            }
        }

        public AuthenticationService AuthenticationService { get { return new AuthenticationService(); } }
        public PasswordGenerationService PasswordGenerationService { get { return new PasswordGenerationService(); } }
        public FileService FileService { get { return new FileService(); } }
        public GenericWebConnectionService GenericWebConnectionService { get { return new GenericWebConnectionService(); } }
        public SignalRService SignalRService { get { return new SignalRService(); } }
        public PdfService PdfService { get { return new PdfService(); } }
        public BankReconciliationService BankReconciliationService { get { return new BankReconciliationService(); } }
        public ZipFileService ZipFileService { get { return new ZipFileService(); } }
    }
}


