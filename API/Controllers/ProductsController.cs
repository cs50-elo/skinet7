

using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]    //  https://localhost:5001/products
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            // See C# Extensions settings for private field
            _context = context;
        }

        /* [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var ProductList = _context.Products.ToList();
            return ProductList;
        }
        */

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // var ProductList = await _context.Products.ToListAsync();
            // return ProductList;
            return await _context.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

    }
}