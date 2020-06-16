using System;
namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { set; get; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { set; get; }
    }
}