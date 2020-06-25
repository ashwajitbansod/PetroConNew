using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PetroConnect.Data.Context
{


    public class spCommonResponse
    {
        public int Result { get; set; }
    }

    public class Sp_ResultModals
    {

        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public string Address { get; set; }
    }

 
    public class spLogin_Result
    {
        [Key]
        public long ULA_UID_UserId { get; set; }
        public string ULA_Roll { get; set; }
        public string UID_PumpRegNumber { get; set; }
        public string UserName { get; set; }
        public string ULA_Photo { get; set; }
        public int UserCount { get; set; }
    }
 
    public class spLoginNext_Result
    {
        public string UID_PumpRegNumber { get; set; }
    }

  
    public class spSetCustomerMapping_Result_LETITIT
    {
        public string TNK_Id { get; set; }
        public string TNK_Name { get; set; }
        public string TNK_FuelStock { get; set; }
        public string MCN_Id { get; set; }
        public string MCN_Name { get; set; }
        public string NZL_Id { get; set; }
        public string NZL_Name { get; set; }
    }

    public class spSetNozzleRegistration_Result
    {
        public int Result { get; set; }
    }

    public class spGetCity_Result
    {
        public int CTM_STM_StateID { get; set; }
        public string CTM_Name { get; set; }
        public int CTM_CityCode { get; set; }
    }


    public class spGetStateList_Result
    {
        public int STM_StateId { get; set; }
        public string STM_Name { get; set; }
        public int STM_CNM_CountryId { get; set; }
    }
 

    public class spGetIndent_Result
    {
        [Key]
        public long SBK_Id { get; set; }
        public long SBK_INV_Id { get; set; }
        public long SBK_UID_UserId { get; set; }
        public Nullable<long> SBK_UID_UserId_Customer { get; set; }
        public Nullable<long> SBK_MNS_Id { get; set; }
        public string SBK_SaleType { get; set; }
        public long SBK_PRD_Id { get; set; }
        public Nullable<decimal> SBK_Mrp { get; set; }
        public Nullable<decimal> SBK_GST { get; set; }
        public Nullable<decimal> SBK_Quantity { get; set; }
        public Nullable<decimal> SBK_Discount { get; set; }
        public Nullable<decimal> SBK_Rate { get; set; }
        public Nullable<decimal> SBK_Taxable { get; set; }
        public Nullable<decimal> SBK_NetAmount { get; set; }
        public string SBK_Status { get; set; }
        public Nullable<long> SBK_CDD_Id { get; set; }
        public Nullable<long> SBK_CVD_Id { get; set; }
        public Nullable<DateTime> SBK_IndentExecutionDate { get; set; }
        public Nullable<DateTime> SBK_Date { get; set; }
        public string SBK_IsActive { get; set; }
    }

     
    public class spGetGlobalCode_Result
    {

        public long GBC_Code { get; set; }
        public string GBC_Category { get; set; }
        public string GBC_CodeName { get; set; }
        public string GBC_Description { get; set; }
        public int GBC_SortOrder { get; set; }
    }

    public class spGetTankMachineNozzle_Result
    {
        public long TNK_Id { get; set; }
        public string TNK_Name { get; set; }
        public Nullable<decimal> TNK_FuelStock { get; set; }
        public long MCN_Id { get; set; }
        public string MCN_Name { get; set; }
        public long NZL_Id { get; set; }
        public string NZL_Name { get; set; }
    }
    public class spGetMachine_Result
    {
        [Key]
        public long MCN_UID_UserId { get; set; }
        public long MCN_Id { get; set; }
        public string MCN_Name { get; set; }
        public string MCN_IsActive { get; set; }
    }

    public class spGetProductDetailOwner_Result
    {
        public long PRD_Id { get; set; }
        public string PRDG_Name { get; set; }
        public string PRDG_Desc { get; set; }
        public string PRDG_HSN { get; set; }
        public decimal PRD_GST { get; set; }
        public decimal PRD_Mrp { get; set; }
        public decimal PRD_Discount { get; set; }
        public string PRD_IsActive { get; set; }
        public string PRDG_ProductType { get; set; }
        public string PRDG_OilCompany { get; set; }
    }

    public class spGetCustomerDetails_Result
    {
        public long OCM_Id { get; set; }
        public long OCM_UID_UserId_Customer { get; set; }
        public string UID_CompanyName { get; set; }
        public decimal OCM_CreditLimit { get; set; }
        public int OCM_BillCycleStartDay { get; set; }
        public int OCM_BillCycleDays { get; set; }
        public string OCM_IsActive { get; set; }
        public int? OCM_OpeningBalance { get; set; }
        public string OCM_Refrence { get; set; }
        public long UID_MobileNumber { get; set; }
        public DateTime UID_Date { get; set; }
        public string ULA_Photo { get; set; }
        public string Name { get; set; }
        public string UID_GSTIN { get; set; }
        public string UID_PAN { get; set; }
    }
    public class spGetTeamDetails_Result
    {
        public long ULA_LoginId { get; set; }
        public string ULA_FirstName { get; set; }
        public string ULA_LastName { get; set; }
        public string ULA_Roll { get; set; }
        public string ULA_Photo { get; set; }
        public string ULA_IsActive { get; set; }
    }
    //Get Tanks
    public class spGetTank_Result
    {
        public long TNK_Id { get; set; }
        public long TNK_UID_UserId { get; set; }
        public string TNK_Name { get; set; }
        public string TNK_FuelType { get; set; }
        public int? TNK_Capacity { get; set; }
        public decimal TNK_FuelStock { get; set; }
        //public DateTime? TNK_DeActive { get; set; }
        public string TNK_IsActive { get; set; }
    }
}