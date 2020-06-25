using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetroConnect.API.Models;
using PetroConnect.API.Services;

namespace PetroConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _ITeamService;
        private IUserService _userService;
        public TeamController(ITeamService _ITeamService, IUserService _userService)
        {
            this._ITeamService = _ITeamService;
            this._userService = _userService;
        }
        [HttpGet]
        [Route("GetTeamDetails")]
        public async Task<IActionResult> GetTeamList(long UID_UserId_Owner)
        {
            return Ok(await _ITeamService.GetTeams(UID_UserId_Owner));
        }
        [HttpPost]
        [Route("SetActivationDeActivationTeam")]
        public async Task<IActionResult> SetActivationDeActivationTeam([FromBody] TeamActivateModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _ITeamService.ActivationDeActivationTeam(obj));
            else return UnprocessableEntity();
        }
    }
}
