using API.Entities;

namespace Api.Interface
{
    public interface IproductBrandRepository
    {
        public Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        public Task<ProductBrand> GetProductBrandByIdAsync(int id);
    }
}