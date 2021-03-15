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
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetProducts()
        {
            var product = from products in _context.Products
            join product_descriptions in _context.Products_Descriptions on products.Id equals product_descriptions.Id
            select new ProductsDTO
            {
                Products_id = products.Id,
                Product_name = product_descriptions.product_name,
                Product_description = product_descriptions.product_description,
                Price = product_descriptions.price
            };
            return await product.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductsDTO> GetProducts_byId(int id)
        {
            var product = from products in _context.Products
            join product_descriptions in _context.Products_Descriptions on products.Id equals product_descriptions.Id
            select new ProductsDTO
            {
                Products_id = products.Id,
                Product_name = product_descriptions.product_name,
                Product_description = product_descriptions.product_description,
                Price = product_descriptions.price
            };

            var product_by_id = product.ToList().Find(x => x.Products_id == id);

            if (product_by_id == null)
            {
                return NotFound();
            }
            return product_by_id;
        }

        [HttpPost]
        public async Task<ActionResult<AddProduct>> Add_Product(AddProduct productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pro = new Products()
            {
                Id = productDTO.Product_Id,
                price = productDTO.Product_price,
                name = productDTO.Product_name
            };
            await _context.Products.AddAsync(pro);
            await _context.SaveChangesAsync();

            var product_description = new Products_description()
            {
                Id = pro.Id,
                price = pro.price,
                product_name = pro.name,
                product_description = productDTO.Product_description
            };
            await _context.AddAsync(product_description);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = pro.Id }, productDTO);
        }
    }
}