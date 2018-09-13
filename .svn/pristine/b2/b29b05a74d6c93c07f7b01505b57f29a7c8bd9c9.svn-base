
using System;
using System.Linq;
using TFS_Dashboard.Repository.Context;
using TFS_Dashboard.Repository.Model;

namespace TFS_Dashboard.Repository.Repository
{
    public class ParametroRepository
    {
        DashboardDatabase db = new DashboardDatabase();

        public void Atualizar(DateTime _dataParamento)
        {
            try
            {
                Parametro _parametro = Selecionar();
                _parametro.Dt_RegistroJira = _dataParamento;

                db.Entry(_parametro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Parametro Selecionar()
        {
            Parametro _jira_WorkItem = db.Parametro.FirstOrDefault<Parametro>();

            return _jira_WorkItem;
        }
    }
}