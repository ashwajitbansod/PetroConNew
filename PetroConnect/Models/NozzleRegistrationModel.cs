using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class NozzleRegistrationModel
    {
        [Required]
        public string Action { get; set; }
        public long NZL_Id { get; set; }
        [Required] public long NZL_UID_UserId { get; set; }
        public long NZL_TNK_Id { get; set; }
        public long NZL_MCN_Id { get; set; }
        [Required] public string NZL_Name { get; set; }
        //public DateTime NZL_DeActive { get; set; }
        public string NZL_IsActive { get; set; }
    }

    public class NozzleMappingModel
    {
        public string Action { get; set; }
        public long MNS_Id { get; set; }
        public long MNS_UID_UserId { get; set; }
        [Required] public long MNS_NZL_Id { get; set; }
        public long MNS_SSH_Id { get; set; }
        public string MNS_IsActive { get; set; }
    }


    public class ShiftScheduleModal
    {
        [Required]
        public string Action { get; set; }
        public long SSH_Id { get; set; }
        [Required]
        public long SSH_UID_UserId { get; set; }
        [Required]
        public long SSH_ULA_LoginId { get; set; }
        [Required]
        public long SSH_SSL_Id { get; set; }
        [Required]
        public string SSH_IsActive { get; set; }
        public DateTime SchedulefromDate { get; set; }
        public DateTime ScheduleToDate { get; set; }
    }
}
