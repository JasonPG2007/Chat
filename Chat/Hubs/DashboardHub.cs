using Microsoft.AspNetCore.SignalR;
using Repository;

namespace Chat.Hubs
{
    public class DashboardHub : Hub
    {
        #region Variable
        private readonly IMessageRepository messageRepository;
        #endregion

        #region Constructor
        public DashboardHub()
        {
            messageRepository = new MessageRepository();
        }
        #endregion

        public async Task SendMessage()
        {
            var listMessage = messageRepository.GetMessages();
            await Clients.All.SendAsync("ReceivedMessage", listMessage);
        }
    }
}
