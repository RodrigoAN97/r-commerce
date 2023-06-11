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

        public async Task<IReadOnlyList<Product>> GetProductsAsync(string sort)
        {
            var products = this.context.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType);

            switch (sort)
            {
                case "priceAsc":
                    products.OrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products.OrderBy(p => p.Name);
                    break;
            }

            return await products.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await this.context.ProductTypes.ToListAsync();
        }
    }
}