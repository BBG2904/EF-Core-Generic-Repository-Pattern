using EFCoreDatabase.Entities;
using EFCoreDatabase.Repositories.Interfaces;
using EFCoreDatabase.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWorkWithEnityCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopOrderController : ControllerBase
    {
        private IUnitOfWork<Order> _orderUOW;
        public ShopOrderController(
            IUnitOfWork<Order> order)
        {
            _orderUOW = order;
        }

        //sample data json request
        //        {
        //  "name": "X Order",
        //  "shopId": 1,
        //  "orderItems": [
        //    {
        //      "itemId": 1,
        //      "createdDate": "2024-10-05T11:05:50.355Z"
        //    }
        //  ]
        //}
        [HttpPost]
        public async Task<IActionResult> CreateShopOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order is Invalid.");
            }

            await _orderUOW.EntityRepository.Insert(order);
            await _orderUOW.Complete();

            return Ok("Order Created Successfully :" + order.Id);
        }
    }
}
