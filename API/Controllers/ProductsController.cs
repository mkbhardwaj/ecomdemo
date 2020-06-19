using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;

using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.DTO;
using Microsoft.AspNetCore.Http;
using API.Errors;

namespace API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")] // [controller] will tell .net runtime to user controller name for the endpoint 
    public class ProductsController : BaseApiController
    {
        private IGenericRepository<Product> _prodcutRepo { set; get; }
        private IGenericRepository<ProductBrand> _prodcutBrandRepo { set; get; }
        private IGenericRepository<ProductType> _prodcutTypeRepo { set; get; }
        private IMapper _mapper { set; get; }
        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _prodcutRepo = productRepo;
            _prodcutBrandRepo = productBrandRepo;
            _prodcutTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var products = await _prodcutRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyCollection<Product>, IReadOnlyCollection<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")] // {id} will be the parameter here.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);

            var product = await _prodcutRepo.GetBySpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));

                return Ok(_mapper.Map<Product, ProductToReturnDto>(product));

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