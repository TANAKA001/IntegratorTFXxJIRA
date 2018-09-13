using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Repository
{
    public class RevisionsRepository
    {

        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        SqlCommand cmd;
        public Dictionary<int, string> ConsultaWorkItemRevisions(string idWI)
        {
            string query = "Select ID_Revision  from [dbo].[TFS_Revisions] Where id_workitem = @Id_WorkItem Order By 1 desc";

            Dictionary<int, string> _retorno = new Dictionary<int, string>();
            _retorno = conncetion._dicionarioRevisionData(query, Convert.ToInt32(idWI));

            return _retorno;
        }
        public dynamic InsertWorkItemRevision(List<ObjectToQuery> _objectToQueryList)
        {

            bool _executado = false;

            try
            {
                foreach (var item in _objectToQueryList)
                {
                    String query = " INSERT INTO [dbo].[TFS_Revisions]  ";
                    query += " ([Id_WorkItem],[Id_Revision],[Json_Revisions] ) VALUES ";
                    query += " (@Id_WorkItem, @Id_Revision, @Json_Revisions ) ";

                    _parameters(item, query);

                    conncetion.ExecuteQueries(cmd);
                }

                return new
                {
                    _executado = true
            };
            }
            catch (Exception e)
            {

                return new
                {
                    erro = e,
                   _executado
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