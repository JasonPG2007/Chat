using DataAccess;
using ObjectBusiness;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account Login(string userName, string password) => AccountDAO.Instance.Login(userName, password);
    }
}
