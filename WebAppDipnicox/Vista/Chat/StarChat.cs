using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebAppDipnicox.Vista.Chat.StarChat))]

namespace WebAppDipnicox.Vista.Chat
{
    public class StarChat
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
