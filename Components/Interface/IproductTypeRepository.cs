using API.Entities;

namespace API.Interface
{
    public interface IproductTypeRepository
    {
        public Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        public Task<ProductType> GetProductTypeByIdAsync(int id);
    }
}