using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;

namespace Subscription.Business.ReturnType
{
    public class AuthenticateUserReturnType
    {
        public SignInStatus SignInStatus { get; set; }
        public bool NeedPasswordChange { get; set; }
        public UserWithoutConfidentialInfo UserWithoutConfidentialInfo { get; set; }
        public string CodeUrl { get; set; }
        public string CodeFileName { get; set; }
    }
}
