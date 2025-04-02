using StartAcademy7.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StartAcademy7.BLogic
{
    public class DictionaryAndTuple
    {
        public void UseDictonary()
        {
            Dictionary<string, string> employeeName = [];

            employeeName.Add("A001", "Martin Mystere");
            employeeName.Add("A002", "Dylan Dog");

            foreach (var employee in employeeName)
            {
                Console.WriteLine($" Chiave: {employee.Key}) - Valore: {employee.Value}");
            }

            Console.WriteLine($"Esiste la chiave A002 ?: {employeeName.ContainsKey("A002")}");
            Console.WriteLine($"Esiste il nominativo Dylan Dog ?: {employeeName.ContainsValue("Dylan Dog")}");
            employeeName.Remove("A002");
            employeeName.Add("A003", "Nathan Never");

            if (employeeName.ContainsValue("Zagor"))
            { }
            else { }


            List<Dictionary<int, string>> productDescription = [];

            foreach (var product in productDescription)
            {
                foreach (var item in product)
                {
                }
            }
        }

        public void UseTuple(int Id, string Name, DateTime birthDate)
        {
            Tuple<int,string, DateTime> tuple = new(Id, Name, birthDate);

            Console.WriteLine($"ID: {tuple.Item1} Nome: {tuple.Item2} DataNascita: {tuple.Item3.ToShortDateString()}");

            Tuple<List<Employee>,List<Person>,DateTime,bool> tuple1=
                new([], [], DateTime.Now, false);

            tuple1.Item1.Add(new Employee() { });
            tuple1.Item2.Add(new Person("CLAC", "CLOC",49));
            
            foreach (var item in tuple1.Item1)
            {
                Console.WriteLine($"Nome: {item.Name}");
            }
        }
    }
}
