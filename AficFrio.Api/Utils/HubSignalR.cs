using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AficFrio.Api.Utils
{
    [AllowAnonymous]
    public class HubSignalR : Hub
    {
        public Task MensagemStatus(string group, string tipomensagem, string mensage)
        {
            return Clients.All.SendAsync(group, tipomensagem, mensage);
        }
    }
}
