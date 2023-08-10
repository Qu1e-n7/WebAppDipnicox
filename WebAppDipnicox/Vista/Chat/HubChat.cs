using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Vista.Chat
{
    public class HubChat : Hub
    {
        public void Chat(string nombre, string mensaje)
        {
            Clients.All.chatLinea(nombre, mensaje);
        }
    }
}