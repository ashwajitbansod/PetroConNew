using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PetroConnect.API.Models
{
    

    public class MachineRegistrationModel
    {
        [Required]
        public string Action { get; set; }
        public long MCN_Id { get; set; }
        [Required] public long MCN_UID_UserId { get; set; }
        [Required] public string MCN_Name { get; set; }
        //public DateTime MCN_DeActive { get; set; }
        public string MCN_IsActive { get; set; }
    }


    public class MachineModel
    {
        public long MCN_UID_UserId { get; set; }
        public string MCN_Name { get; set; }
        public string MCN_DeActive { get; set; }
    }
    public class MachineModelList
    {
        public long MCN_UID_UserId { get; set; }
        public long MCN_Id { get; set; }
        public string MCN_Name { get; set; }
        public string MCN_IsActive { get; set; }
    }
    public class GetTankMachineNozzleModel
    {
        public long TNK_Id { get; set; }
        public string TNK_Name { get; set; }
        public Nullable<decimal> TNK_FuelStock { get; set; }
        public long MCN_Id { get; set; }
        public string MCN_Name { get; set; }
        public long NZL_Id { get; set; }
        public string NZL_Name { get; set; }
    }
}
