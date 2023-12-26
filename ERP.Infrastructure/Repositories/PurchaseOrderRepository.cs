using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Orders;
using ERP.Infrastructure.Migrations;

namespace ERP.Infrastructure.Repositories;

public class PurchaseOrderRepository : IPurchaseOrderRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public PurchaseOrderRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<PurchaseOrder> GetAll()
    {
        if (_applicationDbContext.PurchaseOrders != null)
        {
            return _applicationDbContext.PurchaseOrders.ToList();
        }

        return new List<PurchaseOrder>();
    }

    public PurchaseOrder Create(PurchaseOrder order)
    {
        _applicationDbContext.PurchaseOrders?.Add(order);
        _applicationDbContext.SaveChanges();

        return order;
    }

    public PurchaseOrder Update(PurchaseOrder order)
    {
        _applicationDbContext.PurchaseOrders?.Update(order);
        _applicationDbContext.SaveChanges();

        return order;
    }

    public bool Remove(PurchaseOrder order)
    {
        _applicationDbContext.PurchaseOrders?.Remove(order);
        if (_applicationDbContext.SaveChanges() > 0)
        {
            return true;
        }

        return false;
    }

    public PurchaseOrder? GetById(int id)
    {
        return _applicationDbContext.PurchaseOrders?.Find(id);
    }

    public bool IsExist(int id)
    {
        return (_applicationDbContext.PurchaseOrders?.Any(order => order.Id == id)).GetValueOrDefault();
    }
}