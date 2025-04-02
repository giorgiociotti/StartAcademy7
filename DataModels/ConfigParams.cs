using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{   
    public static class ConfigParams        
    {
        public static string? AppFilePath { get; set; } 
        public static string? PathTxtFileName { get; set; }
        public static string? PathJsonFileName { get; set; }
        public static string? PathXmlFileName { get; set; }
        public static string? SqlDbConnection { get; set; }
    }
}
