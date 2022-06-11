using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class AdministrationCustomerScreenConstantReturnType
    {
        public List<CustomerType> CustomerTypes { get; set; }
        public List<Country> Countries { get; set; }
        public List<Title> Titles { get; set; }
        public List<ContactType> ContactTypes { get; set; }
    }
}
