using System.ComponentModel.DataAnnotations;

namespace CalendarManager.Entities.Entities
{
    public class User
    {
        public User(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Login { get; private set; }

        [Required]
        public string Password { get; private set; }

    }
}