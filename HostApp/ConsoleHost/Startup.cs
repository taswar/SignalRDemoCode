using System.Threading;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Timers;

[assembly: OwinStartup(typeof(ConsoleHost.Startup))]

namespace ConsoleHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
