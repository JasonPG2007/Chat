using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MessageRepository : IMessageRepository
    {
        public IEnumerable<Message> GetMessages() => MessageDAO.Instance.GetMessages();
        public IEnumerable<Message> GetMessagesByAccountId(int accountId) => MessageDAO.Instance.GetMessagesByAccountId(accountId);
        public string SendMessage(Message message) => MessageDAO.Instance.SendMessage(message);
    }
}
