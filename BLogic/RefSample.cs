using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    internal static class RefSample
    {
        internal static void SquareNumber(int age)
        {
            int myNumber = age;


            Console.WriteLine($"Valore iniziale: {myNumber}");
            SquareNumber2(myNumber);
            Console.WriteLine($"Valore di myNumber dopo chiamata a SquareNumber2: {myNumber}");
            SquareNumber3(ref myNumber);
            Console.WriteLine($"Valore di myNumber dopo chiamata a SquareNumber3: {myNumber}");
        }

        static int SquareNumber2(int x)
        {
            Console.WriteLine($"Il quadrato di {x}, nel metodo SquareNumber2, vale: {x *= x}");
            return x*= x;
        }

        static void SquareNumber3(ref int x)
        {
            Console.WriteLine($"Il quadrato di {x}, nel metodo SquareNumber3, vale: {x *= x}");
        }

        internal static string TrasformaInMaiuscolo(this string textValue) =>  textValue.ToUpper();
        internal static string PrimaLetteraMaiuscola(this string textValue) => 
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase( textValue );
    }
}
