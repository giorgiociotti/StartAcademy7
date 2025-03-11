using StartAcademy7.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    internal static class EnumsTest
    {
        internal static void CarEnums()
        {
            int myEngine = 2500;
            int currentEngine = 3;

            try
            {
                Console.WriteLine($"TipoMotore (inesistente): {(MainEnumerators.CarEngine)myEngine}");
                Console.WriteLine($"TipoMotore (esistente): {(MainEnumerators.CarEngine)currentEngine}");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"ATTENZIONE: Errore imprevisto: {ex.Message}\nContattare l'aministratore di Sistema.");
            }
            
        }
    }
}
