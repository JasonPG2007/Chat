using ObjectBusiness;

namespace DataAccess
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        private static readonly object Lock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        public Account Login(string userName, string password)
        {
            using var context = new ChatDbContext();
            var user = context.Account.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            return user;
        }
    }
}
