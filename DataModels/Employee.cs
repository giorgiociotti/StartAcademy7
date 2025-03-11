using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{
    public class Employee
    {
        protected List<Employee> Employees = [];

        public string Enrollement { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; }
        public int Gender { get; set; }
        public string City { get; set; } = string.Empty;
        public int Age { get; set; }


        public Employee()
        {
            Enrollement = string.Empty;
            Name = string.Empty;
            Surname = string.Empty;
            Age = 0;
        }

        public Employee(string enrollment, string name,int gender,string city, string surname, int age)
        {
            Enrollement = enrollment;
            Name = name;
            Surname = surname;
            Gender = gender;
            City = city;
            Age = age;
        }
    }
}
