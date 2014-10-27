using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RedisChatApp.Startup))]

namespace RedisChatApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.UseRedis("localhost", 6379, string.Empty, "myChatApp");
            app.MapSignalR();
        }
    }
}
