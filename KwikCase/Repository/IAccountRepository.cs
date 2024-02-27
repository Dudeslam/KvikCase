using KwikCase.Helpers;
using KwikCase.Models;

namespace Kwik.Repository
{
    public interface IAccountRepository
    {
        Account? GetByID(string id);
        IEnumerable<Account> GetAll();
        bool Add(Account entity);
        bool Delete(Account entity);
        void Update(Account entity);
    }
}
