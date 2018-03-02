using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ProductService.Provider
{
    public class oAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //todo check for clientid and secret
            //   context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());
            //my filmsy security check
            var tokenPath = context.OwinContext.Request.Path.ToString();
            if (string.Compare(tokenPath, "/token", true) == 0)
            {
                //need to be in model class
                var SupportedClients = new List<string>
            {
               "http://localhost:54726"
            };

                if (!SupportedClients.Contains(context.OwinContext.Request.Headers.Get("Origin")))
                {
                    context.SetError("Clinet not supported");
                    return Task.FromResult<object>(null);
                }
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var tokenPath = context.OwinContext.Request.Path.ToString();
            if (string.Compare(tokenPath, "/token", true) == 0)
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "http://localhost:54726" });

            }

            IdentityRepository repo = new IdentityRepository();
            var user = repo.FindUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("ivalid_grant", "User couldnt be authentocated");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            identity.AddClaim(new Claim("sub", context.UserName));

            var prop = new AuthenticationProperties(new Dictionary<string, string>
            {
                { "userName", context.UserName }
            });

            var ticket = new AuthenticationTicket(identity, prop);
            context.Validated(ticket);
        }
    }
}