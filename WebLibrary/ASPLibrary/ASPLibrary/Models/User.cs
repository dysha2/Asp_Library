using System.ComponentModel.DataAnnotations;

namespace ASPLibrary.Models
{
    public enum UserType { Proletarian, Gensec };

    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public UserType Role { get; set; }

    }
}
