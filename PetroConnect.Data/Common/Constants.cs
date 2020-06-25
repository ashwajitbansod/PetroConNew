using System;
using System.Collections.Generic;
using System.Text;

namespace PetroConnect.Data.Common
{
    public static class SPConstants
    {
        //User Management
        public static readonly string spRegistrationUser = "spRegistrationUser";
        public static readonly string spRegistrationTeam = "spRegistrationTeam";
        public static readonly string SetCustomerMapping = "spSetCustomerMapping";
        public static readonly string spGetGlobalCode = "spGetGlobalCode";
        public static readonly string spGetCityList = "spGetCityList";
        public static readonly string spGetStateList = "spGetStateList";
        public static readonly string spSetActivationDeActivationUser = "spSetActivationDeActivationUser ";

        //Pump Management
        public static readonly string spSetMachineRegistration = "spSetMachineRegistration";
        public static readonly string spSetTankRegistration = "spSetTankRegistration";
        public static readonly string spSetNozzleRegistration = "spSetNozzleRegistration";
        public static readonly string spGetTankMachineNozzle = "spGetTankMachineNozzle";
        public static readonly string spGetTank = "spGetTank";
        public static readonly string spGetMachine = "spGetMachine";


        //Product Configuration
        public static readonly string spGetProductDetailOwner = "spGetProductDetailOwner";
        public static string spSetProductDetailOwner = "spSetProductDetailOwner";
        public static readonly string spSetDailyUpdateFuelPrice = "spSetDailyUpdateFuelPrice";

        //Shift Management

        public static readonly string spSetShiftSchecdule = "spSetShiftSchecdule";
        public static readonly string spSetMappingNozzleShift = "spSetMappingNozzleShift";


        //Sale Management
        public static readonly string spSetPlaceOrder = "spSetPlaceOrder";
        public static readonly string spGetIndent = "spGetIndent";
        public static readonly string spSetConfirmOrder = "spSetConfirmOrder";

        public static readonly string spGetCustomerDetails = "spGetCustomerDetails";
        

        //Team Management
        public static readonly string spSetActivationDeActivationTeam = "spSetActivationDeActivationTeam";
        public static readonly string spGetTeamDetails = "spGetTeamDetails";

        public static readonly string spExceptionLogger = "spLog";

        //Customer Management
        public static readonly string spSetCustomerDetailEdit = "spSetCustomerDetailEdit";
    }
}
