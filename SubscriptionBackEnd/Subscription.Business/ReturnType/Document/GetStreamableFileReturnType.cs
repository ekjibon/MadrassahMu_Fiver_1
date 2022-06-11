using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetStreamableFileReturnType
    {
        public string Filename { get; set; }
        public string ServerFilePath { get; set; }
        public string ContentType { get; set; }
    }
}
