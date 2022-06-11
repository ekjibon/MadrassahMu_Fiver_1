using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Subscription.Business.Enums;

namespace Subscription.Business.Dto
{
    public class AuthenticateUserDto
    {
        [StringLength(60)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Uid { get; set; }
        public AuthenticationTypeEnum Provider { get; set; }
        public string ImageUrl { get; set; }
    }
}
