using StartAcademy7.BLogic;

namespace StartAcademy7
{
    //internal significa che viene condiviso solo all'interno dello stesso progetto
    //start application class
    internal class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Start.ShowMenu();
        }
    }
}