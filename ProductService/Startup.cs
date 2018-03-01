using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProductService.Provider;

[assembly: OwinStartup(typeof(ProductService.Startup))]
namespace ProductService
{
    public class Startup
    {
        #region -- Properties --
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        #endregion
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            //set up auth settings
            ConfigureoAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase, true, "application/json"));
        }

        public void ConfigureoAuth(IAppBuilder app)
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            OAuthAuthorizationServerOptions oAuthServer = new OAuthAuthorizationServerOptions()
            {


                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),               
                Provider = new oAuthProvider()
            };

            //token generation
            app.UseOAuthAuthorizationServer(oAuthServer);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }

    
}