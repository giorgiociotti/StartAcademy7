using StartAcademy7.DataModels;

namespace StartAcademy7.BLogic
{
    internal static class Start
    {
        #region Private Variables
        #endregion

        #region public methods
        internal static void ShowMenu()
        {
            string menuDescription = "Benvenuto nel menu principale";
            Console.WriteLine("INIZIA L'AVVENTURA DI ACADEMY .NET");
            Console.Write("Inserire nominativo studente: ");

            string? msg = Console.ReadLine();  //nullable

            if (msg != null)
            {
                WriteMenu(menuDescription, msg);
            }
            else
            {
                Console.WriteLine("Nominativo non inserito.");
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// it write the main menu on console
        /// </summary>
        /// <param name="menuDescription"></param>
        /// <param name="msg"></param>
        static void WriteMenu(string menuDescription, string? msg)
        {
            string? menuChoice = "";
            Console.WriteLine($"Benvenuto, caro: {msg.ToUpper()}");

            while (menuChoice != "9")
            {
                Console.Clear();
                //Console.SetCursorPosition(0, 0);

                Console.WriteLine(new string('-', menuDescription.Length + 1));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(menuDescription);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string('-', menuDescription.Length + 1));
                Console.WriteLine("1) Demo Iterazioni e cicli");
                Console.WriteLine("2) Demo Array e Liste");
                Console.WriteLine("3) Test Enumeratori");
                Console.WriteLine("8) Gestione Dipendenti");
                Console.WriteLine("9) Chiusura e Uscita Applicazione");
                Console.Write("Inserire la lettera per la funzione desiderata: ");
                    
                //menuChoice = Console.ReadLine();
                bool resultChoice = int.TryParse(Console.ReadLine(), out int mnuItem);

                if (resultChoice)   
                {
                    switch ((MainEnumerators.MenuItems)mnuItem)
                    {
                        case MainEnumerators.MenuItems.DemoIterations:
                            DemoIterations();
                            break;
                        case MainEnumerators.MenuItems.DemoArrayList:
                            DemoArrayAndList();
                            break;
                        case MainEnumerators.MenuItems.EnumsTest:
                            DemoEnums();
                            break;
                        case MainEnumerators.MenuItems.EmployeesHandler:
                            EmployeesHandler();
                            break;
                        case MainEnumerators.MenuItems.ExitProgram:
                            break;
                        default:
                            Console.WriteLine("Scelta NON valida!");
                            break;
                    }
                }
                if ((MainEnumerators.MenuItems)mnuItem != MainEnumerators.MenuItems.ExitProgram)
                {
                    Console.WriteLine("Premere un tasto, (invio), per continuare.");
                    Console.ReadLine();
                }
            }
        }

        static void DemoEnums()
        {
            EnumsTest.CarEnums();
        }
        static void DemoIterations()
        {
            Console.WriteLine("Esecuzione Metodi classe Iterations");

            string[] strings = ["cavallo", "cane", "gatto"];

            Iterations iterations = new(10, strings);

            iterations.ForEachIteration();
            iterations.ForIteration();
            iterations.WhileDoIteration();
            iterations.DoWhileIteration();
        }
        static void DemoArrayAndList()
        {
            ArrayAndList arrayAndList = new();
            arrayAndList.PrintArrays();
            arrayAndList.PrintListValues();
            arrayAndList.StringManipulation();
        }

        static void EmployeesHandler()
        {
            Employee employee = new();
        }
        #endregion
    }
}
