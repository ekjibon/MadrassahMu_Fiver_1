using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Model
{
    public class ExcelTemplateWorksheet
    {
        public int WorksheetNumber { get; set; }
        public List<ExcelTemplateData> ExcelTemplateDatas { get; set; }
    }

    public class ExcelTemplateData
    {
        public string Cell { get; set; }
        public Object Value { get; set; }
    }
}
