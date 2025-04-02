using StartAcademy7.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    public static class LogTrace
    {
        public static void WriteLog(Exception Ex)
        {
			LogData logData;
			string logPath = Path.Combine(Environment.CurrentDirectory, "LogApplication");

			try
			{
				var traceObj = new StackTrace(Ex);
				var myFrame= traceObj.GetFrame(traceObj.FrameCount-1).GetMethod();
				string partialFileName = DateTime.Now.ToShortDateString().Replace('/', '_');

                if (!Directory.Exists(logPath))
				{
					Directory.CreateDirectory(logPath);
				}

                logData = new LogData
				{
					Id=1,
					ExceptionDate=DateTime.Now, 
					ExceptionMessage= Ex.Message,
					SourceCodeException= myFrame.Name + " - " + myFrame.DeclaringType.Name
                };

				switch(ConfigurationManager.AppSettings["LogFileType"].ToUpper())
				{
					case "JSON":
						break;
					case "XML":
						break;
					case "TXT":
                        File.AppendAllText(Path.Combine(
							logPath,$"LogTrace_" +
							$"{DateTime.Now.ToShortDateString().Replace('/', '_')}.txt"), 
							logData.LogValues().ToString());
                        break;
				}

            }
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
