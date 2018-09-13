using System.Web.Http;

namespace ons.pdp.iu.web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Views/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
