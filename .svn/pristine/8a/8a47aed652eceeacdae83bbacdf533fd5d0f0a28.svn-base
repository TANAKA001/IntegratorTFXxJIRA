using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Controllers
{
    public class UpdatesRepository : TfsIntegradora
    {

        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        SqlCommand cmd;
        public Dictionary<int, string> ConsultaWorkItemUpdates(string idWI)
        {
            string query = "Select id_Update from " + tabelaUpdate + " Where Id_WorkItem = " + idWI + " Order By 1 desc";

            Dictionary<int, string> _retorno = new Dictionary<int, string>();

            _retorno = conncetion._dicionarioUpdateData(query, Convert.ToInt32(idWI));

            return _retorno;
        }
        public dynamic InsertWorkItemUpdate(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;

            try
            {
                String query = " INSERT INTO [dbo].[" + tabelaUpdate + "] ";
                query += " ([Id_WorkItem],[Id_Update],[Json_Updates]) VALUES ";
                query += " (@Id_WorkItem, @Id_Update, @Json_Updates) ";

                _parameters(_objectToQuery, query);

                conncetion.ExecuteQueries(cmd);
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
        public dynamic UpdateWorkItemUpdate(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;

            try
            {
                String query = "UPDATE [dbo].[TFS_Updates]";
                query += " SET [Json_WorkItem] = @Json_WorkItem ";
                query += " WHERE [Id_WorkItem] = @Id_WorkItem AND [Id_Update] = @Id_Update ";

                _parameters(_objectToQuery, query);

                conncetion.ExecuteQueries(cmd);

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

            int IdWorkItem = Convert.ToInt32(_objectToQuery.IdWorkItem);
            int IdWIUpdate = Convert.ToInt32(_objectToQuery.IdAuxiliar);
            string JsonWorkItem = _objectToQuery.JsonWorkItem;
            DateTime DtRegistro = Convert.ToDateTime(_objectToQuery.DtRegistro);

            cmd.Parameters.Add("@Id_WorkItem", SqlDbType.Int);
            cmd.Parameters["@Id_WorkItem"].Value = Convert.ToInt32(IdWorkItem);

            cmd.Parameters.Add("@Id_Update", SqlDbType.Int);
            cmd.Parameters["@Id_Update"].Value = IdWIUpdate;

            cmd.Parameters.Add("@Json_Updates", SqlDbType.NVarChar, -1);
            cmd.Parameters["@Json_Updates"].Value = JsonWorkItem;

        }

    }
}