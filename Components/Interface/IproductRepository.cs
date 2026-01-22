using API.Entities;

namespace Api.Interface
{
    public interface IproductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();

    }
}