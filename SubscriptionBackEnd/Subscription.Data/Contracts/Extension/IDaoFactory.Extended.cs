using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data
{
    public partial interface IDaoFactory
    {
        IBankReconciliationDao BankReconciliationDao { get; }
    }
}
