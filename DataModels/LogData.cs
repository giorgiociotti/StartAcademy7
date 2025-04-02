using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StartAcademy7.DataModels.MainEnumerators;
using System.Xml.Linq;

namespace StartAcademy7.DataModels
{
    public class LogData
    {
        public int Id { get; set; }
        public string SourceCodeException { get; set; } = string.Empty;
        public DateTime ExceptionDate { get; set; }
        public string ExceptionMessage { get; set; } = string.Empty;
        public string LogValues() => $"{Id};{SourceCodeException};{ExceptionDate};{ExceptionMessage}\n";

    }
}
