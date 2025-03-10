using System;
using System.Text;

namespace StartAcademy7.BLogic
{
    internal static class Start
    {
        #region Public Methods
        internal static void ShowMenu()
        {
            
            string menuDescription = "Benvenuto nel menu principale!";

            Console.WriteLine("Inizio academy!");
            Console.Write("Inserire nominativo: ");
            string? msg = Console.ReadLine()?.Trim(); // Rimuove eventuali spazi vuoti

            if (!string.IsNullOrWhiteSpace(msg))
            {
                Console.Clear(); // Pulisce la console prima di mostrare il menu
                WriteMenu(menuDescription, msg);
            }
            else
            {
                Console.WriteLine("⚠ Nominativo non inserito. Riprova.");
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Scrive il menu principale nella console.
        /// </summary>
        /// <param name="menuDescription">Descrizione del menu</param>
        /// <param name="msg">Nome dell'utente</param>
        private static void WriteMenu(string menuDescription, string msg)
        {
            Console.WriteLine($"Benvenuto, {msg.ToUpper()}!");
            Console.WriteLine(new string('-', menuDescription.Length));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(menuDescription);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', menuDescription.Length));
            Console.WriteLine("\nPremi INVIO per continuare...");
            Console.ReadLine();
        }
        #endregion
    }
}
