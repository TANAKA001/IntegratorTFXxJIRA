
using System.Linq;
using System.Web.Http;
using TFS_Dashboard.Repository.Context;


namespace TFS_IntegradoraWeb
{
    public class HomeController : ApiController
    {
        private DashboardDatabase db = new DashboardDatabase();

        public void Index()
        {
            //var lista = db.AcompanhamentoDemanda.ToList().Select(a => new {
            //    a.Qtd_HorasFaturadas,
            //    a.Qtd_HorasTrabalhadas
            //});

            //int Qtd_HorasFaturadas = 0;
            //int Qtd_HorasTrabalhadas = 0;
            //foreach (var item in lista)
            //{
            //   Qtd_HorasFaturadas = item.Qtd_HorasFaturadas != null ? Qtd_HorasFaturadas + item.Qtd_HorasFaturadas.Value : Qtd_HorasFaturadas;
            //   Qtd_HorasTrabalhadas = item.Qtd_HorasTrabalhadas != null ? Qtd_HorasTrabalhadas + item.Qtd_HorasTrabalhadas.Value : Qtd_HorasTrabalhadas;
            //}

            //return View();
        }      
    }
}