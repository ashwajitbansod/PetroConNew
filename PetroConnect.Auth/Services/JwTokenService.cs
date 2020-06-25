
using Microsoft.EntityFrameworkCore;
using PetroConnect.Auth.Models;
using PetroConnect.Data.Context;
using System;
using System.Linq;

namespace PetroConnect.Auth.Services
{
    public class JwTokenService
    {
        public AuthModel GetJwToken(string userName, string password, string Issuer, string selfAddress, bool isAdmin = false)
        {
            var objResult = new AuthModel();
            try
            {

                var objData = new PetroConnect.Data.Services.UserDetails();
                var result = objData.GetUserDetails(userName, password);


                objResult.Token = result.Token;
                objResult.FullName = result.FullName;
                objResult.Role = result.Role;
                objResult.IsAdmin = result.isAdmin;
                objResult.Token = new JWTTokenManager().GetTokenWithClaims(userName, objResult, Issuer, selfAddress);

                return objResult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool GetDatausingProcedure()
        {
            using (var db = new PetroConnectContext())
            {
                var res = db.TestData.FromSqlRaw("exec uspGetEmployee ").ToList();
            }

            return true;

        }
    }
}