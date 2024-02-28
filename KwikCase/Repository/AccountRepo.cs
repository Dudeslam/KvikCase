using KwikCase.Context;
using KwikCase.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Kwik.Repository
{
    public class AccountRepo : IAccountRepository
    {
        private readonly PersonContext _context = new PersonContext();
        private static Random rnd = new Random();
        private  List<Account> _dbSet = null!;

        public AccountRepo(PersonContext context)
        {
            _context = context;
            _dbSet = new List<Account>(_context.PersonData.OrderBy(x=>x.UserId));
        }

        public virtual bool Add(Account entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool Delete(Account entity)
        {
            var entityToDelete = _dbSet.FirstOrDefault(x =>  x.UserId == entity.UserId);
            if (entityToDelete == null) return false;

            try
            {
                _context.Attach(entityToDelete);
                _context.Remove(entityToDelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async virtual Task<IEnumerable<Account>> GetAll()
        {
            int nElements = 2000;
            var accList = _dbSet.ToList();
            List<Account> retList = new List<Account>();
            HashSet<int> taken = new HashSet<int>();

            while (taken.Count < nElements)
                taken.Add(rnd.Next(nElements));

            foreach (var index in taken.OrderBy(x => x))
            {
                retList.Add(new Account
                {
                    UserId = accList[index].UserId,
                    Sex = accList[index].Sex,
                    LastName = accList[index].LastName,
                    FirstName = accList[index].FirstName,
                    Email = accList[index].Email,
                    DateOfBirth = accList[index].DateOfBirth,
                    Phone = accList[index].Phone,
                    Profession = accList[index].Profession
                });
            }
            return retList;
        }

        public virtual async Task<Account?> GetByIDAsync(string id)
        {
            return await _context.Set<Account>().FirstOrDefaultAsync(acc => acc.UserId == id);
        }

        public virtual Account? GetByID(string id)
        {
            return _dbSet.FirstOrDefault(acc => acc.UserId == id);
        }

        public virtual void Update(Account entity)
        {
            var entityToUpdate = _dbSet.FirstOrDefault(x => x.UserId == entity.UserId);
            if (entityToUpdate == null) return;

            _dbSet.Add(entityToUpdate);
            _context.SaveChanges();
        }
    }
}
