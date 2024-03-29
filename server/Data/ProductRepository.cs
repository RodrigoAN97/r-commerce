using Microsoft.EntityFrameworkCore;
using server.Core.Entities;
using server.Core.Interfaces;

namespace server.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;
        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await this.context.ProductBrands.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await this.context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await this.context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await this.context.ProductTypes.ToListAsync();
        }
    }
}