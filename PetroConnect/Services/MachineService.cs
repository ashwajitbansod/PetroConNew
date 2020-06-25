using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetroConnect.API.Models;
using PetroConnect.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{
    public interface IMachineService
    {
   
        //Task<List<MachineModel>> GetMachineList(long MCN_UID_UserId);
    }
    public class MachineService : IMachineService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public MachineService(IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _connectContext = connectContext;
        }

        //public async Task<List<MachineModel>> GetMachineList(long MCN_UID_UserId)
        //{
        //    try
        //    {
        //        return await _connectContext.spGetMachine.FromSqlRaw("").Select(x => new MachineModel
        //        {
        //            MCN_UID_UserId = x.MCN_UID_UserId,
        //            MCN_Name = x.MCN_Name,
        //            MCN_DeActive = x.MCN_DeActive
        //        }).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _ILogger.Log(LogLevel.Critical, "Exception while calling SpRegistrationTeam ", ex);
        //        return null;
        //    }

        //}

        
    }
}
