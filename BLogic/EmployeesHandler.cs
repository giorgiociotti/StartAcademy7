using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Logging;
using Serilog;
using StartAcademy7.DataModels;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace StartAcademy7.BLogic
{
    public class EmployeesHandler
    {
        private List<Employee> Employees = [];
        private List<Worker> Workers = [];
        private DateTime EmployeeBirthDate = DateTime.MinValue;
        private int EmployeeAge = 0; 
        //private static Microsoft.Extensions.Logging.ILogger loggerMS;

        public EmployeesHandler()
        {
            //using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder.AddConsole();
            //});

            //loggerMS = loggerFactory.CreateLogger<EmployeesHandler>();

            Log.Information("Istanziamento classe EmployeesHandler, senza parametro");
        }

        public EmployeesHandler(DateTime birthDate)
        {
            EmployeeBirthDate = birthDate;
            Log.Information("Istanziamento classe EmployeesHandler, con parametro, birthDate");
        }

        public bool InsertEmployee(Employee employee)
        {
            bool result = false;

            try
            {
                Employees.Add(employee);
                result = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            return result;
        }

        public bool DeleteEmployee(string enrollement)
        {
            bool result = false;

            try
            {
                Employee? employee = Employees.Find(e => e.Enrollement == enrollement);

                if (employee != null)
                {
                    Employees.Remove(employee);
                    result = true;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

            return result;
        }

        public void PrintEmployees()
        {
            Employees
                .ForEach(e =>
                {
                    Console.WriteLine($"Nominativo: {e.Name} {e.Surname} - Città: {e.City}");
                });
        }

        public void EmployeesFilter(int age, string city)
        {
            Employees.FindAll(e => e.Age >= age && e.City.Contains(city, StringComparison.OrdinalIgnoreCase))
                .ForEach(e =>
                {
                    Console.WriteLine($"Nominativo: {e.Name} {e.Surname}");
                });
        }

        public void SaveEmployees()
        {
            try
            {
                // write txt file (csv), with File .NET class
                List<string> EmployeesString = [];

                foreach (Employee e in Employees)
                {
                    EmployeesString.Add(e.EmployeeValues());
                }

                File.WriteAllLines("C:\\Temp\\EMployees.txt", EmployeesString);
                // ****************************************************************

                // write txt file (csv) with Streamwriter .NET Class

                //StreamWriter streamWriter = new ("C:\\Temp\\EMployees2.txt");

                //foreach (Employee e in Employees)
                //    streamWriter.WriteLine(e.EmployeeValues());

                //streamWriter.Close();

                using (StreamWriter streamWriter2 = new(ConfigParams.PathTxtFileName))
                {
                    foreach (Employee e in Employees)
                    {
                        // Check again, age property
                        streamWriter2.WriteLine(e.EmployeeValues());
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }

        }


        public void ReadWorkers()
        {
            try
            {
                // Read txt file by File.ReadAllLines
                string[] stringsWorkers = File.ReadAllLines("C:\\Temp\\EMployees.txt");  // NO HARDCODED
                string[] daysWork = File.ReadAllLines("C:\\Temp\\Calendars.txt");
                Workers.Clear();

                foreach (string se in stringsWorkers)
                {
                    var fields = se.Split(';');
                    Workers.Add(new Worker
                    {
                        Matricola = fields[0],
                        FullName = fields[1],
                        Role = fields[2],
                        Department = fields[3],
                        Age = Convert.ToInt16(fields[4]),
                        Address = fields[5],
                        City = fields[6],
                        Province = fields[7],
                        Cap = fields[8],
                        Phone = fields[9],
                    });
                    foreach (string day in daysWork)
                    {
                        if (se.Split(';')[0] == day.Split(';')[2])
                        {
                            Workers[Workers.Count - 1].Weekworks.Add(new(Workers[Workers.Count - 1].Weekworks.Count + 1,
                                DateTime.Parse(day.Split(';')[0]), day.Split(';')[1], day.Split(';')[2]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        public void ReadEmployees()
        {
            try
            {
                // Read txt file by File.ReadAllLines
                string[] stringsEMployees = File.ReadAllLines("C:\\Temp\\EMployees.txt");  // NO HARDCODED
                Employees.Clear();

                foreach (string se in stringsEMployees)
                {
                    var fields = se.Split(';');
                    Employees.Add(new Employee
                    {
                        Enrollement = fields[0],
                        Name = fields[1],
                        Surname = fields[2],
                        Gender = Enum.Parse<MainEnumerators.Gender>(fields[3]),
                        City = fields[4],
                        Age = int.Parse(fields[5])
                    });
                }

                //****************************************************************
                // Read  txt file by Streamreader

                //using (StreamReader streamReader = new("C:\\Temp\\EMployees2.txt"))
                //{
                //    string row;
                //    while ((row = streamReader.ReadLine()) != null)
                //    {
                //        // row validation, is required
                //        Employees.Add(new Employee
                //        {
                //            Enrollement = row.Split(';')[0],
                //            Name = row.Split(';')[1],
                //            Surname = row.Split(';')[2],
                //            Gender = Enum.Parse<MainEnumerators.Gender>(row.Split(';')[3]),
                //            City = row.Split(';')[4],
                //            Age = int.Parse(row.Split(';')[5])
                //        });
                //    }
                //}
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }
        public void FillCompleteEmployee()
        {
            int i = 1;
            foreach (Employee employee in Employees)
            {
                Weekwork weekwork = new();
                weekwork.Id = i;
                weekwork.EnrollementFather = employee.Enrollement;
                weekwork.WorkDate = DateTime.Now;
                weekwork.Activity = "Docenza";

                employee.weekworks.Add(weekwork);
                i += 1;
            }
        }

        public void SaveEmployeesJson()
        {
            try
            {
                string jsonEmployees = JsonSerializer.Serialize(Employees, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(ConfigParams.PathJsonFileName, jsonEmployees);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        public void ReadEmployeesJson()
        {
            try
            {
                Employees.Clear();
                string jsonEmployees = File.ReadAllText(ConfigParams.PathJsonFileName);

                Employees = JsonSerializer.Deserialize<List<Employee>>(jsonEmployees);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        public void SaveEmployeesXml()
        {
            XmlSerializer serializer = new(typeof(List<Employee>));

            using (StreamWriter writer = new StreamWriter(ConfigParams.PathXmlFileName))
            {
                serializer.Serialize(writer, Employees);
            }
        }

        public void ReadEmployeesXML()
        {
            try
            {
                Employees.Clear();
                XmlSerializer serializer = new(typeof(List<Employee>));

                using (StreamReader reader = new StreamReader(ConfigParams.PathXmlFileName))
                {
                    Employees = (List<Employee>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);

            }
        }

        public bool EmployeeValidation(Employee employee)
        {
            var contextValidation = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(employee, contextValidation, validationResults, true);

            if (isValid)
                return true;
            else
            {
                Console.WriteLine("ATTENZIONE: Uno o più dati del Dipendente, risultano NON validi");
                foreach (ValidationResult validationResult in validationResults)
                    Console.WriteLine(validationResult.ErrorMessage);
                return false;
            }
        }

        public void RegExDemo()
        {
            string text = " C'è un cane sul mio tetto";
            string pattern = "cane";
            string replacement = "gatto";
            string newText = Regex.Replace(text, pattern, replacement);
            Console.WriteLine(newText);
            string phoneNumber = "Numero telefono 123-456789-01 e in più quello aziendale 012-655454-33";
            string pattern2 = @"\d{3}-\d{6}-\d{2}";

            MatchCollection matches = Regex.Matches(phoneNumber, pattern2);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

            string bykeCost = "Il costo della byke downhill è di: 4200 Euro";
            string pattern3 = @"\d+";

            Match match1 = Regex.Match(bykeCost, pattern3);
            if (match1.Success)
                Console.WriteLine($"La Byke per Claudio, costa: {match1.Value}");
            else
                Console.WriteLine("Costo assente");

            string email = "esempio@dominio.com";
            string pattern4 = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        }

        public void LinqDemo()
        {
            // Language Integration Query
            Console.WriteLine("Uso metodi standard per estrazione dati e statistiche, con lambda expression/linq");
            var employeesRoma = Workers.Where(e => e.City == "Roma");

            foreach (Worker employee in employeesRoma)
            {
                Console.WriteLine($"Nominativo: {employee.FullName}");
            }

            var ancientEmployees = Workers.OrderByDescending(e => e.Age).FirstOrDefault();
            Console.WriteLine($"Impiegato più anziano: {ancientEmployees.FullName}");

            var employeesCity = Workers.GroupBy(e => e.City);
            Console.WriteLine("Impiegati raggruppati per città");
            foreach (var group in employeesCity)
            {
                Console.WriteLine($"Città: {group.Key}");
                foreach (Worker employee in group)
                {
                    Console.WriteLine($"Nominativo: {employee.FullName}");
                }
            }

            var employeesRoma2 = from wkr in Workers
                                 where wkr.City == "Roma"
                                 select wkr;

            foreach (Worker employee in employeesRoma2)
            {
                Console.WriteLine($"Nominativo: {employee.FullName}");
            }
        }

        public void Sha256Encryption(string password)
        {
            string rsult = string.Empty;
            var sha256 = SHA256.Create();
            byte[] encryptedBytes = Encoding.UTF8.GetBytes(password);

            try
            {
                byte[] hash = sha256.ComputeHash(encryptedBytes);
                rsult = BitConverter.ToString(hash, 0, hash.Length).Replace("-", "");
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);
            }
        }

        public KeyValuePair<string, string> SaltEncryption(string sPassword)
        {
            KeyValuePair<string, string> encryptionResult;
            byte[] bytesSalt = new byte[32];

            RandomNumberGenerator.Fill(bytesSalt);
            string hashValue = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: sPassword,
                salt: bytesSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 64));

            encryptionResult = new KeyValuePair<string, string>(hashValue, Convert.ToBase64String(bytesSalt));

            return encryptionResult;
        }

        public void EmployeesStatistics()
        {
            //loggerMS.LogInformation("Esecuzione metodo demo LinQ");
            Console.WriteLine("SITUAZIONE FERIE");

            var workersHolidays = Workers
                .Select(wk => new
                {
                    wk.Matricola,
                    wk.FullName,
                    wkHolyday = wk.Weekworks
                    .Where(wh => wh.Activity.ToLower() == "ferie")
                    .Select(wh => new { wh.Activity, wh.WorkDate }).ToList()
                })
                .Where(wk => wk.wkHolyday.Any());

            foreach (var wk in workersHolidays)
            {
                Console.WriteLine($"Matricola: {wk.Matricola} - Nominativo: {wk.FullName}");
                foreach (var wh in wk.wkHolyday)
                {
                    Console.WriteLine($"\tAttività: {wh.Activity} - Data: {wh.WorkDate}");
                }
            }

            Console.WriteLine("SITUAZIONE STRAORDINARI PRE FESTIVI");

            var workersExtraTime = Workers
                .Select(wk => new
                {
                    wk.Matricola,
                    wk.FullName,
                    wkExtra = wk.Weekworks
                    .Where(wh => wh.Activity.ToLower() == "pre festivo")
                    .Select(wh => new { wh.Activity, wh.WorkDate }).ToList()
                })
                .Where(wk => wk.wkExtra.Any());

            foreach (var wk in workersExtraTime)
            {
                Console.WriteLine($"Matricola: {wk.Matricola} - Nominativo: {wk.FullName} - Totale Straordinari: {wk.wkExtra.Count * 5} Ore ");
                foreach (var wh in wk.wkExtra)
                {
                    Console.WriteLine($"\tAttività: {wh.Activity} - Data: {wh.WorkDate}");
                }
            }
        }
    }
}
