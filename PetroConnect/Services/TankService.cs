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
    public interface ITankService
    {
        Task<int> SetTankRegistration(TankRegistrationModel obj);
        Task<List<TankModel>> GetTankListDetails(long UserId);
        Task<List<MachineModelList>> GetMachineList(long MCN_UID_UserId);
    }

    public class TankService : ITankService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public TankService(IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _connectContext = connectContext;
        }

        public async Task<int> SetTankRegistration(TankRegistrationModel obj)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(obj, SPConstants.spSetTankRegistration);
                var res = await _connectContext.spSetTankRegistration
                    .FromSqlRaw(sp, obj.Action, obj.TNK_Id, obj.TNK_UID_UserId, obj.TNK_Name, obj.TNK_FuelType, obj.TNK_Capacity, obj.TNK_IsActive)
                    .ToListAsync();
                return res.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SetTankRegistration ", ex);
                return 0;
            }
        }
        //Created by : Ashwajit Bansod to get tank list
        public async Task<List<TankModel>> GetTankListDetails(long UserId)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(1, SPConstants.spGetTank);
                var result = await _connectContext.spGetTank.FromSqlRaw(sp, UserId).
                Select(x => new TankModel()
                {
                    TNK_Capacity = x.TNK_Capacity,
                    TNK_IsActive = x.TNK_IsActive,
                    TNK_FuelType = x.TNK_FuelType,
                    TNK_Id = x.TNK_Id,
                    TNK_Name = x.TNK_Name,
                    TNK_UID_UserId = x.TNK_UID_UserId,
                    TNK_FuelStock = x.TNK_FuelStock
                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling GetTankListDetails ", ex);
                return null;
            }
           
        }

        public async Task<List<MachineModelList>> GetMachineList(long MCN_UID_UserId)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(1, SPConstants.spGetMachine);
                return await _connectContext.spGetMachine.FromSqlRaw(sp, MCN_UID_UserId).Select(x => new MachineModelList
                {
                    MCN_Id = x.MCN_Id,
                    MCN_UID_UserId = x.MCN_UID_UserId,
                    MCN_Name = x.MCN_Name,
                    MCN_IsActive = x.MCN_IsActive
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling GetMachineList ", ex);
                return null;
            }

        }
    }
}
