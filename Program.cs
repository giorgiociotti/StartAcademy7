using Serilog;
using Serilog.Sinks.MSSqlServer;
using StartAcademy7.BLogic;
using StartAcademy7.DataModels;

namespace StartAcademy7
{
    // start application class
    internal class Program
    {

        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Utility AppUtility = new();
            AppUtility.GetSetApplicationParams();

            DbManager dbManager = new(ConfigParams.SqlDbConnection);
            //if (dbManager.IsDbOnline)
            //{
            //    //dbManager.GetWorkers().ForEach(w => Console.WriteLine($"Nominativo: {w.FullName}"));
            //    //dbManager.GetWorkersByFullName("Rossi").ForEach(w => Console.WriteLine($"Matricola per nominativo: {w.Matricola}"));
            //    //Console.WriteLine($"Numero totale dei dipententi: {dbManager.GetTotalWorkers()}");

            //    //Console.WriteLine(new string('-', 120));
            //    //Console.WriteLine($"\nMatricola ottenuta da Stored Procedure, cercando Mario Rossi: {dbManager.GetSPWorkersByFullName("Mario Rossi")}");
            //    //dbManager.spGetEmployeesByName().ForEach(worker => 
            //    //    Console.WriteLine($"Esecuzione SP spGetEmployeesByName: {worker.Matricola} - {worker.FullName} - {worker.Role}"));
            //    //Console.WriteLine(new string('-', 120));

            //    //dbManager.spGetEmployeesByName("Rossi","Impiegato").ForEach(worker =>
            //    //    Console.WriteLine($"Esecuzione SP spGetEmployeesByName CON PARAMETRI: {worker.Matricola} - {worker.FullName} - {worker.Role}"));

            //    Worker worker = new()
            //    {
            //        Matricola = "Z192",
            //        FullName = "Harry Potter",
            //        Role = "Young Wizard",
            //        Department = "Hogwards"
            //    };
            //    Console.WriteLine(dbManager.spInsertWorker(worker));

            //    Console.WriteLine(dbManager.UpdateWorker("I001", "Vendite"));

            //    Console.WriteLine(dbManager.DeleteDbWorker("F022"));
            //}
            //else
            //{
            //    Console.WriteLine("Database non raggiungibile, applicazione terminata");
            //    return;
            //}




            //MSSqlServerSinkOptions sSqlServerSinkOptions = new MSSqlServerSinkOptions
            //{
            //    TableName = "WorkersLog",
            //    AutoCreateSqlDatabase = true,
            //    AutoCreateSqlTable = true,
            //    BatchPostingLimit = 30,
            //    BatchPeriod = TimeSpan.FromSeconds(300),
            //    EagerlyEmitFirstEvent = true
            //};

            //Log.Logger = new LoggerConfiguration()
            //     .WriteTo.Console()
            //     .WriteTo.File(Path.Combine(ConfigParams.AppFilePath, "SeriLogger.log"))
            //     .WriteTo.MSSqlServer("Data Source=BETACOM-PCBC9S\\SQLEXPRESS;Initial Catalog=AcaSevenWorkers;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False", sSqlServerSinkOptions)
            //     .CreateLogger();

            //Log.Information("Esecuzione programma Academy7 (tipo console)");
            ////NLog.Logger nLogger = NLog.LogManager.GetCurrentClassLogger();

            ////nLogger.Info("INFORMAZIONE DA NLOG");

            //try
            //{
            //    int x = 1;
            //    Console.WriteLine(x / 0);

            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex,$"ERRORE IMPREVISTO: {ex.Message}");
            //    //nLogger.Error($"NLOG ERRORE IMPREVISTO: {ex.Message}");
            //}


            //Oop.SquareArea standardObject = new();
            //standardObject.Show();
            //standardObject.ComputeArea();

            //Oop.CircleArea area = new Oop.CircleArea();
            //area.Show();
            //area.ComputeArea();

            //Oop.Circle circle = new();

            //circle.Show();
            //circle.ComputeArea();
            //circle.GetRadius(3.4);

            //CarAuto carAuto = new();

            //carAuto.Brand = "BMW";
            //carAuto.Model = "X6";
            //carAuto.CarEngine = MainEnumerators.CarEngine.Hybrid;
            //carAuto.BasePrice = 50000m;
            //Console.WriteLine(carAuto.FinalPrice());

            //CarBenzina carBenzina = new();
            //carBenzina.Brand = "Mercedes";
            //carBenzina.Model = "C200";
            //carBenzina.BasePrice = 44000m;
            //carBenzina.CarEngine = MainEnumerators.CarEngine.Fuel;
            //Console.WriteLine(carBenzina.FinalPrice());

            //CarElettrica carElettrica = new();
            //carElettrica.BasePrice = 40000m;
            //carElettrica.CarEngine = MainEnumerators.CarEngine.Electric;
            //Console.WriteLine(carElettrica.FinalPrice());


            //Singleton singleton = Singleton.Instance;
            //singleton.Msg();
            //Singleton singleton2 = Singleton.Instance;
            //singleton.Msg();
            //Singleton singleton3 = Singleton.Instance;
            //singleton.Msg();
            //Person person = new("Claudio", "Orloff", 49);
            //Console.WriteLine($"Nome: {person.name}");
            //Console.WriteLine($"Cognome: {person.surname}");
            //Console.WriteLine($"Età: {person.age}");
            //Console.WriteLine($"Nome Completo: {person.FullName}");
            //Person person1 = person with { name = "Marion" };
            //Console.WriteLine($"Nome: {person1.name}");
            //Console.WriteLine($"Cognome: {person1.surname}");
            //Console.WriteLine($"Età: {person1.age}");
            //Person person2 = new("Claudio", "Orlofsf", 49);
            //Console.WriteLine($"person = person2?: {person == person2}");

            //(string nome, string cognome, int eta) = person;
            //Console.WriteLine($"Nome: {nome}");
            //Console.WriteLine($"Cognome: {cognome}");
            //Console.WriteLine($"Età: {eta}");
            //Point point = new(27, 81);
            //Console.WriteLine(point.X + " - " + point.Y);
            //DictionaryAndTuple dicTuple = new ();
            //dicTuple.UseDictonary();

            //Utility AppUtility = new();

            //AppUtility.GetSetApplicationParams();
            //EmployeeCardManager employeeCardManager = EmployeeCardManager.Instance;
            //employeeCardManager.ReadAndSplitEmployees();
            //AppUtility.LogTypeFileRequest();
            //Start.ShowMenu();

            //string separator = new string('-', 150) + '\n';
            //RefSample.SquareNumber(9);
            //DateTime date1 = DateTime.Now;
            //for (int i = 0; i <= 100000; i++)
            //{ }
            //DateTime date2 = DateTime.Now;

            //Console.WriteLine($"Che ora sarà tra due ore?: {date1.AddHours(2)}");
            //Console.WriteLine(separator);
            //Console.WriteLine($"Durata ciclo for da 100000 : {(date2 - date1).TotalMilliseconds}");
            //Console.WriteLine(separator);
            //Console.WriteLine($"data e ora corrente : {DateTime.Now}");
            //Console.WriteLine(separator);
            //Console.WriteLine($"data , formato corto : {DateTime.Now.ToShortDateString()}");
            //Console.WriteLine(separator);
            //Console.WriteLine($"data , formato lungo : {DateTime.Now.ToLongDateString()}");
            //Console.WriteLine(separator);
            //Console.WriteLine($"data e ora corrente, formato corto : " +
            //    $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            //Console.WriteLine(separator);
            //Console.WriteLine($"data e ora corrente, formato lungo : " +
            //    $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
            //Console.WriteLine(separator);
            //Console.WriteLine($"data e ora corrente : {DateTime.Now.ToString("yyyy/MM/dd")}");
            //Console.WriteLine(separator);
            //Console.WriteLine(separator);
            //string testo = "claudio orloffo";
            //Console.WriteLine(testo.TrasformaInMaiuscolo());
            //Console.WriteLine(testo.PrimaLetteraMaiuscola());

            EmployeesHandler employeesHandler = new EmployeesHandler();

            //Employee employee = new ()
            //{
            //    Enrollement = "A01",
            //    Name = "k.jdzhfkjsdhfhwefòilhsdlkclskdclwhroiurowieuroi3uworiu3opru29ru32p9urfp9à3wufeàoilsjfdkjxz",
            //    Surname = "orloff",
            //    Age = 15
            //};

            //employeesHandler.EmployeeValidation(employee);

            //employeesHandler.RegExDemo();
            employeesHandler.ReadWorkers();
            //employeesHandler.LinqDemo();
            //employeesHandler.Sha256Encryption("Orloff");
            //KeyValuePair<string, string> keyValuePair = employeesHandler.SaltEncryption("Orloff");

            //Console.WriteLine($"HASH: {keyValuePair.Key} - SALT: {keyValuePair.Value}");
            //employeesHandler.EmployeesStatistics();
            //Console.Write("Aspetto un tuo comando, mio signore, per chiuder: ");
            //Console.ReadLine();


            //DA QUI ESERCIZIO DATABASE
            //employeesHandler.Workers
            if (dbManager.IsDbOnline) {
                //dbManager.PopulateAcademy7Tables(employeesHandler.Workers);
                //dbManager.UpdateWeekWork(5, "I001", "2025-04-02", "aaaaaaaa");
                dbManager.spReadWeekwork(Activity: "").ForEach(w => Console.WriteLine($"ID: {w.Id} - Enroll: {w.EnrollementFather} - Date: {w.WorkDate.Day}/{w.WorkDate.Month}/{w.WorkDate.Year} - Activity: {w.Activity}"));
            }




        }
    }
}
