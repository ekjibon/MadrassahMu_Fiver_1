using Subscription.Business.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Subscription.Service.Authentication
{
    public class ApplicationSignInManager : SignInManager<User, long>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return ((ApplicationUserManager)UserManager).GenerateUserIdentityAsync(user);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public Task<SignInStatus> PasswordSignInAsyncWithEmail(string email, string password, bool isPersistent, bool shouldLockout)
        {
            Expression<Func<Business.User, bool>> expression = property => property.IsDeactivated != true
               && property.Email == email;

            Business.User user = ServiceFactory.Instance.UserService.GetUserCustomRaw(expression);

            if (user == null)
                throw new Exception(string.Format("User with email {0} not found", email));

            return PasswordSignInAsync(user.UserName, password, isPersistent, shouldLockout);
        }
    }
}
