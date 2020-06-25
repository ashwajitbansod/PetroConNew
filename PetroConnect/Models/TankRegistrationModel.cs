using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class TankRegistrationModel
    {
        [Required]
        public string Action { get; set; }
        public long TNK_Id { get; set; }
        [Required]
        public long TNK_UID_UserId { get; set; }
        [Required] public string TNK_Name { get; set; }
        [Required] public string TNK_FuelType { get; set; }
        [Required]
        public int? TNK_Capacity { get; set; }
       // public DateTime TNK_DeActive { get; set; }
        public string TNK_IsActive { get; set; }
        public decimal? TNK_FuelStock { get; set; }
    }
    public class TankModel
    {
        public long TNK_Id { get; set; }
        public long TNK_UID_UserId { get; set; }
        public string TNK_Name { get; set; }
        public string TNK_FuelType { get; set; }
        public int? TNK_Capacity { get; set; }
        public decimal TNK_FuelStock { get; set; }

        public string TNK_IsActive { get; set; }
        //public DateTime? TNK_DeActive { get; set; }
    }
         
}
