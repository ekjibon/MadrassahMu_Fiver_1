using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class UserRegistrationDto
    {
        public User User { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string AdminPassword { get; set; }
        public long IdRole { get; set; }
    }
}
