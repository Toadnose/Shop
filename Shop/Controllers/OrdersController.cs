using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly Context _context;

        public OrdersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpPost("buy")]
        public async Task<ActionResult<IEnumerable<BuyProduct>>> Buy_Product(BuyProduct request)
        {
            foreach (var item in request.product_ids)
            {
                var order = new Orders()
                {
                    Product_id = item,
                    Customer_Id = request.Customers_id
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetOrders", request);
        }

        [HttpPost("return")]
        public async Task<ActionResult<IEnumerable<BuyProduct>>> Return_Product(ReturnProduct request)
        {
            foreach (var item in request.product_ids)
            {
                var order_item = await _context.Orders.SingleOrDefaultAsync(x => x.Id == item);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetOrders", request);
        }
    }
}
