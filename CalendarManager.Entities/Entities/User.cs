using System.ComponentModel.DataAnnotations;

namespace CalendarManager.Entities.Entities
{
    public class User
    {
        public User( string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Username { get; private set; }

        [Required]
        public string Password { get; private set; }

        public User HidePassword(string password)
        {
            Password = password;
            return this;
        }

    }
}