using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TFS_ConsoleIntegrador.QuerryModels;
using TFS_ConsoleIntegrador.Repository;

namespace TFS_ConsoleIntegrador.DAO
{
    public class TFSIntegradoraConnection
    {
        SqlConnection _connection;
        

        private void OpenConection()
        {
            _connection = new SqlConnection(GetConnectionString());
            _connection.Open();
        }
        private void CloseConnection()
        {
            _connection.Close();
        }
        public void ExecuteQueries(SqlCommand cmd)
        {
            try
            {
                OpenConection();
                using (_connection)
                {
                    cmd.Connection = _connection;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        public Dictionary<int, string> _dicionarioWorkItemData(string query)
        {
            Dictionary<int, string> _dados = new Dictionary<int, string>();

            try
            {
                OpenConection();

                List<ObjectToQuery> ResultSet = new List<ObjectToQuery>();

                using (_connection)
                {
                    SqlCommand command = new SqlCommand(query, _connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var _Workitem = new ObjectToQuery();
                        _Workitem.IdWorkItem = reader["Id_WorkItem"].ToString();

                        ResultSet.Add(_Workitem);
                    }
                }
                foreach (var item in ResultSet)
                {
                    _dados.Add(Convert.ToInt32(item.IdWorkItem), "");
                }
            }
            catch (Exception e)
            {
                var error = e;
            }
            finally
            {
                CloseConnection();
            }
            return _dados;
        }

        public Dictionary<int, string> _dicionarioUpdateData(string query, int idWI)
        {
            Dictionary<int, string> _dados = new Dictionary<int, string>();

            try
            {
                OpenConection();

                List<ObjectToQuery> ResultSet = new List<ObjectToQuery>();

                using (_connection)
                {
                    SqlCommand command = new SqlCommand(query, _connection);
                    
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var _Workitem = new ObjectToQuery();
                        _Workitem.IdAuxiliar = reader["Id_Update"].ToString();

                        ResultSet.Add(_Workitem);
                    }
                }
                foreach (var item in ResultSet)
                {
                    _dados.Add(Convert.ToInt32(item.IdAuxiliar), "");
                }
            }
            catch (Exception e)
            {
                var error = e;
            }
            finally
            {
                CloseConnection();
            }
            return _dados;
        }

        public Dictionary<int, string> _dicionarioRevisionData(string query, int idWI)
        {
            Dictionary<int, string> _dados = new Dictionary<int, string>();

            try
            {
                OpenConection();

                List<ObjectToQuery> ResultSet = new List<ObjectToQuery>();

                using (_connection)
                {
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.Add("@Id_WorkItem", SqlDbType.Int);
                    command.Parameters["@Id_WorkItem"].Value = idWI;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var _Workitem = new ObjectToQuery();
                        _Workitem.IdAuxiliar = reader["ID_Revision"].ToString();

                        ResultSet.Add(_Workitem);
                    }
                }
                foreach (var item in ResultSet)
                {
                    _dados.Add(Convert.ToInt32(item.IdAuxiliar),"");
                }
            }
            catch (Exception e)
            {
                var error = e;
            }
            finally
            {
                CloseConnection();
            }
            return _dados;
        }

        public DateTime _parametroData(string query)
        {
            DateTime _dateRegistro = DateTime.Now;

            try
            {
                OpenConection();

                ObjectToQuery ResultSet = new ObjectToQuery();

                using (_connection)
                {
                    SqlCommand command = new SqlCommand(query, _connection);
                    
                    SqlDataReader reader = command.ExecuteReader();

                    var _Workitem = new ObjectToQuery();

                    while (reader.Read())
                    {
                        _Workitem.DtRegistro = Convert.ToDateTime(reader["Dt_RegistroTFS"]);
                    }

                    if (reader.HasRows)
                    {
                        _dateRegistro = _Workitem.DtRegistro;
                    }
                }
            }
            catch (Exception e)
            {
                var error = e;
            }
            finally
            {
                CloseConnection();
            }
            return _dateRegistro;
        }

        static private string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["ConnectionString"];
        }
    }

}