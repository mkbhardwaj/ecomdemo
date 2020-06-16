using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _context.Products.Include(i => i.ProductBrand).Include(i => i.ProductType).ToListAsync();
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.Include(i => i.ProductBrand).Include(i => i.ProductType).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}