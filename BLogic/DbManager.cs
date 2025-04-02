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
                if(_connection.State == ConnectionState.Open)
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
                        Age = string.IsNullOrEmpty(dataReader["Age"].ToString()) ? 0: Convert.ToInt16(dataReader["Age"]),
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
                _command.Parameters.AddWithValue("@FullName", "%"+FullName+"%");
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
                _command.Parameters.AddWithValue("@EmployeeName",FullName);
                _command.Parameters.Add(new SqlParameter("@Matricola",SqlDbType.NChar,4)).Direction = ParameterDirection.Output ;
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

        public List<Worker> spGetEmployeesByName(string P1="", string Role = "")
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

        public bool spInsertWorker(Worker worker)
        {
            bool result = false;
            try
            {
                CheckDbOpen();

                _command = new SqlCommand
                {
                    CommandText = "spInsertWorker",
                    CommandType = CommandType.StoredProcedure,
                    Connection = _connection
                };

                _command.Parameters.AddWithValue("@Matricola",worker.Matricola);
                _command.Parameters.AddWithValue("@FullName", worker.FullName);
                _command.Parameters.AddWithValue("@Role",worker.Role);
                _command.Parameters.AddWithValue("@Department", worker.Department);

                _command.ExecuteNonQuery();

                result = true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Erorre SQL:" + sqlEx.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erorre generico:" + ex.Message);
            }
            finally { CheckDbClose(); }
            return result;
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
                Console.WriteLine("Erorre SQL:"+SqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erorre generico:" + ex.Message);
            }
            finally
            {
                CheckDbClose();
            }
            return true;
        }

    }
}
