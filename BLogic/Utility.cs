using StartAcademy7.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    public class Utility
    {
        public void GetSetApplicationParams()
        {
            //string curDirectory = Environment.CurrentDirectory;
            //Directory.CreateDirectory();


            string? filePath = ConfigurationManager.AppSettings["FilePath"];
            string? txtFileName = ConfigurationManager.AppSettings["TxtFileName"];

            if (filePath != null && txtFileName != null)
            {
                ConfigParams.AppFilePath = filePath;
                ConfigParams.PathTxtFileName = Path.Combine(filePath, txtFileName);
            }   
            else
            {
                // Handle the case where filePath or txtFileName is null
                throw new ArgumentNullException("FilePath or TxtFileName is not set in the configuration.");
            }

            string? jsonFilePath = ConfigurationManager.AppSettings["FilePath"];
            string? JsonFileName = ConfigurationManager.AppSettings["JsonFileName"];
            string? sqlConString = ConfigurationManager.AppSettings["DbConnectionString"];
            if (sqlConString != null)
            {
                ConfigParams.SqlDbConnection = sqlConString;
            }
            else
            {
                throw new ArgumentNullException("DbConnectionString is not set in the configuration.");
            }

            if (jsonFilePath != null && JsonFileName != null)
            {
                ConfigParams.PathJsonFileName = Path.Combine(filePath, JsonFileName);
            }
            else
            {
                // Handle the case where filePath or txtFileName is null
                throw new ArgumentNullException("FilePath or TxtFileName is not set in the configuration.");
            }

            string? xmlFilePath = ConfigurationManager.AppSettings["FilePath"];
            string? xmlFileName = ConfigurationManager.AppSettings["XmlFileName"];

            if (jsonFilePath != null && xmlFileName != null)
            {
                ConfigParams.PathXmlFileName = Path.Combine(filePath, xmlFileName);
            }
            else
            {
                // Handle the case where filePath or txtFileName is null
                throw new ArgumentNullException("FilePath or TxtFileName is not set in the configuration.");
            }
        }

        public void SetConfigurationConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (ConfigurationManager.AppSettings["Newkey"] != null)
            {
                ConfigurationManager.AppSettings["Newkey"] = "NewValue";
            }
            else
            {
                config.AppSettings.Settings.Add("Newkey", "errlogOK");
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void LogTypeFileRequest()
        {
            if (ConfigurationManager.AppSettings["LogFileType"] == null)
            {
                Console.Clear();
                Console.Write("Impostare la tipologia del file di log (txt,json,xml): ");
                string logType = Console.ReadLine();
                
                if (logType != null)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Add("LogFileType", logType);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }   
            }
        }
    }
}
