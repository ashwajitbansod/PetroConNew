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
    public class SalesController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public SalesController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody]PlaceOrderModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _orderService.PlaceOrder(obj));
            else return UnprocessableEntity();
        }

        [HttpGet]
        [Route("GetIndent")]
        public async Task<IActionResult> GetIndent(long UID_UserId_Owner, long LoginId, string Roll, long SBK_MNS_Id, string SBK_SaleType)
        {
            var obj = new IndentModel
            {
                UID_UserId_Owner = UID_UserId_Owner,
                LoginId = LoginId,
                Roll = Roll,
                SBK_MNS_Id = SBK_MNS_Id,
                SBK_SaleType = SBK_SaleType,
            };
            if (ModelState.IsValid)
                return Ok(await _orderService.GetIndent(obj));
            else return UnprocessableEntity();
        }


        [HttpPost]
        [Route("SetConfirmOrder")]
        public async Task<IActionResult> SetConfirmOrder([FromBody]ConfirmOderModel obj)
        {
            if (ModelState.IsValid)
                return Ok(await _orderService.SetConfirmOrder(obj));
            else return UnprocessableEntity();
        }

    }
}