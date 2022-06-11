using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class CombinePdfFileListDto
    {
        public List<string> FilePaths { get; set; }
        public string OutputFilePath { get; set; }
    }
}
