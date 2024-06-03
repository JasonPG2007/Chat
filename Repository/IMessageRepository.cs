using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMessageRepository
    {
        public IEnumerable<Message> GetMessages();
        public IEnumerable<Message> GetMessagesByAccountId(int accountId);
        public string SendMessage(Message message);
    }
}
