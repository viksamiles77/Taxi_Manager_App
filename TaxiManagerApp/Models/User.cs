using Models.Enums;

namespace Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; }
        public RoleEnum Role { get; set; }

        public User(int id, string firstName, string lastName, string userName, string password, RoleEnum role)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            SetPassword(password);
            Role = role;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is required");
            }

            if(password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }

            Password = password;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }
    }
}
