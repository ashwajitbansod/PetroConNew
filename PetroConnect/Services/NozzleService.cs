using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetroConnect.API.Models;
using PetroConnect.Data.Common;
using PetroConnect.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{
    public interface INozzleService
    {

        Task<object> SetMappingNozzleShift(NozzleMappingModel obj);
        Task<int> SetShiftSchecdule(ShiftScheduleModal obj);
    }
    public class NozzleService : INozzleService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public NozzleService(IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _connectContext = connectContext;
        }

        public async Task<object> SetMappingNozzleShift(NozzleMappingModel obj)
        {
            try
            {
                var sp = PetroConnect.API.Helpers.StringGenerator.GetProcedureParameter(obj, SPConstants.spSetMappingNozzleShift);

                var res = await _connectContext.SetMappingNozzleShift
                    .FromSqlRaw(sp, obj.Action, obj.MNS_Id, obj.MNS_UID_UserId, obj.MNS_NZL_Id, obj.MNS_SSH_Id, obj.MNS_IsActive)
                    .ToListAsync();
                return res.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SetMappingNozzleShift ", ex);
                return false;
            }
        }

        public async Task<int> SetShiftSchecdule(ShiftScheduleModal obj)
         {
            try
            {
                var sp = PetroConnect.API.Helpers.StringGenerator.GetProcedureParameter(obj, SPConstants.spSetShiftSchecdule);

                var res = await _connectContext.spSetShiftSchecdule
                    .FromSqlRaw(sp, obj.Action, obj.SSH_Id, obj.SSH_UID_UserId, obj.SSH_ULA_LoginId, obj.SSH_SSL_Id, obj.SSH_IsActive , obj.SchedulefromDate, obj.ScheduleToDate)
                    .ToListAsync();
                return res.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SetShiftSchecdule ", ex);
                return 0;
            }
        }
    }
}
