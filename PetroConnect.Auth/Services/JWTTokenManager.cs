using Microsoft.IdentityModel.Tokens;
using PetroConnect.Auth.Common;
using PetroConnect.Auth.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PetroConnect.Auth.Services
{
    public class JWTTokenManager
    {

        private const string Secret = "PetroConnect@JWT_Token_34234FD";



        public string GetTokenWithClaims(string userName, AuthModel objResult, string Issuer, string selfAddress)
        {
         
            var claimObject = new ClaimsIdentity(new[] {

                new Claim(ClaimTypes.Name , userName),
                new Claim(ClaimTypes.GivenName , objResult.FullName),
                new Claim(ClaimTypes.Role , objResult.Role.ToString()),
                new Claim(ClaimsConstants.IsAdmin , objResult.IsAdmin),
            });
          
            return GenerateToken(claimObject, Issuer, selfAddress);
        }
        public string GenerateToken(ClaimsIdentity claims, string JwtIssuer, string selfAddress, int expireMinutes = 60)
        {
            var symetric = Convert.FromBase64String(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Secret)));
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;


            var toekDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Issuer = JwtIssuer,
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                Audience = selfAddress,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symetric), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(toekDescriptor);

            return tokenHandler.WriteToken(stoken);

        }
    }
}
