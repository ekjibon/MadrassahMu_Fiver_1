using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetDefaultPictureReturnType
    {
        public string ProfilePicture { get; set; }
        public string ProfileCoverPicture { get; set; }
        public string CompanyCoverPicture { get; set; }
        public string CompanyPicture { get; set; }
    }
}
