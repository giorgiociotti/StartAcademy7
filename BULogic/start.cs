using StartAcademy7.BLogic;
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
                    menu();  // Aggiunto per chiamare il menu dopo aver visualizzato la descrizione
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

        static void menu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Scegli un'opzione:");
                Console.WriteLine("A - test iterazioni");
                Console.WriteLine("X - uscita");
                Console.Write("Scelta: ");

                string input = Console.ReadLine().ToUpper();
                Console.Clear();


                switch (input)
                {
                    case "A":
                        Console.Clear();
                        DemoIterations();
                        break;
                    
                    case "B":
                        Console.Clear();
                        DemoArrayAndList();
                        break;

                    case "X":
                        running = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta non valida, inserisci A per i test delle iterazioni o X per uscire.");
                        break;
                }
            }
        }

        static void DemoIterations()
        {
            Console.WriteLine("Esecuzione Metodi classe Iterations");

            string[] strings = ["cavallo", "cane", "gatto"];

            Iterations iterations = new(10, strings);

            Console.WriteLine("Esecuzione ForEachIteration");
            iterations.ForEachIteration();
            Console.WriteLine("-------------------------------------------------------");
            
            Console.WriteLine("Esecuzione ForIteration");
            iterations.ForIteration();
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Esecuzione WhileDoIteration");
            iterations.WhileDoIteration();
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Esecuzione DoWhileIteration");
            iterations.DoWhileIteration();
            Console.Clear();

        }
        #endregion
    }
}
