using Kwik.DTO;
using KwikCase.Models;
namespace Kwik.Mappers
{
    public class AccountMapper
    {
        public AccountMapper() { }
        public static AccountDTO ToDTO(Account account)
        {
            return new AccountDTO
            {
                UserId = account.UserId,
                Sex = account.Sex,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                DateOfBirth = DateTime.Parse(account.DateOfBirth),
                Phone = account.Phone,
                Profession = account.Profession,
            };
        }

        public static Account ToAccount(AccountDTO account)
        {
            return new Account
            {
                UserId = account.UserId,
                Sex = account.Sex,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                DateOfBirth = account.DateOfBirth.ToString(),
                Phone = account.Phone,
                Profession = account.Profession,
            };
        }
    }
}
