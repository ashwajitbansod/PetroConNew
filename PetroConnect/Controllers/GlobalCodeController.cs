using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetroConnect.API.Services;

namespace PetroConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalCodeController : ControllerBase
    {
        private readonly IGlobalCodeService _IGlobalCodeService;
        public GlobalCodeController(IGlobalCodeService productService)
        {
            _IGlobalCodeService = productService;
        }
      
    }
}