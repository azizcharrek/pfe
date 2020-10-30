using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Hosting;
using System.Web.Http;


[assembly: OwinStartup(typeof(Web.Startup))]
namespace Web

{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);
          //  GlobalConfiguration.Configure(WebApiConfig.Register);
            WebApiConfig.Register(config);
          //  app.UseCors( CorsOptions.AllowAll);
            //options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            app.UseWebApi(config);

          



        }

        public void ConfigureAuth(IAppBuilder app)
        {
              OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
              {
                  TokenEndpointPath = new PathString("/token"),
                  Provider = new MyAuthorizationServerProvider(),
                  AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                  AllowInsecureHttp = true
              };
              app.UseOAuthAuthorizationServer(option);
              app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

          }
  }}