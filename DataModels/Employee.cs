using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{
    public class Employee
    {

        [Required]
        [MinLength(4, ErrorMessage = "Matricola da 4 caratteri di cui il primo alfabetico"),MaxLength(4,ErrorMessage = "Matricola da 4 caratteri di cui il primo alfabetico")]
        public string Enrollement { get; set; }
        [Required]
        [MinLength(3), MaxLength(35)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(35)]
        public string Surname { get; set; }
        [Required]
        public MainEnumerators.Gender Gender { get; set; }
        public string City { get; set; } = string.Empty;

        [Range(18,100)]
        public int Age { get; set; }
        public string EmployeeValues() => $"{Enrollement};{Name};{Surname};{Gender};{City};{Age}";

        public List<Weekwork> weekworks { get; set; } = [];
        public Employee()
        {
            Enrollement = string.Empty;
            Name = string.Empty;
            Gender = MainEnumerators.Gender.None;
            City = string.Empty;
            Surname = string.Empty;
            Age = 0;
        }

        public Employee(string enrollment, string name, MainEnumerators.Gender gender, string city, string surname, int age)
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
