using KwikCase.Helpers;
using KwikCase.Models;

namespace Kwik.Repository
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIDAsync(string id);
        Account? GetByID(string id);
        Task<IEnumerable<Account>> GetAll();
        bool Add(Account entity);
        bool Delete(Account entity);
        void Update(Account entity);
    }
}
