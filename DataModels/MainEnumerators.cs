using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{
    public class MainEnumerators
    {
        internal enum MenuItems
        {
            DemoIterations=1,
            DemoArrayList=2,
            EnumsTest,
            EmployeesHandler=8,
            ExitProgram=9
        }

        internal enum CarEngine
        {
            Fuel= 1,
            Hybrid,
            Diesel,
            FullHybrid,
            Plugin
        }
        public enum GenderType
        {
            Male = 1,
            Female = 2,
            Other = 3
        }
    }
}
