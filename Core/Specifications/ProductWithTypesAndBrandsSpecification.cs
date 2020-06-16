using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification: BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(int id):base(x=> x.Id == id)
        {
            AddInludes(p => p.ProductBrand);
            AddInludes(p => p.ProductType);
        }
        public ProductWithTypesAndBrandsSpecification() {
            AddInludes(p => p.ProductBrand);
            AddInludes(p => p.ProductType);
        }
    }
}
