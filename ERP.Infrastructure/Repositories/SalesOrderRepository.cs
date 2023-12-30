using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Orders;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class SalesOrderRepository : ISalesOrderRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _applicationDbContext;

    public SalesOrderRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<SalesOrder>> GetAllAsync()
    {
        if (_applicationDbContext.SalesOrders is null)
        {
            throw new NullReferenceException("SalesOrders should not be null");
        }
        
        return await _applicationDbContext.SalesOrders.Include(c => c.Customer).ToListAsync();
    }

    public async Task<SalesOrder> CreateAsync(SalesOrder order)
    {
        if (_applicationDbContext.SalesOrders is null)
        {
            throw new NullReferenceException("SalesOrders should not be null");
        }
        
        await _applicationDbContext.SalesOrders.AddAsync(order);

        return order;
    }

    public SalesOrder Update(SalesOrder order)
    {
        if (_applicationDbContext.SalesOrders is null)
        {
            throw new NullReferenceException("SalesOrders should not be null");
        }
        
        _applicationDbContext.SalesOrders.Update(order);

        return order;
    }

    public void Remove(SalesOrder order)
    {
        if (_applicationDbContext.SalesOrders is null)
        {
            throw new NullReferenceException("SalesOrders should not be null");
        }
        
        _applicationDbContext.SalesOrders.Remove(order);
    }

    public async Task<SalesOrder?> GetByIdAsync(int id)
    {
        if (_applicationDbContext.SalesOrders is null)
        {
            throw new NullReferenceException("SalesOrders should not be null");
        }

        return await _applicationDbContext.SalesOrders.Include(o => o.Customer).FirstOrDefaultAsync(o => o.Id.Equals(id));
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_applicationDbContext.SalesOrders is null)
        {
            throw new NullReferenceException("SalesOrders should not be null");
        }

        return await _applicationDbContext.SalesOrders.AnyAsync(order => order.Id.Equals(id));
    }

    public void Dispose()
    {
        _applicationDbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _applicationDbContext.DisposeAsync();
    }
}