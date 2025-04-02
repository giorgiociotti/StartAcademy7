using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{
    public class MainEnumerators
    {
        public enum MenuItems
        {
            DemoIterations=1,
            DemoArrayList=2,
            EnumsTest,
            EmployeesHandler=8,
            ExitProgram
        }

        public enum CarEngine
        {
            Fuel= 1,
            Hybrid,
            Diesel,
            FullHybrid, 
            Plugin,
            Electric
        }

        public enum Gender
        {
            None,
            Female,
            Male,
            Transgender
        }
    }
}
