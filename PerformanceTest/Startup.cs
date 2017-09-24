using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using PerformanceTest.App_Start;

[assembly: OwinStartup(typeof(PerformanceTest.Startup))]

namespace PerformanceTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            Register(config);
            config.EnsureInitialized();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            app.UseWebApi(config);

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //      json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
