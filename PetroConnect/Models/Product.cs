using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Models
{
    public class Product
    {
    }

    public class ProductDetailOwner
    {
        [Required]
        public string Action { get; set; }
        public long PRD_Id { get; set; }
        [Required]

        public long PRD_UID_UserId { get; set; }
        [Required]
        public long PRD_PRDG_Id { get; set; }
        [Required]
        public decimal PRD_GST { get; set; }
        [Required]
        public decimal PRD_Mrp { get; set; }
        [Required]
        public decimal PRD_Discount { get; set; }
        public string PRD_IsActive { get; set; }
    }


    public class ProductDetailOwnerList
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
}
