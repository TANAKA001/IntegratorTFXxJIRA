using System;
using System.Data;
using System.Data.SqlClient;
using TFS_Dashboard.Repository.Context;
using TFS_Dashboard.Repository.Model;

namespace TFS_Dashboard.Repository.Repository
{
    public class LogProcessamentoRepository
    {
        DashboardDatabase db = new DashboardDatabase();

        public LogProcessamentoRepository()
        {
        }

        public dynamic InsertLogProcessamento(LogProcessamento logProcessamento)
        {
            bool _executado = false;
            try
            {
                db.LogProcessamento.Add(logProcessamento);

                db.SaveChanges();

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
    }
}
