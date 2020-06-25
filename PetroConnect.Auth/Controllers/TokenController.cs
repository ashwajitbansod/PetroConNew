
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetroConnect.API.Services;
using PetroConnect.Auth.Models;
using System.Threading.Tasks;

namespace PetroConnect.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {

        private readonly ILogger<TokenController> _logger;
        private IUserService _userService;

        public TokenController(ILogger<TokenController> logger, IUserService userService)
        {
            _logger = logger;

            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("wokring");
        }

        [AllowAnonymous]
        [EnableCors("AuthCorsPolicy")]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(user);
        }
    }
}
