using StartAcademy7.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StartAcademy7.BLogic.EmployeeCardManager;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace StartAcademy7.BLogic
{
    public class EmployeeCardManager
    {
        private static EmployeeCardManager instance;
        List<Tuple<string, string, EmployeeData, List<Weekwork>>> employeeCard = [];
        public static EmployeeCardManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeCardManager();
                }
                return instance;
            }
        }

        public void ReadTxtFile()
        {

        }

        public void WriteTxtFile()
        {
        }

        public void ReadAndSplitEmployees()
        {
            Dictionary<string, string> employeeEnrollmentJob = [];
            List<EmployeeData> employeeDatas = [];

            EmployeeData employee;


            try
            {
                string[] employeeLines = File.ReadAllLines(ConfigParams.PathTxtFileName);

                foreach (string line in employeeLines)
                {
                    string[] items = line.Split(';');

                    if (items.Length == 10)
                    {
                        employee = new EmployeeData(items[0], items[1], items[3], Convert.ToInt16(items[4]), items[5], items[6], items[7], items[8], items[9]);

                        employeeDatas.Add(employee);
                        employeeEnrollmentJob.Add(items[0], items[2]);
                        employeeCard.Add(new(items[0], items[2], employee, []));
                    }
                }

                SerializeEmployeeCardToJson();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //foreach (var empJobTitle in employeeEnrollmentJob)
            //{
            //    EmployeeData employeeData = employeeDatas.Find(e => e.EnrollId == empJobTitle.Key);

            //    if ( employeeData != null)
            //    {
            //        //List<Tuple<string, string, EmployeeData, List<Weekwork>>> employeeCard;
            //        Console.WriteLine($"Matricola: {empJobTitle.Key}. Mansione: {empJobTitle.Value}");
            //        Console.WriteLine(new string('-', 100));
            //        Console.WriteLine($"Nome : {employeeData.Name}, Reparto: {employeeData.Department}, Età: {employeeData.Age}");
            //        Console.WriteLine($"{new string('*', 100)}\n");
            //    }
            //}
        }

        public record EmployeeData(string EnrollId, string Name, string Department,
            int Age, string Address, string City, string Province, string ZipCode, string PhoneNumber);

        private void SerializeEmployeeCardToJson()
        {
            //  List<Tuple<string, string, EmployeeData, List<Weekwork>>> employeeCard = [];

            try
            {
                string cardJson = JsonSerializer.Serialize(employeeCard, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(Path.Combine(ConfigParams.AppFilePath, "Employeecard.json"), cardJson);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"ERRORE SERIALIZZAZIONE OGGETTO TUPLA: {ex.Message}");
                throw;
            }
        }
    }
}
