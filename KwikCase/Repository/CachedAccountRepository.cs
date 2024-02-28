using Kwik.Repository;
using KwikCase.Context;
using KwikCase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace KwikCase.Repository
{
    public class CachedAccountRepository : IAccountRepository
    {
        private readonly AccountRepo _decorated;
        private readonly IDistributedCache _redisCache;

        public CachedAccountRepository(AccountRepo decorated, IDistributedCache memory)
        {
            _decorated = decorated;
            _redisCache = memory;
        }

        public bool Add(Account entity)
        {
            return _decorated.Add(entity);
        }

        public bool Delete(Account entity)
        {
            return _decorated.Delete(entity);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            string? cachedAccount = await _redisCache.GetStringAsync("all");


            IEnumerable<Account?> accounts;
            if (string.IsNullOrEmpty(cachedAccount))
            {
                accounts = await _decorated.GetAll();


                await _redisCache.SetStringAsync("all", JsonConvert.SerializeObject(accounts), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
                });

                if (accounts != null)
                {
                    return accounts;
                }

            }

            return JsonConvert.DeserializeObject<IEnumerable<Account>>(cachedAccount, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });

        }

        public Account? GetByID(string id)
        {
            return _decorated?.GetByID(id);
        }

        public async Task<Account?> GetByIDAsync(string id)
        {
            string? cachedAccount = await _redisCache.GetStringAsync(id);

            Account? account;
            if(string.IsNullOrEmpty(cachedAccount))
            {
                account = await _decorated.GetByIDAsync(id);


                await _redisCache.SetStringAsync(id, JsonConvert.SerializeObject(account), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
                });

                if (account != null)
                {
                    return account;
                }

            }

            return JsonConvert.DeserializeObject<Account>(cachedAccount, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });
        }

        public void Update(Account entity)
        {
            _decorated.Update(entity);
        }
    }
}
