using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.BusinessObject
{
    public partial class OnlineOrder
    {
        public long IdOrder { get; set; }
        public DateTime? OrderDate { get; set; }
        public long? IdOrderConcept { get; set; }
        public long? IdUserAuthor { get; set; }
        public string OrderNumber { get; set; }
        public long? IdOrderSource { get; set; }
        public long? IdOrderState { get; set; }
        public double? TotalAmount { get; set; }

        public long? IdOrderCompany { get; set; }
        public long? IdOrderPerson { get; set; }
        public string Name { get; set; }
        public List<OnlineOrderProduct> Products { get; set; }
    }

    public class OnlineOrderProduct
    {
        public long IdProduct { get; set; }
        public double? Quantity { get; set; }
        public double? Rate { get; set; }
        public string ProductName { get; set; }
        public long IdOrderDetail { get; set; }
        public long? IdOrder { get; set; }
    }
}