using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Orders;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;

    public OrderItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        if (_dbContext.OrderItems is null)
        {
            throw new NullReferenceException("OrderItems should not be null");
        }

        return await _dbContext.OrderItems.ToListAsync();
    }

    public async Task<OrderItem> CreateAsync(OrderItem item)
    {
        if (_dbContext.OrderItems is null)
        {
            throw new NullReferenceException("OrderItems should not be null");
        }

        var result = await _dbContext.OrderItems.AddAsync(item);
        return result.Entity;
    }

    public OrderItem Update(OrderItem item)
    {
        if (_dbContext.OrderItems is null)
        {
            throw new NullReferenceException("OrderItems should not be null");
        }

        return _dbContext.OrderItems.Update(item).Entity;
    }

    public void Remove(OrderItem item)
    {
        if (_dbContext.OrderItems is null)
        {
            throw new NullReferenceException("OrderItems should not be null");
        }

        _dbContext.OrderItems.Remove(item);
    }

    public async Task<OrderItem?> GetByIdAsync(int id)
    {
        if (_dbContext.OrderItems is null)
        {
            throw new NullReferenceException("OrderItems should not be null");
        }

        return await _dbContext.OrderItems.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_dbContext.OrderItems is null)
        {
            throw new NullReferenceException("OrderItems should not be null");
        }

        return await _dbContext.OrderItems.AnyAsync(i => i.Id.Equals(id));
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