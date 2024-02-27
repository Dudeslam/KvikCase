using System;
using System.Collections.Generic;

namespace KwikCase.Models
{
    public partial class Account
    {
        public string? Indexo { get; set; }

        public string UserId { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Sex { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? DateOfBirth { get; set; }

        public string? Profession { get; set; }

        public Account(string id, string fName, string sName, string sex, string eMail, string phone, string date, string prof)
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

        public Account() { }
    }
}


