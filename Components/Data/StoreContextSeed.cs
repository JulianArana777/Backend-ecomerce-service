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
                // Obtenemos la ruta base del directorio de trabajo actual
                // Esto ayuda a que "Data/archivo.json" se encuentre correctamente
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Components", "Data");

                if (!context.ProductsBrand.Any())
                {
                    var brandsData = await File.ReadAllTextAsync(Path.Combine(path, "brands.json"));
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if (brands != null) context.ProductsBrand.AddRange(brands);
                }

                if (!context.ProductsType.Any())
                {
                    var typesData = await File.ReadAllTextAsync(Path.Combine(path, "types.json"));
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if (types != null) context.ProductsType.AddRange(types);
                }

                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync(Path.Combine(path, "products.json"));
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products != null) context.Products.AddRange(products);
                }

                if (context.ChangeTracker.HasChanges())
                    await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Agregamos un log más descriptivo para ver la ruta que falló
                Console.WriteLine($"Error en Seeding: {ex.Message}");
                throw;
            }
        }
    }
}