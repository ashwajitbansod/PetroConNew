using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetroConnect.API.Helpers;
using PetroConnect.API.Models;
using PetroConnect.Data.Common;
using PetroConnect.Data.Context;
using PetroConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{
    public interface IUserService
    {
        /// <summary>
        /// You can add or update Users using this method. 
        /// If you are adding or updating it will impact two tables UserLoginDetails and UserLoginAccess
        /// </summary>
        /// <param name="obj"></param
        /// <returns></returns>
        System.Threading.Tasks.Task<int> AddUpdateUserRegistrationAsync(UserRegistrationModel obj);
        System.Threading.Tasks.Task<int> AddUpdateTeamMembersAsync(TeamModel obj);
        Task<List<GlobalCodeModel>> GetGlobalCode(string gBC_Category);
        Task<int> ActivateDeactivateUser(UserActivateModel obj);
    }
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public UserService(IOptions<AppSettings> appSettings, IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _appSettings = appSettings.Value;
            _connectContext = connectContext;
        }

        public async Task<int> AddUpdateUserRegistrationAsync(UserRegistrationModel obj)
        {
            try
            {
                var spString = StringGenerator.GetProcedureParameter(obj, SPConstants.spRegistrationUser);
                var res = await _connectContext.spCustomerRegistration
                    .FromSqlRaw(
                    spString,
                    obj.Action,
                    obj.UID_UserId,
                    obj.UID_CompanyName,
                    obj.UID_PumpRegNumber,
                    obj.UID_OilCompany,
                    obj.UID_Address,
                    obj.UID_STM_StateId,
                    obj.UID_CTM_CityCode,
                    obj.UID_Pin,
                    obj.UID_UserType,
                    obj.UID_MobileNumber,
                    obj.UID_eMail,
                    obj.UID_GSTIN,
                    obj.UID_PAN,
                    obj.UID_TIN,
                    obj.UID_CIN,
                    obj.UID_ValidFrom,
                    obj.UID_ValidThru,
                    obj.ULA_FirstName,
                    obj.ULA_LastName,
                    obj.ULA_Photo
                    ).ToListAsync();
                return res.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SpUserRegistration", ex);
                return 0;
            }
        }

        public async Task<int> AddUpdateTeamMembersAsync(TeamModel obj)
        {
            try
            {
                var spString = StringGenerator.GetProcedureParameter(obj, SPConstants.spRegistrationTeam);

                var res = await _connectContext.spCustomerRegistration
                    .FromSqlRaw(string.Format(spString, obj.Action, obj.ULA_UID_UserId, obj.ULA_Roll, obj.ULA_LoginId, obj.ULA_FirstName, obj.ULA_LastName , obj.ULA_Photo ))
                    .ToListAsync();
                return res.FirstOrDefault().Result;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SpRegistrationTeam ", ex);
                return 0;
            }
        }
        public async Task<int> SetShiftSchecdule(TeamModel obj)
        {
            try
            {
                var result = await _connectContext.spSetShiftSchecdule.FromSqlRaw(SPConstants.spSetShiftSchecdule).ToListAsync();
                return result.FirstOrDefault().Result;

            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SetShiftSchecdule ", ex);
                return 0;
            }
        }

        public async Task<List<GlobalCodeModel>> GetGlobalCode(string gBC_Category)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(SPConstants.spGetGlobalCode);
                var res = await _connectContext.spGetGlobalCode
                    .FromSqlRaw(sp + " {0} ", gBC_Category).Select(m => new GlobalCodeModel
                    {

                        GBC_Category = m.GBC_Category,
                        GBC_Code = m.GBC_Code,
                        GBC_CodeName = m.GBC_CodeName,
                        GBC_Description = m.GBC_Description,
                        GBC_SortOrder = m.GBC_SortOrder
                    })
                    .ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling GetGlobalCode ", ex);
                return new List<GlobalCodeModel>();
            }
        }
        //Created By : Ashwajit Bansod to acitvate deactivate user
        public async Task<int> ActivateDeactivateUser(UserActivateModel obj)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(obj, SPConstants.spSetActivationDeActivationUser);
                var result = await _connectContext.spSetActivationDeActivationUser
                     .FromSqlRaw(sp, obj.UID_UserId, obj.IsActive)
                     .ToListAsync();
                return result.FirstOrDefault().Result;

            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling ActivateDeactivateUser ", ex);
                return 0;
            }
        }
        
    }
}
