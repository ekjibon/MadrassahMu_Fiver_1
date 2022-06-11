using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Common
{
    public class FileToZipInfo
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileNameWithExtension { get; set; }
        public string FilePath { get; set; }
        public string ZipFileName { get; set; }
    }
}
