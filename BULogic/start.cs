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

            try
            {
                string? msg = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    Console.Clear();
                    WriteMenu(menuDescription, msg);
                }
                else
                {
                    Console.WriteLine("⚠ Nominativo non inserito. Riprova.");
                }
            }
            catch (IOException ioException)
            {
                Console.WriteLine($"❌ Errore di input/output: {ioException.Message}");
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
