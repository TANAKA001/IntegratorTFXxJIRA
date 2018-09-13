using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Controllers
{
    public class WorkItemRepository : TfsIntegradora
    {

        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        SqlCommand cmd;
        public Dictionary<int, string> ConsultaWorkItem()
        {
            string query = "Select Id_WorkItem from " + tabelaWorkItem + " Order By 1 desc";

            Dictionary<int, string> _retorno = new Dictionary<int, string>();
            _retorno = conncetion._dicionarioWorkItemData(query);

            return _retorno;
        }

        public dynamic InsertWorkItem(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = " INSERT INTO [dbo].[" + tabelaWorkItem + "] ";
                query += " ([Id_WorkItem],[Json_WorkItem] ) VALUES";
                query += " (@Id_WorkItem, @Json_WorkItem) ";

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

        public dynamic UpdateWorkItem(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;

            try
            {
                String query = "UPDATE [dbo].[TFS_WorkItem]";
                query += "SET [Json_WorkItem] = @Json_WorkItem ";
                query += "WHERE [Id_WorkItem] = @Id_WorkItem ";

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
            string JsonWorkItem = _objectToQuery.JsonWorkItem;
            DateTime DtRegistro = Convert.ToDateTime(_objectToQuery.DtRegistro);

            cmd.Parameters.Add("@Id_WorkItem", SqlDbType.Int);
            cmd.Parameters["@Id_WorkItem"].Value = IdWorkItem;

            cmd.Parameters.Add("@Json_WorkItem", SqlDbType.NVarChar, -1);
            cmd.Parameters["@Json_WorkItem"].Value = JsonWorkItem;

        }
    }
}