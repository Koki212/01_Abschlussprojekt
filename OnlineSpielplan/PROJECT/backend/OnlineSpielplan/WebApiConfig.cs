using System.Web.Http;
namespace OnlineSpielplan
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Enable CORS
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            // Default route
            config.Routes.MapHttpRoute(
                               name: "DefaultApi",
                                              routeTemplate: "api/{controller}/{id}",
                                                             defaults: new
                                                             { id = RouteParameter.Optional}
                                                                        );
        }
    }
}
