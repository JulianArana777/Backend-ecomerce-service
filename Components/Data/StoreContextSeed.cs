using System.Text.Json;
using API.Entities;
using API.Repository;

namespace API.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            try
            {
                // 1. Cargar Marcas
                if (!context.ProductsBrand.Any())
                {
                    var brandsData = await File.ReadAllTextAsync("../ApiBackend/Components/Data/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    context.ProductsBrand.AddRange(brands);
                }

                // 2. Cargar Tipos
                if (!context.ProductsType.Any())
                {
                    var typesData = await File.ReadAllTextAsync("../ApiBackend/Components/Data/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    context.ProductsType.AddRange(types);
                }

                // 3. Cargar Productos
                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync("../ApiBackend/Components/Data/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    context.Products.AddRange(products);
                }

                // Guardar todos los cambios en la DB
                if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Aquí podrías loguear el error si es necesario
                throw;
            }
        }
    }
}