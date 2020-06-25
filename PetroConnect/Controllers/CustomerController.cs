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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _ICustomerService;
        public CustomerController(ICustomerService _ICustomerService)
        {
            this._ICustomerService = _ICustomerService;
        }
        //Getting cutomer details
        [HttpGet]
        [Route("GetCustomerDetails")]
        public async Task<IActionResult> GetCustomerList(long UID_UserId_Owner)
        {
            return Ok(await _ICustomerService.GetCustomerList(UID_UserId_Owner));
        }
        [HttpPost]
        [Route("SetCustomerDetailEdit")]
        public async Task<IActionResult> SetCustomerDetailEdit([FromBody] EditCustomerModel obj)
        {
            return Ok(await _ICustomerService.EditCustomer(obj));
        }
    }
}
