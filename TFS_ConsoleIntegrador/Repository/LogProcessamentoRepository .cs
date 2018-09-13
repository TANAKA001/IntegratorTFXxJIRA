using System;
using System.Data;
using System.Data.SqlClient;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Repository
{
    public class LogProcessamentoRepository
    {
        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        SqlCommand cmd;

        public LogProcessamentoRepository()
        {
        }

        //public String ConsultaDtLog()
        //{
        //    string query = "Select dtProcessamento, dscErroProcessamento from [dbo].[LogProcessamento]";

        //    DateTime _retorno = conncetion._LogData(query);

        //    //return _retorno.ToString("yyyy/MM/dd HH:mm:ss");
        //    return _retorno.ToString("yyyy/MM/dd 00:00:00");
        //}

        public dynamic InsertLogProcessamento(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = " INSERT INTO [dbo].[LogProcessamento] ";
                query += " ([dtProcessamento], [flgErroProcessamento], [dscErroProcessamento], [etapaProcessamento]) VALUES";
                query += " (@dtProcessamento, @flgErroProcessamento, @dscErroProcessamento, @etapaProcessamento ) ";

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
                return new
                {
                    e
                };
            }
        }

        public dynamic UpdateDtProcessamento(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = " UPDATE [dbo].[LogProcessamento] ";
                query += " SET [dtProcessamento] = @dtProcessamento, ";
                query += " [flgErroProcessamento] = @flgErroProcessamento, ";
                query += " [dscErroProcessamento] = @dscErroProcessamento ";

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
                return new
                {
                    e
                };
            }
        }

        private void _parameters(ObjectToQuery _objectToQuery, string query)
        {
            cmd = new SqlCommand(query);

            DateTime DtRegistro = Convert.ToDateTime(_objectToQuery.DtRegistro);
            bool FlgErro = _objectToQuery.FlagErroPrcessamento;
            string DscErro = (string.IsNullOrEmpty(_objectToQuery.DscErroProcessamento))?"": _objectToQuery.DscErroProcessamento;
            string etapaProcessamento = (string.IsNullOrEmpty(_objectToQuery.EtapaProcessamento)) ? "" : _objectToQuery.EtapaProcessamento;

            cmd.Parameters.Add("@dtProcessamento", SqlDbType.DateTime);
            cmd.Parameters["@dtProcessamento"].Value = DtRegistro;

            cmd.Parameters.Add("@flgErroProcessamento", SqlDbType.Bit);
            cmd.Parameters["@flgErroProcessamento"].Value = FlgErro;

            cmd.Parameters.Add("@dscErroProcessamento", SqlDbType.NVarChar,-1);
            cmd.Parameters["@dscErroProcessamento"].Value = DscErro;
            
            cmd.Parameters.Add("@etapaProcessamento", SqlDbType.NVarChar, -1);
            cmd.Parameters["@etapaProcessamento"].Value = etapaProcessamento;
        }
    }
}
