using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Inventory;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;

    public SupplierRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        if (_dbContext.Suppliers is null)
        {
            throw new NullReferenceException("Suppliers should not be null");
        }

        return await _dbContext.Suppliers.ToListAsync();
    }

    public async Task<Supplier> CreateAsync(Supplier supplier)
    {
        if (_dbContext.Suppliers is null)
        {
            throw new NullReferenceException("Suppliers should not be null");
        }

        var result = await _dbContext.Suppliers.AddAsync(supplier);
        return result.Entity;
    }

    public Supplier Update(Supplier supplier)
    {
        if (_dbContext.Suppliers is null)
        {
            throw new NullReferenceException("Suppliers should not be null");
        }

        return _dbContext.Suppliers.Update(supplier).Entity;
    }

    public void Remove(Supplier supplier)
    {
        if (_dbContext.Suppliers is null)
        {
            throw new NullReferenceException("Suppliers should not be null");
        }

        _dbContext.Suppliers.Remove(supplier);
    }

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        if (_dbContext.Suppliers is null)
        {
            throw new NullReferenceException("Suppliers should not be null");
        }

        return await _dbContext.Suppliers.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_dbContext.Suppliers is null)
        {
            throw new NullReferenceException("Suppliers should not be null");
        }

        return await _dbContext.Suppliers.AnyAsync(s => s.Id.Equals(id));
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