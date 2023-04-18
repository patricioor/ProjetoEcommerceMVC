using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    internal interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductCategoryAsync(int? id);

        Task<Category> CreateAsync(Product product);

        Task<Category> UpdateAsync(Product product);

        Task<Category> RemoveAsync(Product product);
    }
}

