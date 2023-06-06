using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext _productContext;
    public ProductRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }
    public async Task<IEnumerable<Product>> GetProductCategoryAsync()
    {
        _productContext.
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        return  await _productContext.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        throw new NotImplementedException();
    }
}