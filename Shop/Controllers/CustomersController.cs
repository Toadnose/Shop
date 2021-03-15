using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Data;
using Shop.DTO;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;

        public CustomersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersDTO>>> GetCustomers()
        {
            var customer = from customers in _context.Customers join Customers_description in _context.Customers_Description on customers.Id equals Customers_description.Id
            select new CustomersDTO {
                Customers_id = customers.Id,
                First_name = Customers_description.first_name,
                Last_name = Customers_description.last_name,
                Address = Customers_description.address
            };
            return await customer.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<CustomersDTO> Get_byId(int id)
        {
            var customer = from customers in _context.Customers join Customers_description in _context.Customers_Description on customers.Id equals Customers_description.Id
            select new CustomersDTO {
                Customers_id = customers.Id,
                First_name = Customers_description.first_name,
                Last_name = Customers_description.last_name,
                Address = Customers_description.address,
                Phone = Customers_description.phone_number
            };

            var customer_by_id = customer.ToList().Find(x => x.Customers_id == id);

            if (customer_by_id == null)
            {
                return NotFound();
            }
            return customer_by_id;
        }

        /*[HttpPost]
        public async Task<IActionResult<IEnumerable<AddCustomer>>> Add_Customers(Customers customers)
        {
            foreach(var item in customers.Id)
            {
                var new_customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == item);
                new_customer.
            }

            return CreatedAtAction("GetCustomers", new { id = customers.Id }, customers);
        }*/

        [HttpPost]
        public async Task<ActionResult<AddCustomer>> Add_Customer(AddCustomer customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cust = new Customers()
            {
                Id = customerDTO.Customer_Id,
                first_name = customerDTO.Customer_first_name,
                last_name = customerDTO.Customer_last_name
            };
            await _context.Customers.AddAsync(cust);
            await _context.SaveChangesAsync();

            var customer_description = new Customers_description()
            {
                Id = cust.Id,
                first_name = cust.first_name,
                last_name = cust.last_name,
                address = customerDTO.Customer_adress,
                phone_number = customerDTO.Customer_phone
            };
            await _context.AddAsync(customer_description);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = cust.Id }, customerDTO);
        }
    }
}
