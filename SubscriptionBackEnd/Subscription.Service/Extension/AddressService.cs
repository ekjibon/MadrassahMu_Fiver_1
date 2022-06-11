using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;

namespace Subscription.Service
{
    public partial class AddressService : BaseService
    {
        internal string FormatAddressForView(Address address, string joinCharacter = ",")
        {
            List<string> completeAddress = new List<string>();
            if (address.AddressLine1 != null)
            {
                completeAddress.Add(address.AddressLine1);
            }
            if (address.AddressLine2 != null)
            {
                completeAddress.Add(address.AddressLine2);
            }
            if (address.AddressLine3 != null)
            {
                completeAddress.Add(address.AddressLine3);
            }
            if (address.AddressLine4 != null)
            {
                completeAddress.Add(address.AddressLine4);
            }
            if (address.City != null)
            {
                completeAddress.Add(address.City);
            }
            //if (address.Country != null)
            //{
            //    completeAddress.Add(address.Country.Description);
            //}
            return String.Join(joinCharacter, completeAddress.ToArray());
        }
    }
}
