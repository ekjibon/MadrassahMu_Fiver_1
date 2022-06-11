using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType.Security
{
    public class GetLinkedInUserDetailFromCodeReturnType
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Uid { get; set; }
    }
}
