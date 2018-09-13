using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brq.com.TFSDashboard.Web.Controllers
{
    public class ControlaAcesso
    {
        protected List<string> Administradores() {

            List<string> adms;

            return adms = new List<string>() {"GABRIELARRIGONI","BRUNORIBEIRO"};
        }

        public bool ValidaEntrada() {
            
            return (Administradores().Contains(Environment.UserName)) ? true : false;
        }
    }
}