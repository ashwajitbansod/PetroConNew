using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetroConnect.API.Models;
using PetroConnect.API.Services;

namespace PetroConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpController : ControllerBase
    {
        private readonly ITankService _ITankService;
        public readonly IPumpService _pumpService;
        //public readonly IMachineService _IMachineService;
        public PumpController(IPumpService fuelService, ITankService productService)//, IMachineService machineService)
        {
            _ITankService = productService;
            _pumpService = fuelService;
            //this._IMachineService = machineService;
        }   
       
        [HttpPost]
        [Route("MachineRegistration")]
        public async Task<IActionResult> MachineRegistration([FromBody]MachineRegistrationModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _pumpService.MachineRegistration(obj));
            else return UnprocessableEntity();
        }
        [HttpPost]
        [Route("NozzleRegistration")]
        public async Task<IActionResult> NozzleRegistration([FromBody]NozzleRegistrationModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _pumpService.NozzleRegistration(obj));
            else return UnprocessableEntity();
        }

        [HttpGet]
        [Route("GetTankMachineNozzle")]
        public async Task<IActionResult> GetTankMachineNozzle(long UserId)
        {
            return Ok(await _pumpService.GetTankMachineNozzle(UserId));
        }

        [HttpPost]
        [Route("SetTankRegistration")]
        public async Task<IActionResult> SetTankRegistration([FromBody]TankRegistrationModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _ITankService.SetTankRegistration(obj));
            else return UnprocessableEntity();
        }

        [HttpGet]
        [Route("GetTank")]
        public async Task<IActionResult> GetTankList(long UserId)
        {
            return Ok(await _ITankService.GetTankListDetails(UserId));
        }
        [HttpGet]
        [Route("GetMachine")]
        public async Task<IActionResult> GetMachineList(long UserId)
        {
            return Ok(await _ITankService.GetMachineList(UserId));
        }
    }
}