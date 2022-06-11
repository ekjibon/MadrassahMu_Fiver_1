using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class LoadListByNameAndAddressReturnType
    {
        public string FullName { get; set; }
        public string FullAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string City { get; set; }
        public long IdCustomer { get; set; }
        public Address Address { get; set; }
        public Customer Customer { get; set; }
    }
}
