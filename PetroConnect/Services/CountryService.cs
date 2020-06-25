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

    public interface ICountryService
    {
        Task<List<CityModel>> GetCity(long CTM_STM_StateID);
        Task<List<StateModel>> GetStates(long CountryId);
    }
    public class CountryService : ICountryService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;

        public CountryService(IDbLogger logger, PetroConnectContext connectContext)
        {
            _ILogger = logger;
            _connectContext = connectContext;
        }
        public async Task<List<CityModel>> GetCity(long CTM_STM_StateID)
        {
            try
            {
                var spString = StringGenerator.GetProcedureParameter(SPConstants.spGetCityList);
                return await _connectContext.spGetCity
                    .FromSqlRaw(spString + " " + CTM_STM_StateID)
                    .Select(x => new PetroConnect.API.Models.CityModel
                    {

                        CTM_CityCode = x.CTM_CityCode,
                        CTM_Name = x.CTM_Name,
                        CTM_STM_StateID = x.CTM_STM_StateID
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling GetCity", ex);
                return new List<CityModel>();
            }
        }

        public async Task<List<StateModel>> GetStates(long CountryId)
        {
            try
            {
                var spString = StringGenerator.GetProcedureParameter(SPConstants.spGetStateList);
                return await _connectContext.spGetStateList
                    .FromSqlRaw(spString + " " + CountryId)
                    .Select(x => new StateModel
                    {
                        STM_CNM_CountryId = x.STM_CNM_CountryId,
                        STM_Name = x.STM_Name,
                        STM_StateId= x.STM_StateId
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling GetStates", ex);
                return new List<StateModel>();
            }
        }
    }


}   