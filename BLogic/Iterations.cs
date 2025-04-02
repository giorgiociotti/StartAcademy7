namespace StartAcademy7.BLogic
{
    public class Iterations
    {
        int loopNumber = 0;
        string[]? stringsName;
        bool isOK = true;

        public Iterations(int LoopNumber) 
        { 
            loopNumber = LoopNumber;
        }

        public Iterations(int LoopNumber, string[] StringsName)
        { 
            loopNumber = LoopNumber;
            stringsName = new string[StringsName.Length];
            stringsName = StringsName;
        }

        public Iterations()
        {
        }

        public void ForIteration()
        {
            for (int i = 0; i < loopNumber; i++)
            { 
                Console.WriteLine($"Valore ciclo for (i): {i}"); 
            }

            for (int i = 0; i < stringsName.Length; i++)
            {
                Console.WriteLine($"Valore ciclo for (i): {stringsName[i]}");
            }
        }

        public void ForEachIteration()
        {
            foreach(string name in stringsName)
            {
                Console.WriteLine($"Valore array stringhe: {name}");
            }
        }

        public void WhileDoIteration()
        {
            string inputText = string.Empty;
            while (isOK)
            {
                Console.Write($"scrivi qualcosa (fine per uscire dal while)");
                inputText = Console.ReadLine();
                isOK = inputText.ToLower() != "fine"? true : false;
            } 
        }

        public void DoWhileIteration()
        {
            string inputText = string.Empty;
            do
            {
                Console.Write($"scrivi qualcosa (fine per uscire dal DO while)");
                inputText = Console.ReadLine();
                isOK = inputText.ToLower() != "fine" ? true : false;
            } while (isOK);
        }
    }
}
