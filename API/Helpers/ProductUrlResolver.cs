using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using Core.Entities;
using API.DTO;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product,ProductToReturnDto,string>
    {
       private IConfiguration _configuration { set; get; }
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
