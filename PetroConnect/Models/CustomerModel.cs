using System;
using System.ComponentModel.DataAnnotations;

namespace PetroConnect.API.Models
{
    public class CustomerModel
    {
    }
    public class CustomerMappingModel
    {
        public string Action { get; set; }
        public long OCM_Id { get; set; }
        public long OCM_UID_UserId_Owner { get; set; }
        public int OCM_UID_UserId_Customer { get; set; }
        public decimal OCM_CreditLimit { get; set; }
        public int OCM_BillCycleStartDay { get; set; }
        public int OCM_BillCycleDays { get; set; }
        public string OCM_IsActive { get; set; }
        //public string OCM_CompanyName { get; set; }

        //public long OCM_UserId_Customer { get; set; }
        public int? OCM_OpeningBalance { get; set; }
        public string OCM_Refrence { get; set; }
        public long OCM_UpdatedBy { get; set; }
    }
    public class RegistrationTeamModal
    {
        [Required]
        public string Action { get; set; }
        [Required]

        public long ULA_UID_UserId { get; set; }
        [Required]

        public string ULA_Roll { get; set; }
        [Required]

        public long ULA_LoginId { get; set; }
        [Required]

        public string ULA_FirstName { get; set; }

        public string ULA_LastName { get; set; }

    }

    public class GetCustomerModel
    {
        public long OCM_Id { get; set; }
        //public int OCM_UID_UserId_Customer { get; set; }
        public decimal OCM_CreditLimit { get; set; }
        public int OCM_BillCycleStartDay { get; set; }
        public int OCM_BillCycleDays { get; set; }
        public string OCM_IsActive { get; set; }
        public string OCM_CompanyName { get; set; }

        public long OCM_UserId_Customer { get; set; }
        public int? OCM_OpeningBalance { get; set; }
        public string OCM_Refrence { get; set; }
        public long OCM_UpdatedBy { get; set; }
        public long UID_MobileNumber { get; set; }
        public DateTime UID_Date { get; set; }
        public string OCM_Photo { get; set; }
        public string OCM_Name { get; set; }
        public string OCM_GSTIN { get; set; }
        public string OCM_PAN { get; set; }
    }

    public class EditCustomerModel
    {
        public long? OCM_Id { get; set; }
        public long? OCM_UID_UserId_Customer { get; set; }
        //public int OCM_UID_UserId_Customer { get; set; }
        public decimal? OCM_CreditLimit { get; set; }
        public int? OCM_BillCycleStartDay { get; set; }
        public int? OCM_BillCycleDays { get; set; }
        public int? OCM_OpeningBalance { get; set; }
        public string OCM_Refrence { get; set; }
        public long? OCM_UpdatedBy { get; set; }
        public string UID_CompanyName { get; set; }      
        public long UID_MobileNumber { get; set; }
        public string UID_GSTIN { get; set; }
        public string UID_PAN { get; set; }
        public string ULA_Photo { get; set; }
        public string ULA_FirstName { get; set; }
        public string CompanyAction { get; set; }
    }
}
