namespace Kwik.DTO
{
    public class AccountDTO
    {
        public string UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Sex { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        public string Profession { get; set; } = string.Empty;

        public AccountDTO() { }

        public AccountDTO(string id, string fName, string sName, string sex, string eMail, string phone, DateTime date, string prof)
        {
            UserId = id;
            FirstName = fName;
            LastName = sName;
            Sex = sex;
            Email = eMail;
            Phone = phone;
            DateOfBirth = date;
            Profession = prof;
        }
    }
}
