using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Report
{
    public interface IReportGenerator<T>  
    {
        string GenerateReport(T reportParameter);
    }
}
