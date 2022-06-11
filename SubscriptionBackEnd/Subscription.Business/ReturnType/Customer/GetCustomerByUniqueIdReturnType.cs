using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetCustomerByNidReturnType
    {
        public LoadListByNameAndAddressReturnType Customer { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public bool doesNidExists { get; set; }
    }
}
