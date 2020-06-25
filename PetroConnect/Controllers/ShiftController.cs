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
    public class ShiftController : ControllerBase
    {
        private readonly INozzleService _INozzleService;
        public ShiftController(INozzleService productService)
        {
            _INozzleService = productService;
        }
        [HttpPost]
        [Route("SetMappingNozzleShift")]
        public async Task<IActionResult> SetMappingNozzleShift([FromBody]NozzleMappingModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _INozzleService.SetMappingNozzleShift(obj));
            else return UnprocessableEntity();
        }

        [HttpPost]
        [Route("SetShiftSchecdule")]
        public async Task<IActionResult> SetShiftSchecdule([FromBody]ShiftScheduleModal obj)
        {
            if (ModelState.IsValid)
                return Ok(await _INozzleService.SetShiftSchecdule(obj));
            else return UnprocessableEntity();
        }

    }
}