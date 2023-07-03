using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Talabat.Repository.Entites;
using Talabat.Service.Data;

public static class StoreContextDataSeeding
{
    public static async Task SeedASync(StoreDbConetxt Context, ILoggerFactory loggerFactory)
    {
        

        try
        {
            // Read the JSON file
            if (!Context.ProductBrand.Any())
            {
                string brandsdata = File.ReadAllText("C:\\Users\\faara\\source\\repos\\Talabat.APIs1\\Talabat.Service\\Data\\DataSeeding\\Files\\brands.json");

                // Deserialize the JSON data into objects

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                foreach (var brand in brands)
                {
                    Context.Set<ProductBrand>()
                        .Add(brand);
                }
            }

            if (!Context.ProductType.Any())
            {
                // Deserialize the JSON data into objects
                string typesdata = File.ReadAllText("C:\\Users\\faara\\source\\repos\\Talabat.APIs1\\Talabat.Service\\Data\\DataSeeding\\Files\\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                foreach (var  type in types)
                {
                    Context.Set<ProductType>()
                        .Add(type);
                }
            }

            if (!Context.Products.Any())
            {
                // Deserialize the JSON data into objects
                string productdata = File.ReadAllText("C:\\Users\\faara\\source\\repos\\Talabat.APIs1\\Talabat.Service\\Data\\DataSeeding\\Files\\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productdata);
                foreach (var product in products)
                {
                    Context.Set<Product>()
                        .Add(product);
                }
            }





            await Context.SaveChangesAsync();   

        
        }
        catch (Exception ex)
        {
           var logger = loggerFactory.CreateLogger<StoreDbConetxt>();
            logger.LogError(ex, ex.Message);
        }
    }
}