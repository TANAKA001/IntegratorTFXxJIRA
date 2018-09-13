using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TFS_ConsoleIntegrador.DAO;
using TFS_ConsoleIntegrador.QuerryModels;

namespace TFS_ConsoleIntegrador.Repository
{
    public class WorkItemRepository
    {

        TFSIntegradoraConnection conncetion = new TFSIntegradoraConnection();
        LogProcessamentoRepository _LogReg = new LogProcessamentoRepository();
        SqlCommand cmd;
        public Dictionary<int, string> ConsultaWorkItem()
        {
            string query = "SELECT Id_WorkItem FROM [dbo].[TFS_WorkItem] WHERE Ativo = 1 Order By 1 desc";

            Dictionary<int, string> _retorno = new Dictionary<int, string>();
            _retorno = conncetion._dicionarioWorkItemData(query);

            return _retorno;
        }

        public void InsertWorkItem(string idWI, string _dataWI, int ativo)
        {
            string _dataRegistro = DateTime.Now.ToString();

            ObjectToQuery _objectToQuery = new ObjectToQuery();
            _objectToQuery.IdWorkItem = idWI;
            _objectToQuery.JsonWorkItem = _dataWI;
            _objectToQuery.Ativo = ativo;

            try
            {
                String query = " INSERT INTO [dbo].[TFS_WorkItem] ";
                query += " ([Id_WorkItem],[Json_WorkItem], [Ativo] ) VALUES";
                query += " (@Id_WorkItem, @Json_WorkItem, @Ativo ) ";

                _parameters(_objectToQuery, query);
                conncetion.ExecuteQueries(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateWorkItem(string idWI, string _dataWI, int ativo)
        {

            string _dataRegistro = DateTime.Now.ToString();
            ObjectToQuery _objectToQuery = new ObjectToQuery();

            _objectToQuery.IdWorkItem = idWI;
            _objectToQuery.JsonWorkItem = _dataWI;
            _objectToQuery.Ativo = ativo;

            try
            {
                String query = "UPDATE [dbo].[TFS_WorkItem]";
                query += "SET [Json_WorkItem] = @Json_WorkItem,  [Ativo] = @Ativo ";
                query += "WHERE [Id_WorkItem] = @Id_WorkItem ";

                _parameters(_objectToQuery, query);

                conncetion.ExecuteQueries(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal void DeleteWorkItem(List<int> idWIList, int ativo)
        {
            ObjectToQuery _objectToQuery = new ObjectToQuery();

            _objectToQuery.Ativo = ativo;
            StringBuilder idsToDelete = new StringBuilder();
            try
            {
                foreach (var item in idWIList)
                {
                    idsToDelete.Append(item);
                }
                String query = "UPDATE [dbo].[TFS_WorkItem]";
                query += "SET [Ativo] = @Ativo ";
                query += "WHERE [Id_WorkItem] in (" + idsToDelete + ")";

                _parameters(_objectToQuery, query);

                conncetion.ExecuteQueries(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExecAtualizaWorkItemSP()
        {
            try
            {
                string sp_AtualizaWorItem = "usp_AtualizaStatusWorkItens";

                cmd = new SqlCommand(sp_AtualizaWorItem);

                conncetion.ExecuteQueries(cmd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void _parameters(ObjectToQuery _objectToQuery, string query)
        {
            cmd = new SqlCommand(query);

            int IdWorkItem = Convert.ToInt32(_objectToQuery.IdWorkItem);
            string JsonWorkItem = _objectToQuery.JsonWorkItem;
            DateTime DtRegistro = Convert.ToDateTime(_objectToQuery.DtRegistro);
            int FlgAtivo = _objectToQuery.Ativo;

            cmd.Parameters.Add("@Id_WorkItem", SqlDbType.Int);
            cmd.Parameters["@Id_WorkItem"].Value = IdWorkItem;

            cmd.Parameters.Add("@Json_WorkItem", SqlDbType.NVarChar, -1);
            cmd.Parameters["@Json_WorkItem"].Value = JsonWorkItem;

            cmd.Parameters.Add("@Ativo", SqlDbType.Bit);
            cmd.Parameters["@Ativo"].Value = JsonWorkItem;
        }

    }
}