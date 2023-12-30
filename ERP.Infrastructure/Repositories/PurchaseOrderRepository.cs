using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Orders;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class PurchaseOrderRepository : IPurchaseOrderRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _applicationDbContext;

    public PurchaseOrderRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
    {
        if (_applicationDbContext.PurchaseOrders is null)
        {
            throw new NullReferenceException("PurchaseOrders should not be null");
        }
        
        return await _applicationDbContext.PurchaseOrders.ToListAsync();
    }

    public async Task<PurchaseOrder> CreateAsync(PurchaseOrder order)
    {
        if (_applicationDbContext.PurchaseOrders is null)
        {
            throw new NullReferenceException("PurchaseOrders should not be null");
        }
        
        await _applicationDbContext.PurchaseOrders.AddAsync(order);
        
        return order;
    }

    public PurchaseOrder Update(PurchaseOrder order)
    {
        if (_applicationDbContext.PurchaseOrders is null)
        {
            throw new NullReferenceException("PurchaseOrders should not be null");
        }
        
        _applicationDbContext.PurchaseOrders.Update(order);

        return order;
    }

    public void Remove(PurchaseOrder order)
    {
        if (_applicationDbContext.PurchaseOrders is null)
        {
            throw new NullReferenceException("PurchaseOrders should not be null");
        }
        
        _applicationDbContext.PurchaseOrders.Remove(order);
    }

    public async Task<PurchaseOrder?> GetByIdAsync(int id)
    {
        if (_applicationDbContext.PurchaseOrders is null)
        {
            throw new NullReferenceException("PurchaseOrders should not be null");
        }
        
        return await _applicationDbContext.PurchaseOrders.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_applicationDbContext.PurchaseOrders is null)
        {
            throw new NullReferenceException("PurchaseOrders should not be null");
        }
        
        return await _applicationDbContext.PurchaseOrders.AnyAsync(order => order.Id.Equals(id));
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