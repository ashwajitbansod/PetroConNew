using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.Auth.Models
{
    public class Common
    {
    }

    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UID_PumpRegNumber { get; set; }

        public string Token { get; set; }
        public string Role { get; set; }
        public string ProfileImage { get; set; }

        public int UserCount { get; set; }


        public List<PumpModal> Pumps { get; set; }

    }

    public class PumpModal
    {
        public string UID_PumpRegNumber { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }
        public string ClientAppUrl { get; set; }
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
