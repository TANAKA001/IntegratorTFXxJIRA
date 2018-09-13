using System;
using TFS_ConsoleIntegrador.Controller;
using TFS_ConsoleIntegrador.QuerryModels;
using TFS_ConsoleIntegrador.Repository;

namespace TFS_ConsoleIntegrador
{
    class Program
    {
        static TFS_Integrador _integrador = new TFS_Integrador();

        static void Main(string[] args)
        {
            GetDataTFS();
        }

        private static void GetDataTFS()
        {
            try
            {
                _integrador.GetTfsData();
                _integrador.ProcessRegistration(DateTime.Now);        
                _integrador.AtualizaWorkItemSP();

            }
            catch (Exception e)
            {
                string erro = e.Message.ToString();
                string etapa = e.StackTrace.ToString();
                
                _integrador.RegisterLog(erro, etapa);
            }
        }
    }
}
