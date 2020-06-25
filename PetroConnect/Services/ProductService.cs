using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetroConnect.API.Helpers;
using PetroConnect.API.Models;
using PetroConnect.Data.Common;
using PetroConnect.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{
    public interface IProductService
    {
        public Task<int> SetProductDetailOwner(ProductDetailOwner pro);
        public Task<List<ProductDetailOwnerList>> GetProductDetailOwnerList(long PRD_UID_UserId, string ProductType);
    }
    public class ProductService : IProductService
    {

        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public ProductService(IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _connectContext = connectContext;
        }

        public async Task<List<ProductDetailOwnerList>> GetProductDetailOwnerList(long PRD_UID_UserId, string ProductType)
        {
            var sp = StringGenerator.GetProcedureParameter(2, SPConstants.spGetProductDetailOwner);
            return await _connectContext.spGetProductDetailOwner.FromSqlRaw(sp, PRD_UID_UserId, ProductType).Select(x => new ProductDetailOwnerList
            {
                PRDG_Name = x.PRDG_Name,
                PRDG_HSN = x.PRDG_HSN,
                PRDG_Desc = x.PRDG_Desc,
                PRDG_OilCompany = x.PRDG_OilCompany,
                PRDG_ProductType = x.PRDG_ProductType,
                PRD_Discount = x.PRD_Discount,
                PRD_GST = x.PRD_GST,
                PRD_Id = x.PRD_Id,
                PRD_IsActive = x.PRD_IsActive,
                PRD_Mrp = x.PRD_Mrp
            }).ToListAsync();
        }

        public async Task<int> SetProductDetailOwner(ProductDetailOwner pro)
        {

            try
            {
                var sp = StringGenerator.GetProcedureParameter(pro, SPConstants.spSetProductDetailOwner);
                var result = await _connectContext.spSetProductDetailOwner
                    .FromSqlRaw(sp, pro.Action, pro.PRD_Id, pro.PRD_UID_UserId, pro.PRD_PRDG_Id, pro.PRD_GST, pro.PRD_Mrp, pro.PRD_Discount, pro.PRD_IsActive)
                    .ToListAsync();
                return result.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SpRegistrationTeam ", ex);
                return 0;
            }

        }
    }
}
