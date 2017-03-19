using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AspNetMvcDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //to return 'application/json' in response to 'accept: text/html'
            //so that Json shows up in browsers by default, 
            //but applications can still select response type the normal way
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
            .Add(new RequestHeaderMapping("Accept",
                                          "text/html",
                                          StringComparison.InvariantCultureIgnoreCase,
                                          true,
                                          "application/json"));
        }
    }
}
