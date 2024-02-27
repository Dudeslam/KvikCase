using KwikCase.Context;
using KwikCase.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Kwik.Repository
{
    public class AccountRepo<T> : IAccountRepository<Account> where T : class
    {
        private readonly PersonContext _context = null!;
        private  List<Account> _dbSet = null!;


        public bool Add(Account entity)
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

        public bool Delete(Account entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Account> GetAll()
        {
            var accList = _dbSet.ToList();
            IEnumerable<Account> retList = new List<Account>();
            foreach (var acc in accList)
            {
                new Account
                {
                    UserId = acc.UserId,
                    Sex = acc.Sex,
                    LastName = acc.LastName,
                    FirstName = acc.FirstName,
                    Email = acc.Email,
                };
            }

            return retList;
        }

        public Account? GetByID(string id)
        {
            var account = _dbSet.FirstOrDefault(x => x.UserId == id);
            return account != null ? new Account()
            {
                UserId = account.UserId,
                Sex = account.Sex,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
            } : null;
        }


        public void Update(Account entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
