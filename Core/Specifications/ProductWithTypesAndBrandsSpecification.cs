using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using core.Specifications;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInludes(p => p.ProductBrand);
            AddInludes(p => p.ProductType);
        }


        public ProductWithTypesAndBrandsSpecification(ProductSpecParams param) : base(f =>
              (string.IsNullOrEmpty(param.Search) || f.Name.ToLower().Contains(param.Search))
          && (!param.BrandId.HasValue || f.ProductBrandId == param.BrandId)
          && (!param.TypeId.HasValue || f.ProductTypeId == param.TypeId)
            )
        {
            AddInludes(p => p.ProductBrand);
            AddInludes(p => p.ProductType);
            AddOrderBy(o => o.Name);

            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "priceAsc":
                        {
                            AddOrderBy(o => o.Price);
                            break;
                        }
                    case "priceDesc":
                        {
                            AddOrderByDesc(o => o.Price);
                            break;
                        }
                    default:
                        AddOrderBy(o => o.Name);
                        break;

                }

            }
            AddPagination((param.PageIndex - 1) * param.PageSize, param.PageSize);
        }


    }
}

