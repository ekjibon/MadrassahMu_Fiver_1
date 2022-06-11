using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Identity
{
    public class User : IdentityUser<long, User_Login, User_Role, User_Claim>
    {
        public bool NeedPasswordChange { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long? IdPerson { get; set; }
    }
}
