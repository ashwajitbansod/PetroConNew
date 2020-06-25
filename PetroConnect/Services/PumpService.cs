using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetroConnect.API.Helpers;
using PetroConnect.API.Models;
using PetroConnect.Data.Common;
using PetroConnect.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{
    public interface IPumpService
    {
        Task<int> SetDailyUpdateFuelPrice(FuelPriceModel fuelPrice);
        Task<int> MachineRegistration(MachineRegistrationModel obj);
        Task<int> NozzleRegistration(NozzleRegistrationModel obj);
        Task<List<GetTankMachineNozzleModel>> GetTankMachineNozzle(long UserId);
    }

    public class PumpService : IPumpService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public PumpService(IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _connectContext = connectContext;
        }
        public async Task<int> SetDailyUpdateFuelPrice(FuelPriceModel fuelPrice)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(fuelPrice, SPConstants.spSetDailyUpdateFuelPrice);
                var result = await _connectContext.spSetDailyUpdateFuelPrice
                    .FromSqlRaw(sp, fuelPrice.PRD_Id, fuelPrice.PRD_UID_UserId, fuelPrice.PRD_Mrp)
                    .ToListAsync();
                return result.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SpRegistrationTeam ", ex);
                return 0;
            }
        }

        public async Task<int> MachineRegistration(MachineRegistrationModel obj)
        {
            try
            {
                var sp = PetroConnect.API.Helpers.StringGenerator.GetProcedureParameter(obj, SPConstants.spSetMachineRegistration);
                var result = await _connectContext.spSetMachineRegistration.FromSqlRaw(sp, obj.Action, obj.MCN_Id, obj.MCN_UID_UserId, obj.MCN_Name, obj.MCN_IsActive).ToListAsync();
                return result.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SpRegistrationTeam ", ex);
                return 0;
            }

        }

        public async Task<List<GetTankMachineNozzleModel>> GetTankMachineNozzle(long UserId)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(1, SPConstants.spGetTankMachineNozzle);
                var res = await _connectContext.spGetTankMachineNozzle
                    .FromSqlRaw(sp, UserId)
                    .Select(item => new GetTankMachineNozzleModel
                    {
                        MCN_Id = item.MCN_Id,
                        MCN_Name = item.MCN_Name,
                        NZL_Id = item.NZL_Id,
                        NZL_Name = item.NZL_Name,
                        TNK_FuelStock = item.TNK_FuelStock,
                        TNK_Id = item.TNK_Id,
                        TNK_Name = item.TNK_Name
                    })
                    .ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SetTankRegistration ", ex);
                return null;
            }
        }

        public async Task<int> NozzleRegistration(NozzleRegistrationModel obj)
        {
            try
            {
                var spExecue = Helpers.StringGenerator.GetProcedureParameter(obj, SPConstants.spSetNozzleRegistration);
                var res = await _connectContext.spSetNozzleRegistration
                    .FromSqlRaw(spExecue, obj.Action, obj.NZL_Id, obj.NZL_UID_UserId, obj.NZL_TNK_Id, obj.NZL_MCN_Id, obj.NZL_Name,  obj.NZL_IsActive)
                    .ToListAsync();
                return res.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling NozzleRegistration ", ex);
                return 0;
            }
        }

    }
}
