using System;
using System.Data;
using System.Data.SqlClient;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Repository
{
    public class DtParametroRepository 
    {
        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        SqlCommand cmd;

        public DtParametroRepository()
        {
        }

        public String ConsultaDtParametro()
        {
            string query = "Select Dt_RegistroTFS from [dbo].[Parametro]";

            DateTime _retorno = conncetion._parametroData(query);

            //return _retorno.ToString("yyyy/MM/dd HH:mm:ss");
            return _retorno.ToString("yyyy/MM/dd 00:00:00");
        }

        public dynamic InsertDtRegistro(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = " INSERT INTO [dbo].[Parametro] ";
                query += " ([Dt_RegistroTFS]) VALUES";
                query += " (@Dt_RegistroTFS) ";

                _parameters(_objectToQuery, query);
                conncetion.ExecuteQueries(cmd);
                /*-----------*/
                return new
                {
                    _executado
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public dynamic UpdateDtRegistro(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = " UPDATE [dbo].[Parametro] ";
                query += " SET [Dt_RegistroTFS] = @Dt_RegistroTFS ";
                
                _parameters(_objectToQuery, query);
                conncetion.ExecuteQueries(cmd);
                /*-----------*/
                return new
                {
                    _executado
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void _parameters(ObjectToQuery _objectToQuery, string query)
        {
            cmd = new SqlCommand(query);

            DateTime DtRegistro = Convert.ToDateTime(_objectToQuery.DtRegistro);

            cmd.Parameters.Add("@Dt_RegistroTFS", SqlDbType.DateTime);
            cmd.Parameters["@Dt_RegistroTFS"].Value = DtRegistro;
        }
    }
}
