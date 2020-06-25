using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PetroConnect.Models
{
    public class AuthModel
    {
        public string isAdmin;

        public string FullName { get; set; }
        public int UserId { get; set; }
        public int Role { get; set; }
        public string IsAdmin { get; set; }

        public string Token;
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int Role { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
    }

    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}