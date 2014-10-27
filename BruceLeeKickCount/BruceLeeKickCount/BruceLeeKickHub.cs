using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BruceLeeKickCount
{
    [HubName("bruceLeeKickHub")]
    public class BruceLeeKickHub : Hub
    {
        private static int _kick;

        public void DropKick()
        {
            _kick++;
            Clients.All.onKicking(_kick);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _kick--;
            Clients.All.onKicking(_kick);
            Clients.User("taswar").onKicking(_kick);
                            return base.OnDisconnected(stopCalled);
        }
    }
}