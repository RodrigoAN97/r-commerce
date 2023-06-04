using server.Core.Entities;

namespace server.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    }
}