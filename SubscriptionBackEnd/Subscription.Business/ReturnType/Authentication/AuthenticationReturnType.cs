using Subscription.Business.Common;
using System.Collections.Generic;

namespace Subscription.Business.ReturnType
{
    public class AuthenticationReturnType
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public string AuthKey { get; set; }
        public List<CombinedPermission> CombinePermissions { get; set; }
    }
}