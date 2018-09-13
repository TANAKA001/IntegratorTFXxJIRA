using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TFS_Dashboard.Repository.Context;
using TFS_Dashboard.Repository.Model;

namespace TFS_IntegradoraWeb.View.Shared
{
    public class MainController : ApiController
    {

        //private readonly string adm = ConfigurationManager.AppSettings["ADMINISTRADORES"];
        //private readonly string sup = ConfigurationManager.AppSettings["SUPERVISORES"];

        private DashboardDatabase db = new DashboardDatabase();

        private List<string> Administradores()
        {
            List<string> _admin = new List<string>();
            _admin.Add("GABRIELARRIGONI");
            _admin.Add("BRUNORIBEIRO");
            _admin.Add("DANIELKHING");

            return _admin;
        }
        private List<string> Supervisores()
        {
            List<string> _sup = new List<string>();
            foreach (string admin in Administradores())
            {
                _sup.Add(admin);
            }
            _sup.Add("JOHANN");
            _sup.Add("RAMONDELEMOS");
            _sup.Add("JREYES");
            _sup.Add("JREYES");
            _sup.Add("RODRIGOJORGE");
            _sup.Add("LUCIOBARBOSA");
           

            return _sup;
        }

        [HttpPost]
        public dynamic validaUsuario()
        {
            var _login = Environment.UserName.ToUpper();
            List<dynamic> acesso = new List<dynamic>();

            if (Administradores().Contains(_login))
            {
                acesso.Add(new { Incluir = true, Editar = true, Dividir = true, Apagar = true });


            }
            else if (Supervisores().Contains(_login))
            {
                acesso.Add(new { Incluir = true, Editar = true, Dividir = true, Apagar = false });
            }

            return new {
                acesso
            };
        }
    }
}