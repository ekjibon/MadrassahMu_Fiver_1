using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;

namespace Subscription.Business.Dto
{
    public class ZipFileDto
    {
        public List<FileToZipInfo> FilesToZip { get; set; }
        public string OutputFilePath { get; set; }
    }
}
