using Kwik.Mappers;
using Kwik.DTO;
using Kwik.Repository;
using KwikCase.Models;

namespace KwikCase.Services
{
    public class AccountService : IAccountService
    {
        private AccountMapper accMapper = new AccountMapper();
        private readonly IAccountRepository _Accountrepository;

        public AccountService(IAccountRepository AccountRepository)
        {
            _Accountrepository = AccountRepository;
        }
        public List<AccountDTO> GetAccounts()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            _Accountrepository.GetAll().ToList().ForEach(x => accounts.Add(new AccountDTO(x.UserId, x.FirstName, x.LastName, x.Sex, x.Email, x.Phone, DateTime.Parse(x.DateOfBirth), x.Profession)));
            return accounts;
        }

        public AccountDTO? GetAccount(string id)
        {
            var accData = _Accountrepository.GetByID(id);
            return accData != null ? AccountMapper.ToDTO(accData) : null;
        }

        public bool UpdateAccount(AccountDTO acc)
        {
            if (_Accountrepository.GetByID(acc.UserId) == null) return false;
            _Accountrepository.Update(AccountMapper.ToAccount(acc));
            return true;
        }

        public bool CreateAccount(AccountDTO acc)
        {
            return _Accountrepository.Add(AccountMapper.ToAccount(acc));
        }

        public bool DeleteAccount(string id)
        {
            var account = _Accountrepository.GetByID(id);
            if (account != null)
            {
                return _Accountrepository.Delete(account);
            }
            return false;
        }
    }
}
