using EFCoreDatabase.Entities;
using EFCoreDatabase.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWorkWithEnityCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopOrderController : ControllerBase
    {
        private IGenericRepository<Order> _orderRepository;
        private IGenericRepository<Item> _itemRepository;
        private IGenericRepository<OrderItem> _orderItemRepository;
        public ShopOrderController(
            IGenericRepository<Order> orderRepository,
            IGenericRepository<Item> itemRepository,
            IGenericRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
            _orderItemRepository = orderItemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopOrder([FromBody] Order order)
        {
            if(order == null)
            {
                return BadRequest("Order is Invalid");
            }

            await _orderRepository.Insert(order);

            return Ok("Order Created Successfully");
        }
    }
}
