using EntityFrameworkExtras.EF7;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
 

namespace PetroConnect.API.Models
{
    [StoredProcedure("spSetPlaceOrder")]
    public class PlaceOrderModel
    {
        [Required]
        public long UID_UserId_Owner { get; set; }
        public long UID_UserId_Customer { get; set; }
       
        [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "UT_SaleBucket")]
        public List<SalesBucket> SalesBucket { get; set; }

        public DataTable GetSalesBucket()
        { 
            DataTable table = new DataTable();
            table.Columns.Add("SBK_Id", typeof(long));
            table.Columns.Add("SBK_MNS_Id", typeof(long));
            table.Columns.Add("SBK_SaleType", typeof(string));
            table.Columns.Add("SBK_PRD_Id", typeof(long));
            table.Columns.Add("SBK_Mrp", typeof(decimal));
            table.Columns.Add("SBK_GST", typeof(decimal));
            table.Columns.Add("SBK_Quantity", typeof(decimal));
            table.Columns.Add("SBK_Discount", typeof(decimal));
            table.Columns.Add("SBK_Status", typeof(string));
            table.Columns.Add("SBK_CDD_Id", typeof(decimal));
            table.Columns.Add("SBK_CVD_Id", typeof(decimal));
            table.Columns.Add("SBK_IndentExecutionDate", typeof(DateTime));
            table.Columns.Add("SBK_IsActive", typeof(char));

            foreach(var SalesBucket in SalesBucket)
            {
                DataRow dr = table.NewRow();
                dr["SBK_Id"] = SalesBucket.SBK_Id;
                dr["SBK_MNS_Id"] = SalesBucket.SBK_MNS_Id;
                dr["SBK_SaleType"] = SalesBucket.SBK_SaleType;
                dr["SBK_PRD_Id"] = SalesBucket.SBK_PRD_Id;
                dr["SBK_Mrp"] = SalesBucket.SBK_Mrp;
                dr["SBK_GST"] = SalesBucket.SBK_GST;
                dr["SBK_Quantity"] = SalesBucket.SBK_Quantity;
                dr["SBK_Discount"] = SalesBucket.SBK_Discount;
                dr["SBK_Status"] = SalesBucket.SBK_Status;
                dr["SBK_CDD_Id"] = SalesBucket.SBK_CDD_Id;
                dr["SBK_CVD_Id"] = SalesBucket.SBK_CVD_Id;
                dr["SBK_IndentExecutionDate"] = SalesBucket.SBK_IndentExecutionDate;
                dr["SBK_IsActive"] = SalesBucket.SBK_IsActive;
                table.Rows.Add(dr);
            }
            return table;
        }
    }


    [UserDefinedTableType("UT_SaleBucket")]
    public class SalesBucket
    {
        [UserDefinedTableTypeColumn(1)]
        public long SBK_Id { get; set; }
        [UserDefinedTableTypeColumn(2)]
        public long SBK_MNS_Id { get; set; }
        [UserDefinedTableTypeColumn(3)] 
        public string SBK_SaleType { get; set; }
        [UserDefinedTableTypeColumn(4)] 
        public long SBK_PRD_Id { get; set; }
        [UserDefinedTableTypeColumn(5)] 
        public decimal SBK_Mrp { get; set; }
        [UserDefinedTableTypeColumn(6)] 
        public decimal SBK_GST { get; set; }
        [UserDefinedTableTypeColumn(7)] 
        public decimal SBK_Quantity { get; set; }
        [UserDefinedTableTypeColumn(8)] 
        public decimal SBK_Discount { get; set; }
        [UserDefinedTableTypeColumn(9)] 
        public string SBK_Status { get; set; }
        [UserDefinedTableTypeColumn(10)] 
        public long SBK_CDD_Id { get; set; }
        [UserDefinedTableTypeColumn(11)] 
        public long SBK_CVD_Id { get; set; }
        [UserDefinedTableTypeColumn(12)]
        public DateTime SBK_IndentExecutionDate { get; set; }
        [UserDefinedTableTypeColumn(13)] 
        public string SBK_IsActive { get; set; }
    }




    public class IndentModel
    {
        [Required]
        public long UID_UserId_Owner { get; set; }
        [Required]
        public long LoginId { get; set; }
        [Required]
        public string Roll { get; set; }
        public long SBK_MNS_Id { get; set; }

        public string SBK_SaleType { get; set; }
    }

    public class ConfirmOderModel
    {
        public long INV_Id { get; set; }
        public long ACB_ULA_LoginId { get; set; }/* PaymenTakenBy */
        public List<SalesBucket> SalesBucket { get; set; }
        public DataTable GetSalesBucket()
        {

            DataTable table = new DataTable();
            table.Columns.Add("SBK_Id", typeof(long));
            table.Columns.Add("SBK_MNS_Id", typeof(long));
            table.Columns.Add("SBK_SaleType", typeof(string));
            table.Columns.Add("SBK_PRD_Id", typeof(long));
            table.Columns.Add("SBK_Mrp", typeof(decimal));
            table.Columns.Add("SBK_GST", typeof(decimal));
            table.Columns.Add("SBK_Quantity", typeof(decimal));
            table.Columns.Add("SBK_Discount", typeof(decimal));
            table.Columns.Add("SBK_Status", typeof(string));
            table.Columns.Add("SBK_CDD_Id", typeof(decimal));
            table.Columns.Add("SBK_CVD_Id", typeof(decimal));
            table.Columns.Add("SBK_IndentExecutionDate", typeof(DateTime));
            table.Columns.Add("SBK_IsActive", typeof(char));


            foreach (var SalesBucket in SalesBucket)
            {
                DataRow dr = table.NewRow();
                dr["SBK_Id"] = SalesBucket.SBK_Id;
                dr["SBK_MNS_Id"] = SalesBucket.SBK_MNS_Id;
                dr["SBK_SaleType"] = SalesBucket.SBK_SaleType;
                dr["SBK_PRD_Id"] = SalesBucket.SBK_PRD_Id;
                dr["SBK_Mrp"] = SalesBucket.SBK_Mrp;
                dr["SBK_GST"] = SalesBucket.SBK_GST;
                dr["SBK_Quantity"] = SalesBucket.SBK_Quantity;
                dr["SBK_Discount"] = SalesBucket.SBK_Discount;
                dr["SBK_Status"] = SalesBucket.SBK_Status;
                dr["SBK_CDD_Id"] = SalesBucket.SBK_CDD_Id;
                dr["SBK_CVD_Id"] = SalesBucket.SBK_CVD_Id;
                dr["SBK_IndentExecutionDate"] = SalesBucket.SBK_IndentExecutionDate;
                dr["SBK_IsActive"] = SalesBucket.SBK_IsActive;
                table.Rows.Add(dr);
            }
            return table;
        }
       
      

    }
}
