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
    public interface ITeamService
    {
        Task<object> GetTeams(long UID_UserId_Owner);
        Task<int> ActivationDeActivationTeam(TeamActivateModel obj);
    }
    public class TeamService : ITeamService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public TeamService(IDbLogger iLogger, PetroConnectContext connectContext)
        {
            _connectContext = connectContext;
            _ILogger = iLogger;
        }
        public async Task<object> GetTeams(long UID_UserId_Owner)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(1, SPConstants.spGetTeamDetails);
                return await _connectContext.spGetTeamDetails.FromSqlRaw(sp, UID_UserId_Owner).Select(x => new TeamsModel
                {
                    ULA_FirstName = x.ULA_FirstName,
                    ULA_LastName = x.ULA_LastName,
                    ULA_LoginId = x.ULA_LoginId,
                    ULA_Photo = x.ULA_Photo,
                    ULA_Roll = x.ULA_Roll,
                    ULA_IsActive = x.ULA_IsActive
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling GetCustomerList ", ex);
                return 0;
            }
        }

        //Created By : Ashwajit Bansod to acitvate deactivate team
        public async Task<int> ActivationDeActivationTeam(TeamActivateModel obj)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(obj, SPConstants.spSetActivationDeActivationTeam);
                var result = await _connectContext.spSetActivationDeActivationTeam
                     .FromSqlRaw(sp, obj.ULA_UserId,obj.ULA_LoginId, obj.ULA_IsActive)
                     .ToListAsync();
                return result.FirstOrDefault().Result;

            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling ActivationDeActivationTeam ", ex);
                return 0;
            }
        }
    }
}
