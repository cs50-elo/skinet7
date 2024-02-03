
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                // read data in memory
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                // Create list with objects
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                // Add to table
                context.ProductBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            // All changes made in memory only. Check if we have to update the database.

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
            
        }


    }
}