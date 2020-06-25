using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetroConnect.API.Models;
using PetroConnect.API.Services;

namespace PetroConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _IProductService; public readonly IPumpService _pumpService;
        public ProductController(IPumpService fuelService, IProductService productService)
        {
            _IProductService = productService; 
            _pumpService = fuelService;
        }
        [HttpPost]
        [Route("SetProductDetailOwner")]
        public async Task<IActionResult> SetProductDetailOwner([FromBody]ProductDetailOwner obj)
        {
            if (ModelState.IsValid)
                return Ok(await _IProductService.SetProductDetailOwner(obj));
            else return UnprocessableEntity();
        }

        [HttpGet]
        [Route("GetProductDetailOwner")]
        public async Task<IActionResult> GetProductDetailOwnerList(long PRD_UID_UserId, string ProductType)
        {
            return Ok(await _IProductService.GetProductDetailOwnerList(PRD_UID_UserId, ProductType));
        }

        [HttpPost]
        [Route("SetDailyUpdateFuelPrice")]
        public async Task<IActionResult> SetDailyUpdateFuelPrice([FromBody]FuelPriceModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _pumpService.SetDailyUpdateFuelPrice(obj));
            else return UnprocessableEntity();
        }
    }
}