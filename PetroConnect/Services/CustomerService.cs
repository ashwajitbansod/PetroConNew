using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetroConnect.API.Helpers;
using PetroConnect.API.Models;
using PetroConnect.Data.Common;
using PetroConnect.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{

    public interface ICustomerService
    {
        Task<int> RegistrationUser(RegistrationTeamModal user);
        Task<object> SetCustomerMapping(CustomerMappingModel obj);
        Task<object> GetCustomerList(long UID_UserId_Owner);
        Task<object> EditCustomer(EditCustomerModel obj);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IDbLogger _ILogger;
        private readonly PetroConnectContext _connectContext;
        public CustomerService(IDbLogger iLogger, PetroConnectContext connectContext)
        {
            _connectContext = connectContext;
            _ILogger = iLogger;
        }
        public async Task<int> RegistrationUser(RegistrationTeamModal user)
        {
            try
            {
                var spFinalString = StringGenerator.GetProcedureParameter(user, SPConstants.spRegistrationUser);

                var res = await _connectContext.spCustomerRegistration
                    .FromSqlRaw(string.Format(spFinalString,
                    user.Action,
                    user.ULA_UID_UserId,
                    user.ULA_Roll,
                    user.ULA_LoginId,
                    user.ULA_FirstName,
                    user.ULA_LastName
                    )).ToListAsync()
                    ;
                return res.FirstOrDefault().Result;

            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SpCustomerRegistration ", ex);
                return 1;
            }
        }

        public async Task<object> SetCustomerMapping(CustomerMappingModel obj)
        {
            try
            {
                var spFinalString = StringGenerator.GetProcedureParameter(obj, SPConstants.SetCustomerMapping);

                var res = await _connectContext.spSetCustomerMapping
                    .FromSqlRaw(string.Format(spFinalString, obj.Action, obj.OCM_Id, obj.OCM_UID_UserId_Owner, obj.OCM_UID_UserId_Customer,
                    obj.OCM_CreditLimit, obj.OCM_BillCycleStartDay, obj.OCM_BillCycleDays, obj.OCM_OpeningBalance,
                    obj.OCM_Refrence, obj.OCM_UpdatedBy, obj.OCM_IsActive
                    )).ToListAsync(); 
                    
                return  res.FirstOrDefault().Result;

            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling SetCustomerMapping ", ex);
                return 0;
            }
        }
        /// <summary>
        /// Created By : Ashwajit Bansod
        /// Created Date : 18-06-2020
        /// Created For : To get customer list.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<object> GetCustomerList(long UID_UserId_Owner)
        {
            try
            {
                var sp = StringGenerator.GetProcedureParameter(1, SPConstants.spGetCustomerDetails);
                return await _connectContext.spGetCustomerDetails.FromSqlRaw(sp, UID_UserId_Owner).Select(x => new GetCustomerModel
                {
                    OCM_BillCycleDays = x.OCM_BillCycleDays,
                    OCM_BillCycleStartDay = x.OCM_BillCycleStartDay,
                    OCM_CompanyName = x.UID_CompanyName,
                    OCM_CreditLimit = x.OCM_CreditLimit,
                    OCM_Id =x.OCM_Id,
                    OCM_IsActive = x.OCM_IsActive,
                    OCM_UserId_Customer = x.OCM_UID_UserId_Customer,
                    OCM_OpeningBalance = x.OCM_OpeningBalance,
                    OCM_Refrence = x.OCM_Refrence,
                    UID_MobileNumber = x.UID_MobileNumber,
                    UID_Date = x.UID_Date,
                    OCM_GSTIN = x.UID_GSTIN,
                    OCM_Name = x.Name,
                    OCM_PAN = x.UID_PAN,
                    OCM_Photo = x.ULA_Photo,
                    //OCM_UpdatedBy
                    // OCM_UID_UserId_Owner = x.
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling GetCustomerList ", ex);
                return 0;
            }
        }
        //Created by : Ashwajit Bansod, Date : 24-06-2020, Created For : To update customer details
        
        public async Task<object> EditCustomer(EditCustomerModel obj)
        {
            try
            {
                var spFinalString = StringGenerator.GetProcedureParameter(obj, SPConstants.spSetCustomerDetailEdit);
                var res = await _connectContext.spSetCustomerDetailEdit
                    .FromSqlRaw(string.Format(spFinalString, obj.OCM_Id, obj.OCM_UID_UserId_Customer, obj.OCM_CreditLimit,
                    obj.OCM_BillCycleStartDay, obj.OCM_BillCycleDays, obj.OCM_OpeningBalance, obj.OCM_Refrence, obj.OCM_UpdatedBy,
                    obj.UID_CompanyName, obj.UID_MobileNumber, obj.UID_GSTIN, obj.UID_PAN, obj.ULA_Photo,
                    obj.ULA_FirstName, obj.CompanyAction
                    )).ToListAsync();

                return res.FirstOrDefault().Result;

            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Critical, "Exception while calling EditCustomer ", ex);
                return 0;
            }
        }
        
    }
}
