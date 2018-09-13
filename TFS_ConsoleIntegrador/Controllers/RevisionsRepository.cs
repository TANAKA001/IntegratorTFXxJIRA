using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Controllers
{
    public class RevisionsRepository : TfsIntegradora
    {

        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        SqlCommand cmd;

        public Dictionary<int, string> ConsultaWorkItemRevisions(string idWI)
        {
            string query = "Select ID_Revision , DT_Registro from " + tabelaRevision + " Where id_workitem = @Id_WorkItem Order By 1 desc";

            Dictionary<int, string> _retorno = new Dictionary<int, string>();
            _retorno = conncetion._dicionarioRevisionData(query, Convert.ToInt32(idWI));

            return _retorno;
        }

        public dynamic InsertWorkItemRevision(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;

            try
            {
                String query = " INSERT INTO [dbo].[" + tabelaRevision + "] ";
                query += " ([Id_WorkItem],[Id_Revision],[Json_Revisions] ) VALUES ";
                query += " (@Id_WorkItem, @Id_Revision, @Json_Revisions ) ";

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
        public dynamic UpdateWorkItemRevision(ObjectToQuery _objectToQuery)
        {
            bool _executado = false;
            try
            {
                String query = "UPDATE [dbo].[TFS_Revisions]";
                query += " SET [Json_Revisions] = @Json_Revisions , [Dt_Registro] = @Dt_Registro ";
                query += " WHERE [Id_WorkItem] = @Id_WorkItem AND [Id_Revision] = @Id_Revision ";
                
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
            int IdWIRevision = Convert.ToInt32(_objectToQuery.IdAuxiliar);
            string JsonWorkItem = _objectToQuery.JsonWorkItem;
            DateTime DtRegistro = Convert.ToDateTime(_objectToQuery.DtRegistro);

            cmd.Parameters.Add("@Id_WorkItem", SqlDbType.Int);
            cmd.Parameters["@Id_WorkItem"].Value = Convert.ToInt32(IdWorkItem);

            cmd.Parameters.Add("@Id_Revision", SqlDbType.Int);
            cmd.Parameters["@Id_Revision"].Value = IdWIRevision;

            cmd.Parameters.Add("@Json_Revisions", SqlDbType.NVarChar, -1);
            cmd.Parameters["@Json_Revisions"].Value = JsonWorkItem;

        }
    }
}