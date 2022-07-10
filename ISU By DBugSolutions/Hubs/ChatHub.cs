using ISU_By_DBugSolutions.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISU_By_DBugSolutions.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
        
            await Clients.All.SendAsync("receiveMessage", message);
        
    }
}
