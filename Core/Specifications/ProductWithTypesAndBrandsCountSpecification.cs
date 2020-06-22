using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Specifications
{
   public class ProductWithTypesAndBrandsCountSpecification:BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsCountSpecification(ProductSpecParams param) : base(f =>
            (string.IsNullOrEmpty(param.Search) || f.Name.ToLower().Contains(param.Search))
        && (!param.BrandId.HasValue || f.ProductBrandId == param.BrandId)
        && (!param.TypeId.HasValue || f.ProductTypeId == param.TypeId)
          )

        { }
    }
}
