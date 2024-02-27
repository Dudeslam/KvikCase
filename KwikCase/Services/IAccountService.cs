using Kwik.DTO;

namespace KwikCase.Services
{
    public interface IAccountService
    {

        public List<AccountDTO> GetAccounts();

        public AccountDTO? GetAccount(string id);

        public bool UpdateAccount(AccountDTO acc);

        public bool DeleteAccount(string id);

        public bool CreateAccount(AccountDTO acc);
    }
}
