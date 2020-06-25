using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class TeamsModel
    {
        public long ULA_LoginId { get; set; }
        public string ULA_FirstName { get; set; }
        public string ULA_LastName { get; set; }
        public string ULA_Roll { get; set; }
        public string ULA_Photo { get; set; }

        public string ULA_IsActive { get; set; }
    }
}
