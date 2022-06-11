using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class OAuthAuthenticateUserReturnType : AuthenticateUserReturnType
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
