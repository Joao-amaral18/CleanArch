﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    ApplicationDbContext _productContext;
    public ProductRepository(ApplicationDbContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _productContext.Products.Add(product);
        await  _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        return await  _productContext.Products.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        return await _productContext.Products.Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == id) ?? throw new InvalidOperationException();
        
    }
    public async Task<IEnumerable<Product>> GetProductAsync()
    {
        return await _productContext.Products.ToListAsync() ?? throw new InvalidOperationException();
    } 

    public async Task<Product> UpdateAsync(Product product)
    {
        _productContext.Products.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _productContext.Products.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}