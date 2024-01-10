using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Inventory;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        if (_dbContext.Categories is null)
        {
            throw new NullReferenceException("Categories should not be null");
        }

        return await _dbContext.Categories.Include(c => c.Products).ToListAsync();
    }

    public async Task<Category> CreateAsync(Category category)
    {
        if (_dbContext.Categories is null)
        {
            throw new NullReferenceException("Categories should not be null");
        }

        await _dbContext.AddAsync(category);
        return category;
    }

    public Category Update(Category category)
    {
        if (_dbContext.Categories is null)
        {
            throw new NullReferenceException("Categories should not be null");
        }

        _dbContext.Categories.Update(category);
        return category;
    }

    public void Remove(Category category)
    {
        if (_dbContext.Categories is null)
        {
            throw new NullReferenceException("Categories should not be null");
        }

        _dbContext.Categories.Remove(category);
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        if (_dbContext.Categories is null)
        {
            throw new NullReferenceException("Categories should not be null");
        }

        return await _dbContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id.Equals(id));
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_dbContext.Categories is null)
        {
            throw new NullReferenceException("Categories should not be null");
        }

        return await _dbContext.Categories.AnyAsync(c => c.Id.Equals(id));
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