using System.Linq;
using System.Web.Mvc;
using TFS_Dashboard.Repository.Context;
using TFS_Dashboard.Repository.Model;

namespace brq.com.TFSDashboard.Web.Controllers
{
    public class HomeController : Controller
    {
        private DashboardDatabase db = new DashboardDatabase();

        public ActionResult Index()
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

            return View();
        }      
    }
}