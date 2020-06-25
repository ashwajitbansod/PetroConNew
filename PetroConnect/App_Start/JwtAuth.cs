using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using PetroConnect.Models.Constants;
using PetroConnect.API.Common;
using System.Security.Principal;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace PetroConnect.API.App_Start
{
    public class JwtAuth : Attribute, IAuthenticationFilter
    {
        public JwtAuth(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        private IConfiguration _Configuration;


        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != Constants.Bearer || string.IsNullOrEmpty(authorization.Parameter)){
                context.ErrorResult = new AuthFailureResult("JWT Token is missing");
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthJwtToken(token);
            if(principal == null)
            {
                context.ErrorResult = new AuthFailureResult("Invalid JWT Token");
            }else
            {
                context.Principal = principal;
            }
        }

        protected Task<IPrincipal> AuthJwtToken(string token)
        {
            IEnumerable<Claim> claims;

            if (JwtTokenManager.ValidateToken(token, _Configuration.GetSection("JWTAudience").Key  , _Configuration.GetSection("SelfAddress").Key, out claims))
            {
                var identity = new ClaimsIdentity(claims.ToList(), "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);
                return Task.FromResult(user);
            }
            return Task.FromResult<IPrincipal>(null);

        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
