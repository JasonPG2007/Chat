using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MessageDAO
    {
        private ChatDbContext db;
        private static MessageDAO instance;
        private static readonly object Lock = new object();
        public static MessageDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new MessageDAO();
                    }
                    return instance;
                }
            }
        }
        public MessageDAO()
        {
            db = new ChatDbContext();
        }
        public IEnumerable<Message> GetMessages()
        {
            var listMessage = from a in db.Account
                              join b in db.Message
                              on a.AccountId equals b.AccountId
                              orderby b.DateSend ascending
                              select new Message
                              {
                                  AccountId = a.AccountId,
                                  Avatar = a.Avatar,
                                  MessageId = b.MessageId,
                                  Contents = b.Contents,
                                  DateSend = b.DateSend,
                                  UserName = a.UserName,
                              };
            return listMessage;
        }
        public IEnumerable<Message> GetMessagesByAccountId(int accountId)
        {
            var listMessage = from a in db.Account
                              join b in db.Message
                              on a.AccountId equals b.AccountId
                              where a.AccountId == accountId
                              select new Message
                              {
                                  AccountId = a.AccountId,
                                  Avatar = a.Avatar,
                                  MessageId = b.MessageId,
                                  Contents = b.Contents,
                                  DateSend = b.DateSend,
                              };
            return listMessage;
        }
        public string SendMessage(Message message)
        {
            string status = "error";
            using var context = new ChatDbContext();
            try
            {
                context.Add(message);
                context.SaveChanges();
                status = "success";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
    }
}
