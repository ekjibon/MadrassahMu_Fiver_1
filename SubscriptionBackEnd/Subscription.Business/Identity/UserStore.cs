using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Identity
{
    public class UserStore :
    UserStore<User, Role, long, User_Login, User_Role, User_Claim>
    {
        public UserStore(DbContext dbContext) : base(dbContext) { }

    }
}
