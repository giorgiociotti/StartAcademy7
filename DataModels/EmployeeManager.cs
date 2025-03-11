using System;
using System.Collections.Generic;
using System.Linq;

namespace StartAcademy7.DataModels
{
    public class EmployeeManager
    {

        public List<Employee> Employees = new List<Employee>();

        List <Employee> Employees = new List<Employee>
        {
            new Employee(1, "Mario Rossi", 35, "Roma", "Maschio"),
            new Employee(2, "Anna Bianchi", 28, "Milano", "Femmina"),
            new Employee(3, "Luca Verdi", 40, "Napoli", "Maschio"),
            new Employee(4, "Giulia Neri", 32, "Torino", "Femmina"),
            new Employee(5, "Marco Gialli", 45, "Firenze", "Maschio")
        };
        public override string ToString()
        {
            return $"{ID}: {Name}, {Age} anni, {City}, {Gender}";
        }
        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            Console.WriteLine("Dipendente aggiunto con successo!\n");
        }

        public void RemoveEmployee(string enrollment)
        {
            var removed = Employees.RemoveAll(e => e.Enrollement == enrollment);
            if (removed > 0)
                Console.WriteLine("Dipendente rimosso con successo!\n");
            else
                Console.WriteLine("Dipendente non trovato!\n");
        }

        public void PrintEmployees()
        {
            if (Employees.Count == 0)
            {
                Console.WriteLine("Nessun dipendente registrato.\n");
                return;
            }
            foreach (var emp in Employees)
            {
                Console.WriteLine($"{emp.Enrollement} - {emp.Name} {emp.Surname}, {emp.Age} anni, {emp.City}, Genere: {(GenderType)emp.Gender}");
            }
            Console.WriteLine();
        }

        public void ShowEmployeeMenu()
        {
            while (true)
            {
                Console.WriteLine("GESTIONE DIPENDENTI");
                Console.WriteLine("A) Inserire un nuovo dipendente");
                Console.WriteLine("B) Eliminare un dipendente");
                Console.WriteLine("C) Stampare l'elenco dei dipendenti");
                Console.WriteLine("D) Filtrare i dipendenti");
                Console.WriteLine("E) Uscire");
                Console.Write("Scelta: ");
                string choice = Console.ReadLine()?.ToUpper();

                switch (choice)
                {
                    case "A":
                        Console.Write("Matricola: ");
                        string enrollment = Console.ReadLine();
                        Console.Write("Nome: ");
                        string name = Console.ReadLine();
                        Console.Write("Cognome: ");
                        string surname = Console.ReadLine();
                        Console.Write("Età: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Città: ");
                        string city = Console.ReadLine();
                        Console.Write("Genere (1=Maschio, 2=Femmina, 3=Altro): ");
                        int gender = int.Parse(Console.ReadLine());

                        AddEmployee(new Employee(enrollment, name, gender, city, surname, age));
                        break;

                    case "B":
                        Console.Write("Inserire la matricola del dipendente da eliminare: ");
                        string remEnrollment = Console.ReadLine();
                        RemoveEmployee(remEnrollment);
                        break;

                    case "C":
                        PrintEmployees();
                        break;

                    case "D":
                        Console.Write("Filtrare per età (0 per ignorare): ");
                        int ageFilter = int.Parse(Console.ReadLine());
                        Console.Write("Filtrare per città (lasciare vuoto per ignorare): ");
                        string cityFilter = Console.ReadLine();
                        Console.Write("Filtrare per genere (1=Maschio, 2=Femmina, 3=Altro, 0 per ignorare): ");
                        int genderFilter = int.Parse(Console.ReadLine());

                        var filtered = Employees.Where(e =>
                            (ageFilter == 0 || e.Age == ageFilter) &&
                            (string.IsNullOrEmpty(cityFilter) || e.City.Equals(cityFilter, StringComparison.OrdinalIgnoreCase)) &&
                            (genderFilter == 0 || e.Gender == genderFilter)
                        ).ToList();

                        if (filtered.Count == 0)
                            Console.WriteLine("Nessun risultato trovato.\n");
                        else
                            foreach (var emp in filtered)
                                Console.WriteLine($"{emp.Enrollement} - {emp.Name} {emp.Surname}, {emp.Age} anni, {emp.City}, Genere: {(GenderType)emp.Gender}");
                        Console.WriteLine();
                        break;

                    case "E":
                        Console.WriteLine("Uscita dal menu dipendenti.");
                        return;

                    default:
                        Console.WriteLine("Scelta non valida!\n");
                        break;
                }
            }
        }
    }
}
