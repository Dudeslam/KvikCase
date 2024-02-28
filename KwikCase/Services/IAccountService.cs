using Kwik.DTO;

namespace KwikCase.Services
{
    public interface IAccountService
    {

        public Task<List<AccountDTO>> GetAccounts();

        public Task<AccountDTO?> GetAccount(string id);

        public bool UpdateAccount(AccountDTO acc);

        public bool DeleteAccount(string id);

        public bool CreateAccount(AccountDTO acc);
    }
}
