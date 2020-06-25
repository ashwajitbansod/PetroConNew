using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetroConnect.Auth.Common;
using PetroConnect.Auth.Models;
using PetroConnect.Data.Context;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PetroConnect.API.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly PetroConnectContext _connectContext;
        private readonly ILogger<UserService> _logger;
        public UserService(IOptions<AppSettings> appSettings, ILogger<UserService> logger, PetroConnectContext connectContext)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _connectContext = connectContext;
        }

        /// <summary>
        /// User will authenticate successfully if he has entered the correct username/loginid/mobile and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> Authenticate(string username, string password)
        {
            try
            {
                var spLogin_Re = await _connectContext.spLogin.FromSqlRaw("exec spGetLogin {0} , {1}", username, password).ToListAsync();

                //spLogin_Result x = spLogin_Re.FirstOrDefault();

                var user = spLogin_Re.Select(x => new User
                {
                    Username = x.UserName,
                    UserId = x.ULA_UID_UserId,
                    UID_PumpRegNumber = x.UID_PumpRegNumber,
                    ProfileImage = x.ULA_Photo,
                    Role = x.ULA_Roll,
                    Token = null,
                    Password = null,
                    UserCount = x.UserCount

                }).FirstOrDefault();

                if (user == null)
                    return null;

                if (user.UserCount > 1)
                {
                    var spPetrolPump = await _connectContext.spLoginNext.FromSqlRaw("exec spGetLoginNext {0}", username).ToListAsync();

                    user.Pumps = spPetrolPump.Select(x => new PumpModal
                    {
                        UID_PumpRegNumber = x.UID_PumpRegNumber
                    }).ToList();
                }

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {

                        new Claim(ClaimsConstants.UserId, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserId.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    }),
                    Audience = _appSettings.Audience,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Critical, "calling spGetLogin", ex);
                return null;
            }
        }
    }
}

