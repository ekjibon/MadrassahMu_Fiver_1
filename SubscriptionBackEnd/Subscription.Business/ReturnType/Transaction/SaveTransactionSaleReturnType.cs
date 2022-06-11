using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class SaveTransactionSaleReturnType
    {
        public Transaction Transaction { get; set; }
        public List<Customer> CustomersToSync { get; set; }
        public List<Product> ProductsToSync { get; set; }
    }
}
