using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;

using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // [controller] will tell .net runtime to user controller name for the endpoint 
    public class ProductsController : ControllerBase
    {
        private IGenericRepository<Product> _prodcutRepo { set; get; }
        private IGenericRepository<ProductBrand> _prodcutBrandRepo { set; get; }


        private IGenericRepository<ProductType> _prodcutTypeRepo { set; get; }
        public ProductsController(IGenericRepository<Product> productRepo,IGenericRepository<ProductBrand> productBrandRepo,IGenericRepository<ProductType> productTypeRepo)
        {
            _prodcutRepo = productRepo;
            _prodcutBrandRepo = productBrandRepo;
            _prodcutTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<Product>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            return await _prodcutRepo.ListAsync(spec);

        }

        [HttpGet("{id}")] // {id} will be the parameter here.
        public async Task<Product> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);

            return await _prodcutRepo.GetBySpec(spec);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyCollection<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _prodcutRepo.ListAllAsyc());

        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyCollection<ProductType>>> GetProductTypes()
        {
            return Ok(await _prodcutRepo.ListAllAsyc());

        }
    }
}