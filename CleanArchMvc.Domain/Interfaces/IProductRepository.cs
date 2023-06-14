using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product);
    Task<Product> GetByIdAsync(int? id);
    Task<Product> GetProductCategoryAsync(int? id);
    Task<IEnumerable<Product>> GetProductAsync();
    Task<Product> UpdateAsync(Product product);
    Task<Product> RemoveAsync(Product product);
}