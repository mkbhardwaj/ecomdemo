using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // [controller] will tell .net runtime to user controller name for the endpoint 
    public class ProductsController : ControllerBase
    {
        private StoreContext _storeContext { set; get; }

        public ProductsController(StoreContext context)
        {
            _storeContext = context;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await _storeContext.Products.ToListAsync();
        }

        [HttpGet("{id}")] // {id} will be the parameter here.
        public async Task<Product> GetProduct(int id)
        {
            return await _storeContext.Products.FindAsync(id);
        }
    }
}