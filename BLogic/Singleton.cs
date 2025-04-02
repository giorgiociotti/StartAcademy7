using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    public class Singleton
    {
        private static Singleton instance;
        private int _counter = 0;
        private Singleton() { _counter++; }
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void Msg()
        {
            Console.WriteLine($"Hello, counter: {_counter}");
        }
    }
}
