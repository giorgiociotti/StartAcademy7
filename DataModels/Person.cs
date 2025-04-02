using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{
    public record Person(string name, string surname, int age)
    {
        public string FullName => $"{name} {surname}";
    }
}
