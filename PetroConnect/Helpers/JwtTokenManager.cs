using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetroConnect.API.Common
{
    public class JwtTokenManager
    {
        public JwtTokenManager(IConfiguration configuration)
        {
            _Configuraiton = configuration;
        }
        private readonly IConfiguration _Configuraiton;
        private const string Secret = "PetroConnect@JWT_Token_34234FD";

        public static bool ValidateToken(string token,string jwtIssuer , string audience, out IEnumerable<Claim> claims)
        {
            claims = null;
            var simplePrinciple = GetPricipal(token , jwtIssuer, audience);


            if(simplePrinciple == null)
            {
                return false;
            }

            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if(identity == null)
            {
                return false;
            }
            if (!identity.IsAuthenticated)
                return false;
            claims = identity.Claims;

            if (string.IsNullOrEmpty(claims.First(x => x.Type.Equals(ClaimTypes.Name)).Value))
                return false;


            return true;
        }

        private static ClaimsPrincipal GetPricipal(string token , string jwtIssuer, string audience)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if(jwtToken == null)
                {
                    return null;
                }

                var symetricKey = Convert.FromBase64String(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Secret)));

                var validationPrameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidIssuer = audience,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(symetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationPrameters, out securityToken);

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
