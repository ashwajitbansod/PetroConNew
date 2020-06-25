
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetroConnect.API.Services;
using PetroConnect.API.Models;
using PetroConnect.Models.Constants;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;

namespace PetroConnect.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICountryService _ICountryService;
        private IUserService _userService;
        private readonly ICustomerService _customerService;
        private IDbLogger _logger;

        private IConfiguration configuration;
        private IHostingEnvironment _env;
        public UsersController(IUserService userService, IDbLogger logger, ICustomerService customerService,ICountryService countryService, IConfiguration _iconfig, IHostingEnvironment env)
        {
            _ICountryService = countryService;
            _customerService = customerService;
            _userService = userService;
            _logger = logger;
            configuration = _iconfig;
            _env = env;
        }

        [HttpPost]
        //[Authorize(Roles = "Owner")]
        [Route("RegistrationUser")]
        public async Task<IActionResult> Post([FromBody] UserRegistrationModel obj)
        {
            if (ModelState.IsValid)
            {
                var users = await _userService.AddUpdateUserRegistrationAsync(obj);
                return Ok(users);
            }
            else
            {
                return BadRequest(Constants.InvalidInput);
            }
        }
        
        [HttpGet]
        [Route("GetGlobalCode")]
        public async Task<IActionResult> GetGlobalCode(string GBC_Category)
        {
            return Ok(await _userService.GetGlobalCode(GBC_Category));
        }


        [HttpPost]
        [Route("RegistrationTeam")]
        public async Task<IActionResult> RegistrationTeam([FromBody]TeamModel obj)
        {
            if (ModelState.IsValid)
            {

                //if (obj.ULA_Photo != null)
                //{
                //    var HostingPrefix =  configuration.GetSection("AppSettings").GetSection("Audience").Value;
                //    var ImagePath =  configuration.GetSection("MySettings").GetSection("ImageSave").Value;
                //    var ImageUniqueName = DateTime.Now.ToString("yyyyMMddHHmm") + obj.ULA_LoginId + "_" + obj.ULA_LastName;
                //    var url = HostingPrefix + ImagePath + ImageUniqueName + ".jpg";
                //    var ImageURL = ImageUniqueName + ".jpg";
                //    if (!Directory.Exists(ImagePath))
                //    {
                //        Directory.CreateDirectory(ImagePath);
                //    }
                //    var ImageLocation = ImagePath + ImageURL;
                //    //Save the image to directory
                //    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(obj.ULA_Photo)))
                //    {
                //        using (Bitmap bm2 = new Bitmap(ms))
                //        {
                //            //bm2.Save("SavingPath" + "ImageName.jpg");
                //            bm2.Save(ImageLocation);
                //            obj.ULA_Photo = ImageURL;
                //            //imgupload.ImageUrl = ImageLocation;
                //        }
                //    }
                //}
                return Ok(await _userService.AddUpdateTeamMembersAsync(obj));
            }
            else return UnprocessableEntity();
        }

        [HttpPost]
        [Route("SetCustomerMapping")]
        public async Task<IActionResult> SetCustomerMapping([FromBody]CustomerMappingModel obj)
        {
            if (ModelState.IsValid)
                
            return Ok(await _customerService.SetCustomerMapping(obj));
            else return UnprocessableEntity();
        }

        [HttpGet]
        [Route("GetCity")]
        public async Task<IActionResult> GetCity(long stateId)
        {
            return Ok(await _ICountryService.GetCity(stateId));
        }


        [HttpGet]
        [Route("GetStates")]
        public async Task<IActionResult> GetStates(long countryId)
        {
            return Ok(await _ICountryService.GetStates(countryId));
        }

        [HttpGet]
        [Route("Test")]
        public IActionResult GetTime()
        {
            return  Ok(DateTime.Now);
        }
        [HttpPost]
        [Route("SetActivationDeActivationUser")]
        public async Task<IActionResult> SetActivationDeActivationUser([FromBody] UserActivateModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _userService.ActivateDeactivateUser(obj));
            else return UnprocessableEntity();
        }
    }

}