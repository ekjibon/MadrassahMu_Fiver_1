using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data
{
	public partial class DaoFactory : IDaoFactory
    {
		public IBankReconciliationDao BankReconciliationDao { get { return new BankReconciliationDao(UnitOfWork.Db); } }
	}
}
