using Microsoft.Data.SqlClient;
using StartAcademy7.DataModels;
using System.Data;

namespace StartAcademy7.BLogic
{
    public class DbManager
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        public bool IsDbOnline = false;
        public DbManager(string connectionString)

        {
            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();
                IsDbOnline = true;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

        }

        public List<Worker> GetWorkers()
        {
            List<Worker> workers = [];
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                _command = new SqlCommand("SELECT * FROM [AcademyNet7].[dbo].[Worker]", _connection);
                SqlDataReader dataReader = _command.ExecuteReader();
                while (dataReader.Read())
                {
                    workers.Add(new Worker
                    {
                        Matricola = dataReader[0].ToString(),
                        FullName = dataReader[1].ToString(),
                        Role = dataReader["Role"].ToString(),
                        Department = dataReader["Department"].ToString(),
                        Age = string.IsNullOrEmpty(dataReader["Age"].ToString()) ? 0 : Convert.ToInt16(dataReader["Age"]),
                        Address = dataReader["Address"].ToString(),
                        City = dataReader["City"].ToString(),
                        Province = dataReader["Province"].ToString(),
                        Cap = dataReader["Cap"].ToString(),
                        Phone = dataReader["Phone"].ToString()
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return workers;
        }

        public List<Worker> GetWorkersByFullName(string FullName)
        {
            List<Worker> workers = [];
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                _command = new SqlCommand("SELECT * FROM [AcademyNet7].[dbo].[Worker] WHERE FullName LIKE @FullName", _connection);
                _command.Parameters.AddWithValue("@FullName", "%" + FullName + "%");
                SqlDataReader dataReader = _command.ExecuteReader();
                while (dataReader.Read())
                {
                    workers.Add(new Worker
                    {
                        Matricola = dataReader[0].ToString(),
                        FullName = dataReader[1].ToString(),
                        Role = dataReader["Role"].ToString(),
                        Department = dataReader["Department"].ToString(),
                        Age = string.IsNullOrEmpty(dataReader["Age"].ToString()) ? 0 : Convert.ToInt16(dataReader["Age"]),
                        Address = dataReader["Address"].ToString(),
                        City = dataReader["City"].ToString(),
                        Province = dataReader["Province"].ToString(),
                        Cap = dataReader["Cap"].ToString(),
                        Phone = dataReader["Phone"].ToString()
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return workers;
        }

        public int GetTotalWorkers()
        {
            int totalWorkers = 0;
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                _command = new SqlCommand("SELECT COUNT(*) AS TotaleDipendenti FROM [AcademyNet7].[dbo].[Worker]", _connection);
                totalWorkers = (int)_command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            return totalWorkers;
        }

        public string GetSPWorkersByFullName(string FullName)
        {
            string matricola = string.Empty;
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                _command = new SqlCommand("spGetMatricolaByFullname", _connection);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@EmployeeName", FullName);
                _command.Parameters.Add(new SqlParameter("@Matricola", SqlDbType.NChar, 4)).Direction = ParameterDirection.Output;
                _command.ExecuteNonQuery();
                matricola = _command.Parameters["@Matricola"].Value.ToString();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return matricola;
        }

        public List<Worker> spGetEmployeesByName(string P1 = "", string Role = "")
        {
            List<Worker> workers = [];
            try
            {
                CheckDbOpen();
                _command = new SqlCommand("spGetEmployeesByName", _connection);
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddWithValue("@p1", P1);
                _command.Parameters.AddWithValue("@Role", Role);
                SqlDataReader dataReader = _command.ExecuteReader();
                while (dataReader.Read())
                {
                    workers.Add(new Worker
                    {
                        Matricola = dataReader["Matricola"].ToString(),
                        FullName = dataReader["FullName"].ToString(),
                        Role = dataReader["Role"].ToString(),
                        Department = dataReader["Department"].ToString(),
                        Age = string.IsNullOrEmpty(dataReader["Age"].ToString()) ? 0 : Convert.ToInt16(dataReader["Age"]),
                        Address = dataReader["Address"].ToString(),
                        City = dataReader["City"].ToString(),
                        Province = dataReader["Province"].ToString(),
                        Cap = dataReader["Cap"].ToString(),
                        Phone = dataReader["Phone"].ToString()
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                CheckDbClose();
            }
            return workers;
        }

        private void CheckDbClose()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        private void CheckDbOpen()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public string spInsertWorker(Worker worker)
        {
            bool result = false;
            string spResult = string.Empty;
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "spInsertWorker",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@Matricola", worker.Matricola);
                _command.Parameters.AddWithValue("@FullName", worker.FullName);
                _command.Parameters.AddWithValue("@Role", worker.Role);
                _command.Parameters.AddWithValue("@Department", worker.Department);
                _command.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 200)).Direction =
                    ParameterDirection.Output;

                _command.ExecuteNonQuery();
                spResult = _command.Parameters["@Result"].Value.ToString();

                if (spResult == string.Empty)
                    spResult = "Inserimento worker RIUSCITO";
                result = !string.IsNullOrEmpty(spResult) ? true : false;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Errore SQL:" + sqlEx.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore generico:" + ex.Message);
            }
            finally { CheckDbClose(); }
            return spResult;
        }
        public string spInsertWorkerFull(Worker worker)
        {
            bool result = false;
            string spResult = string.Empty;
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "spInsertWorker",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@Matricola", worker.Matricola);
                _command.Parameters.AddWithValue("@FullName", worker.FullName);
                _command.Parameters.AddWithValue("@Role", worker.Role);
                _command.Parameters.AddWithValue("@Department", worker.Department);
                _command.Parameters.AddWithValue("@Address", worker.Address);
                _command.Parameters.AddWithValue("@Age", worker.Age);
                _command.Parameters.AddWithValue("@Cap", worker.Cap);
                _command.Parameters.AddWithValue("@City", worker.City);
                _command.Parameters.AddWithValue("@Phone", worker.Phone);
                _command.Parameters.AddWithValue("@Province", worker.Province);
                _command.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 200)).Direction =
                    ParameterDirection.Output;

                _command.ExecuteNonQuery();
                spResult = _command.Parameters["@Result"].Value.ToString();

                if (spResult == string.Empty)
                    spResult = "Inserimento tutti worker RIUSCITO";
                result = !string.IsNullOrEmpty(spResult) ? true : false;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Errore SQL:" + sqlEx.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore generico:" + ex.Message);
            }
            finally { CheckDbClose(); }
            return spResult;
        }

        public bool UpdateWorker(string matricola, string department)
        {
            bool result = false;
            try
            {
                CheckDbOpen();
                _command = new();
                _command.CommandText = "Update [Worker] SET Department = @NewDepartment WHERE Matricola = @Matricola";
                _command.Connection = _connection;

                _command.Parameters.AddWithValue("@Matricola", matricola);
                _command.Parameters.AddWithValue("@NewDepartment", department);

                _command.ExecuteNonQuery();

                result = true;
            }
            catch (SqlException SqlEx)
            {
                Console.WriteLine("Errore SQL:" + SqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore generico:" + ex.Message);
            }
            finally
            {
                CheckDbClose();
            }
            return true;
        }

        public string DeleteDbWorker(string matricola)
        {
            string spResult = string.Empty;
            try
            {
                CheckDbOpen();
                _command = new SqlCommand("SELECT COUNT(*) AS TotaleDipendenti FROM [AcademyNet7].[dbo].[Worker] WHERE Matricola = @Matricola", _connection);
                _command.Parameters.AddWithValue("@Matricola", matricola);
                int totalWorkers = (int)_command.ExecuteScalar();
                if (totalWorkers == 0)
                {
                    CheckDbClose();
                    return $"Non esiste un dipendente con la matricola {matricola}!";
                }
                _command = new SqlCommand
                {
                    CommandText = "spDeleteWorker",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@Matricola", matricola);
                _command.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 200)).Direction =
                    ParameterDirection.Output;

                _command.ExecuteNonQuery();
                spResult = _command.Parameters["@Result"].Value.ToString();



                if (spResult == string.Empty)
                    spResult = "Cancellazione worker e relativi weekwork RIUSCITO";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Errore SQL:" + sqlEx.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore generico:" + ex.Message);
            }
            finally { CheckDbClose(); }
            return spResult;

        }



        public void PopulateAcademy7Tables(List<Worker> workers)
        {
            foreach (Worker worker in workers)
            {
                spInsertWorkerFull(worker);
            }
            PopulateWeekwork(workers);

        }

        public void InsertAllWeekwork(List<Weekwork> weekworks)
        {
            foreach (Weekwork weekwork in weekworks)
                spInsertWeekwork(weekwork);
        }

        public string spInsertWeekwork(Weekwork work)
        {
            bool result = false;
            string spResult = string.Empty;
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "spInsertWeekwork",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@EnrollmentFather", work.EnrollementFather);
                _command.Parameters.AddWithValue("@WorkDate", work.WorkDate);
                _command.Parameters.AddWithValue("@Activity", work.Activity);

                _command.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 200))
                    .Direction = ParameterDirection.Output;

                _command.ExecuteNonQuery();
                spResult = _command.Parameters["@Result"].Value.ToString();

                if (string.IsNullOrEmpty(spResult))
                    spResult = "Inserimento Weekwork RIUSCITO";

                result = !string.IsNullOrEmpty(spResult);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Errore SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore generico: " + ex.Message);
            }
            finally
            {
                CheckDbClose();
            }
            return spResult;

        }

        public void PopulateWeekwork(List<Worker> workers)
        {
            foreach (Worker worker in workers)
            {
                InsertAllWeekwork(worker.Weekworks);
            }
        }

        public string DeleteWeekWorkFull(string EnrollementFather, string Workdate, string Activity)
        {
            string spResult = string.Empty;
            try
            {
                CheckDbOpen();
                _command = new SqlCommand("SELECT COUNT(*) AS TotaleDate FROM [AcademyNet7].[dbo].[WeekWork] WHERE EnrollmentFather = @EnrollmentFather AND WorkDate = @WorkDate AND Activity = @Activity", _connection);
                _command.Parameters.AddWithValue("@EnrollmentFather", EnrollementFather);
                _command.Parameters.AddWithValue("@WorkDate", Workdate);
                _command.Parameters.AddWithValue("@Activity", Activity);
                int totalWorkers = (int)_command.ExecuteScalar();
                if (totalWorkers == 0)
                {
                    CheckDbClose();
                    return $"Non esiste nessuna attività {Activity} del dipendente {EnrollementFather} il {Workdate}!";
                }
                _command = new SqlCommand
                {
                    CommandText = "DELETE FROM [Weekwork] WHERE EnrollmentFather = @EnrollmentFather AND WorkDate = @WorkDate AND Activity = @Activity",
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@EnrollmentFather", EnrollementFather);
                _command.Parameters.AddWithValue("@WorkDate", Workdate);
                _command.Parameters.AddWithValue("@Activity", Activity);

                _command.ExecuteNonQuery();
                if (spResult == string.Empty)
                    spResult = "Cancellazione Weekwork RIUSCITO";

            }
            catch (SqlException sqlEx)
            {
                spResult = "Errore SQL: " + sqlEx.Message;
                Console.WriteLine(spResult);
            }
            catch (Exception ex)
            {
                spResult = "Errore generico: " + ex.Message;
                Console.WriteLine(spResult);
            }
            finally
            {
                CheckDbClose();
            }
            return spResult;
        }

        public string DeleteWeekWorkByID(int ID)
        {
            string spResult = string.Empty;
            try
            {
                CheckDbOpen();
                _command = new SqlCommand("SELECT COUNT(*) AS TotaleDate FROM [AcademyNet7].[dbo].[WeekWork] WHERE ID = @ID", _connection);
                _command.Parameters.AddWithValue("@ID", ID);

                int totalWorkers = (int)_command.ExecuteScalar();
                if (totalWorkers == 0)
                {
                    CheckDbClose();
                    return $"Non esiste nessuna attività con ID {ID}!";
                }
                _command = new SqlCommand
                {
                    CommandText = "DELETE FROM [Weekwork] WHERE ID = @ID",
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@ID", ID);

                _command.ExecuteNonQuery();
                if (spResult == string.Empty)
                    spResult = "Cancellazione Weekwork RIUSCITO";

            }
            catch (SqlException sqlEx)
            {
                spResult = "Errore SQL: " + sqlEx.Message;
                Console.WriteLine(spResult);
            }
            catch (Exception ex)
            {
                spResult = "Errore generico: " + ex.Message;
                Console.WriteLine(spResult);
            }
            finally
            {
                CheckDbClose();
            }
            return spResult;
        }


        //updateWeekwork
        public string UpdateWeekWork(int id,string enrollementFather, string? workDate=null, string? activity=null)
        {
            string spResult = string.Empty;
            bool result = false;
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "dbo.spUpdateWeekwork",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };
                _command.Parameters.AddWithValue("@ID", id);
                _command.Parameters.AddWithValue("@EnrollmentFather", enrollementFather);
                _command.Parameters.AddWithValue("@WorkDate", workDate);
                _command.Parameters.AddWithValue("@Activity", activity);
                _command.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 200)).Direction = ParameterDirection.Output;

                _command.ExecuteNonQuery();
                spResult = _command.Parameters["@Result"].Value.ToString();

                if (string.IsNullOrEmpty(spResult))
                    spResult = "Update Weekwork RIUSCITO";

                result = !string.IsNullOrEmpty(spResult);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Errore SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore generico: " + ex.Message);
            }
            finally
            {
                CheckDbClose();
            }
            return spResult;
        }


        public string spUpdateWorkerFull(string matricola, string? fullName = null, string? role = null, string? department = null, int? age = null, string? address = null, string? city = null, string? province = null, string? cap = null, string? phone = null)
        {
            string spResult = string.Empty;
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "spUpdateWorker",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@Matricola", matricola);
                _command.Parameters.AddWithValue("@FullName", fullName);
                _command.Parameters.AddWithValue("@Role", role);
                _command.Parameters.AddWithValue("@Department", department);
                _command.Parameters.AddWithValue("@Address", address);
                _command.Parameters.AddWithValue("@Age", age);
                _command.Parameters.AddWithValue("@Cap", cap);
                _command.Parameters.AddWithValue("@City", city);
                _command.Parameters.AddWithValue("@Phone", phone);
                _command.Parameters.AddWithValue("@Province", province);
                _command.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 200)).Direction =
                    ParameterDirection.Output;

                _command.ExecuteNonQuery();
                spResult = _command.Parameters["@Result"].Value.ToString();

                if (spResult == string.Empty)
                    spResult = $"Modifica Worker {matricola} riuscita";

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Errore SQL:" + sqlEx.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore generico:" + ex.Message);
            }
            finally { CheckDbClose(); }
            return spResult;
        }
        public string UpdateWeekWork(Weekwork weekwork)
        {
            string spResult = string.Empty;
            bool result = false;
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "spUpdateWeekwork",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@EnrollmentFather", weekwork.EnrollementFather);
                _command.Parameters.AddWithValue("@WorkDate", weekwork.WorkDate);
                _command.Parameters.AddWithValue("@NewActivity", weekwork.Activity);
                _command.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 200)).Direction = ParameterDirection.Output;

                _command.ExecuteNonQuery();
                spResult = _command.Parameters["@Result"].Value.ToString();

                if (string.IsNullOrEmpty(spResult))
                    spResult = "Update Weekwork RIUSCITO";

                result = !string.IsNullOrEmpty(spResult);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Errore SQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore generico: " + ex.Message);
            }
            finally
            {
                CheckDbClose();
            }
            return spResult;
        }

        public List<Weekwork> spReadWeekwork(int? ID = null, string? Workdate = null, string? Activity = null, string? EnrollementFather = null)
        {
            string spResult = string.Empty;
            List<Weekwork> weekwork = [];
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "dbo.spReadWeekwork",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };
                _command.Parameters.AddWithValue("@id", ID);
                _command.Parameters.AddWithValue("@EnrollementFather", EnrollementFather);
                _command.Parameters.AddWithValue("@WorkDate", Workdate);
                _command.Parameters.AddWithValue("@Activity", Activity);

                SqlDataReader dataReader = _command.ExecuteReader();
                while (dataReader.Read())
                {
                    weekwork.Add(new Weekwork
                    {
                        Id = Convert.ToInt32(dataReader["id"].ToString()),
                        EnrollementFather = dataReader["EnrollementFather"].ToString(),
                        WorkDate = (DateTime)dataReader["WorkDate"],
                        Activity = dataReader["Activity"].ToString()
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                CheckDbClose();
            }
            return weekwork;
        }

    }
}