using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetroConnect.API.Models;
using PetroConnect.Data.Common;
using PetroConnect.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{
    public interface IOrderService
    {
        Task<int> PlaceOrder(PlaceOrderModel obj);
        Task<List<spGetIndent_Result>> GetIndent(IndentModel obj);
        Task<int> SetConfirmOrder(ConfirmOderModel obj);
    }
    public class OrderService : IOrderService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public OrderService(IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _connectContext = connectContext;
        }

        public async Task<List<spGetIndent_Result>> GetIndent(IndentModel obj)
        {
            try
            {
                var sp = Helpers.StringGenerator.GetProcedureParameter(obj, SPConstants.spGetIndent);
                var result = await _connectContext.spGetIndent
                    .FromSqlRaw(sp, obj.UID_UserId_Owner, obj.LoginId, obj.Roll, obj.SBK_MNS_Id, obj.SBK_SaleType)
                    .ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SpRegistrationTeam ", ex);
                return new List<spGetIndent_Result>();
            }

        }

        public async Task<int> PlaceOrder(PlaceOrderModel obj)
        {
            try
            {
                var sp = Helpers.StringGenerator.GetProcedureParameter(3, SPConstants.spSetPlaceOrder);
                var parameter = new SqlParameter("@UT_SaleBucket", System.Data.SqlDbType.Structured)
                {
                    Value = obj.GetSalesBucket(),
                    TypeName = "[UT_SaleBucket]"
                };
                var result = await _connectContext.spSetPlaceOrder.FromSqlRaw(sp, obj.UID_UserId_Owner, obj.UID_UserId_Customer, parameter).ToListAsync();

                return result.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling PlaceOrder ", ex);
                return 0;
            }

        }

        public async Task<int> SetConfirmOrder(ConfirmOderModel obj)
        {
            try
            {
                var spTable = obj.GetSalesBucket();
                var parameter = new SqlParameter("@UT_SaleBucket", System.Data.SqlDbType.Structured)
                {
                    Value = spTable,
                    TypeName = "[UT_SaleBucket]"
                };
                var sp = Helpers.StringGenerator.GetProcedureParameter(3, SPConstants.spSetConfirmOrder);
                var result = await _connectContext.spSetConfirmOrder.FromSqlRaw(sp, obj.INV_Id, parameter, obj.ACB_ULA_LoginId).ToListAsync();


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
