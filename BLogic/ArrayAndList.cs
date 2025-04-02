using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    internal class ArrayAndList
    {
        private int[] numbersArray = new int[10];
        private float[] numbersArrayValues = { 10, 20, 45, 940, 729, 2 };
        private string[] stringsArray = new string[5];
        private string[] stringsArrayValues = { "UNO", "DUE", "TRE" };

        private List<int> numbersList = [];
        
        internal ArrayAndList() {

            numbersArray[0] = 1;

            for (int i = 1; i < numbersArray.Length; i++)
            {
                numbersArray[i] = i+1;
            }

            for (int j=0; j< 5;j++)
            {
                stringsArray[j] = $"Stringa: {j.ToString()}";
            }

            for(int k=0;k <=100; k+=10)
            {
                numbersList.Add(k);
            }
        }

        internal void PrintArrays()
        {
            Console.WriteLine("STAMPA ARRAYS NUMERI CARICATI CON CICLO FOR");
           
            foreach(int i in numbersArray)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("STAMPA ARRAYS Stringhe CARICATI CON CICLO FOR");
            foreach (var item in stringsArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("STAMPA ARRAYS NUMERI INIZIALIZZATI MANUALMENTE (numbersArrayValues)");
            // Stampare i numeri divisibile per 5
            // stampare anche il risultato

            for (int i = 0;i < numbersArrayValues.Length; i++)
            {
                if (numbersArrayValues[i] % 5 == 0)
                {
                    Console.WriteLine($"Numero: {numbersArrayValues[i]} - Risultato: {numbersArrayValues[i]/5}");
                }
            }

            float numbersSum = 0;

            foreach(float item in numbersArrayValues)
            {
                numbersSum += item;
            }

            float numbersAverage =numbersSum / numbersArrayValues.Length;
            Console.WriteLine($"Media della collezione numbersArrayValues: {numbersAverage}");
        }

        internal void PrintListValues()
        {
            Console.WriteLine($"La somma de numeri in numbersArrayValues, vale: {numbersArrayValues.Sum()}");
            Console.WriteLine($"La media dei numeri in numbersArrayValues, vale: {numbersArrayValues.Average()}");

            List<int> numbersDividedByten = numbersList.FindAll(n => (n % 10 == 0) || n == 100);
            //numbersList.FindAll(n => (n % 10 == 0) || n == 100).ForEach(n => Console.WriteLine(n));
            numbersDividedByten.ForEach(n => Console.WriteLine($"Valori divisibili per 10: {n}"));
        }

        internal void StringManipulation()
        {
            string lordOfRing = "Il signore degli anelli";
            Console.WriteLine(lordOfRing.Contains("ANELLi", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(lordOfRing.IndexOf("degli"));
            Console.WriteLine(lordOfRing.Substring(lordOfRing.IndexOf("Il ")+3));

            string[] ringsWords = lordOfRing.Split(' ');
        }
       
    }
}
