using KwikCase.Context;
using KwikCase.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Kwik.Repository
{
    public class AccountRepo : IAccountRepository
    {
        private readonly PersonContext _context = new PersonContext();
        private  List<Account> _dbSet = null!;

        public AccountRepo(PersonContext context)
        {
            _context = context;
            _dbSet = new List<Account>(_context.PersonData.OrderBy(x=>x.UserId));
        }

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
                    DateOfBirth = acc.DateOfBirth,
                    Phone = acc.Phone,
                    Profession = acc.Profession
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
                DateOfBirth = account.DateOfBirth,
                Phone = account.Phone,
                Profession = account.Profession
            } : null;
        }


        public void Update(Account entity)
        {
            var entityToUpdate = _dbSet.FirstOrDefault(x => x.UserId == entity.UserId);
            if (entityToUpdate == null) return;

            _dbSet.Add(entityToUpdate);
            _context.SaveChanges();
        }
    }
}
