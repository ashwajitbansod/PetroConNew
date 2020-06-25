using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class UserModel
    {
    }

    public class UserRegistrationModel
    {
        [Required]
        public string Action { get; set; }  // -I:Insert / U:Update
        public long UID_UserId { get; set; }

        [Required]
        public string UID_CompanyName { get; set; }  // - For Owner(pump Owner) /Customer(cr.Customer) /Supplier(Depot) / SalesTeam Name
        public string UID_PumpRegNumber { get; set; } // - for pump owner only
        public string UID_OilCompany { get; set; }// - IndianOil / HP / Reliance / Essar
        public string UID_Address { get; set; }    // - Company Address

        [Required]
        public int UID_STM_StateId { get; set; }// -
        [Required]
        public int UID_CTM_CityCode { get; set; } // -
        public int UID_Pin { get; set; }
        [Required]
        public string UID_UserType { get; set; }   // -GBC:GBC_Code :UserType Like(Owner/Customer/Supplier)/Sales/SupAdm
        [Required]
        public long UID_MobileNumber { get; set; }  // - Registered mobile number(that will be LoginId also)
        public string UID_eMail { get; set; }
        public string UID_GSTIN { get; set; }
        public string UID_PAN { get; set; }
        [Required]
        public long UID_TIN { get; set; }
        public string UID_CIN { get; set; }
        public DateTime UID_ValidFrom { get; set; }
        public DateTime UID_ValidThru { get; set; }
        public string ULA_FirstName { get; set; }
        public string ULA_LastName { get; set; }
        public string ULA_Photo { get; set; }


    }

    public class TeamModel
    {
        [Required]
        public string Action { get; set; }
        [Required]
        public long ULA_UID_UserId { get; set; }//-- ref from UserInfoDetail
        [Required]
        public string ULA_Roll { get; set; }
        [Required]
        public long ULA_LoginId { get; set; }//--Mobile Number
        [Required]
        public string ULA_FirstName { get; set; }
        public string ULA_LastName { get; set; }
        public string ULA_Photo { get; set; }
    }
    public class UserActivateModel
    {
        public string IsActive { get; set; }  // -I:Insert / U:Update
        public long UID_UserId { get; set; }
    }

    public class TeamActivateModel
    {
        public string ULA_IsActive { get; set; }  // -I:Insert / U:Update
        public long ULA_UserId { get; set; }
        public long ULA_LoginId { get; set; }
    }
}
