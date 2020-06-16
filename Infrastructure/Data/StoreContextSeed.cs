using System;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductTypes.Any())
                {
                    var jsonTypes = File.ReadAllText("../Infrastructure/Data/seed/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(jsonTypes);

                    context.ProductTypes.AddRange(types);
                    await context.SaveChangesAsync();
                }
                if (!context.ProductBrands.Any())
                {
                    var jsontBrands = File.ReadAllText("../Infrastructure/Data/seed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(jsontBrands);


                    context.ProductBrands.AddRange(brands);
                    await context.SaveChangesAsync();
                }


                if (!context.Products.Any())
                {
                    var jsontProduct = File.ReadAllText("../Infrastructure/Data/seed/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(jsontProduct);
                    context.Products.AddRange(products);
                    await context.SaveChangesAsync();
                }



            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError("Error while seeding data" + e.Message);
                var i = e.InnerException;
                while (true)
                {
                    if (i == null)
                    {
                        break;
                    }
                    else
                    {
                        logger.LogError(i.Message);
                        i = i.InnerException;
                    }

                }
            }

        }

    }
}