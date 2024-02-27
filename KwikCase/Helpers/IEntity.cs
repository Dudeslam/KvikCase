namespace KwikCase.Helpers
{
    public interface IEntity
    {
        int UserId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Sex { get; set; }

        string Email { get; set; }

        string Phone { get; set; }

        DateTime DateOfBirth { get; set; }

        string Profession { get; set; }
    }
}
