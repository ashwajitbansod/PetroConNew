using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class FuelPriceModel
    {
        public long PRD_Id { get; set; }
        [Required] public long PRD_UID_UserId { get; set; }
        [Required] public decimal PRD_Mrp { get; set; }
    }
}
