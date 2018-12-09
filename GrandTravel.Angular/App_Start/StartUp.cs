using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Extensions.DependencyInjection;
using System.Web;

namespace GrandTravel.Angular.App_Start
{
    public class StartUp
    {
        

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Login")
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

                services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieName = ".GrandTravel";
            });
        }
    }
}