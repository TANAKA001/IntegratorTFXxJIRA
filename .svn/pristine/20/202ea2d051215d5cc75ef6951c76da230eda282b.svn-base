using Jira_ConsoleIntegrador.Controler;
using System;
using TFS_Dashboard.Repository.Model;
using TFS_Dashboard.Repository.Repository;

namespace Jira_ConsoleIntegrador
{
    class Program
    {
        static JIRA_Listner _JIRA = new JIRA_Listner();
       
        static void Main(string[] args)
        {
            CallGetDataJIRA();
        }
        private static void CallGetDataJIRA()
        {
            try
            {
                _JIRA.GetDataJIRA();
                _JIRA.ProcessRegistration(DateTime.Now); //Alterar para a tabela dbo.Parametro
            }
            catch (Exception e)
            {
                string erro = e.Message.ToString();
                string etapa = e.StackTrace.ToString();

                LogProcessamento logModel = new LogProcessamento
                {
                    dscErroProcessamento = erro,
                    etapaProcessamento = etapa,
                    flgErroProcessamento = true,
                    dtProcessamento = DateTime.Now
                };

                LogProcessamentoRepository _LogReg = new LogProcessamentoRepository();
                _LogReg.InsertLogProcessamento(logModel);
            }
        }
    }
}
