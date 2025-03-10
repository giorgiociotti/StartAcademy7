using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    internal static class Start
    {
        #region Private Variables
        #endregion

        #region Public Methods
        internal static void ShowMenu()
        {
            string? menuDescription = "Benvenuto nel menu principale!";
            Console.WriteLine("Inizio academy!");
            Console.Write("Inserire nominativo: ");
            string? msg = Console.ReadLine();

            if (msg != null && msg.Length>0)
            {
                WriteMenu(menuDescription, msg);
            }
            else
            {
                Console.WriteLine("Nominativo non inserito");
            }


        }
        #endregion

        #region Private Methods
        /// <summary>
        /// It write the main menu on console
        /// </summary>
        /// <param name="menuDescription"></param>
        /// <param name="msg"></param>
        static void WriteMenu(string menuDescription, string msg)//Senza specificare sarà private
        {
            Console.WriteLine($"Benvenuto, caro: {msg.ToUpper()}");
            Console.Clear();
            Console.WriteLine(new string('-', menuDescription.Length - 1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(menuDescription);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', menuDescription.Length - 1));
            Console.WriteLine();
            Console.ReadLine();
        }
        #endregion
    }
}
