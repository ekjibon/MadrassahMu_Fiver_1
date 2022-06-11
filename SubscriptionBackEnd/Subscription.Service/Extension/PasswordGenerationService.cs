using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Subscription.Service
{
    public class PasswordGenerationService : BaseService
    {
        public string GenerateNewPassword()
        {
            return Membership.GeneratePassword(7, 1);
        }
    }
}
