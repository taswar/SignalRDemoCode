using System;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNet.SignalR;

namespace ConsoleHost
{
    public class HiroHub : Hub
    {

        private Timer t = null;

        public override Task OnConnected()
        {
            if (t == null)
            {
                t = new Timer(1000);

                t.Elapsed += (s, e) =>
                {
                    Clients.All.showTime(DateTime.Now.ToString("hh:mm:ss"));
                };

                t.Start();
            }            


            Console.WriteLine("Someone connected");

            return base.OnConnected();
        }
    }
}