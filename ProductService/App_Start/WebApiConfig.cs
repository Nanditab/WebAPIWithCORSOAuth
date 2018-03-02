using ProductService.Filters;
using ProductService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API configuration and services
           var corsSetting = new EnableCorsAttribute(origins:"*", headers: "*", methods: "OPTIONS");
            config.EnableCors(corsSetting);
            config.Filters.Add(new ProductExceptionFilter());
            config.Services.Add(typeof(IExceptionLogger), new TraceLogger(new System.Diagnostics.TraceSource("APISource", System.Diagnostics.SourceLevels.All)));
            config.Services.Replace(typeof(IExceptionHandler), new ProductExceptionHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
