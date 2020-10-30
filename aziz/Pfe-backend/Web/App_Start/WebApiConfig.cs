using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
              EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");//origins,headers,methods 
                                                              // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();
             config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );
            
             config.Formatters.Remove(config.Formatters.XmlFormatter);
              config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new
              MediaTypeHeaderValue("application/json"));
            config.Filters.Add(new AuthorizeAttribute());

        }

    }
}
