

using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]    //  https://localhost:5001/products
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        //public ProductsController(StoreContext context)
        public ProductsController(IProductRepository repo)
        {
            // See C# Extensions settings for private field
            _repo = repo;
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
            // return await _context.Products.ToListAsync();
            var l = await _repo.GetProductsAsync();
            return Ok(l);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }



    }
}