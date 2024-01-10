using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Inventory;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class ProductRepository : IProductRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        if (_dbContext.Products is null)
        {
            throw new NullReferenceException("Products should not be null");
        }

        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        if (_dbContext.Products is null)
        {
            throw new NullReferenceException("Products should not be null");
        }

        var result = await _dbContext.Products.AddAsync(product);
        return result.Entity;
    }

    public Product Update(Product product)
    {
        if (_dbContext.Products is null)
        {
            throw new NullReferenceException("Products should not be null");
        }

        return _dbContext.Products.Update(product).Entity;
    }

    public void Remove(Product product)
    {
        if (_dbContext.Products is null)
        {
            throw new NullReferenceException("Products should not be null");
        }

        _dbContext.Products.Remove(product);
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        if (_dbContext.Products is null)
        {
            throw new NullReferenceException("Products should not be null");
        }

        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_dbContext.Products is null)
        {
            throw new NullReferenceException("Products should not be null");
        }

        return await _dbContext.Products.AnyAsync(p => p.Id.Equals(id));
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }
}