using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Orders;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class SalesOrderRepository : ISalesOrderRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public SalesOrderRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<SalesOrder> GetAll()
    {
        if (_applicationDbContext.SalesOrders != null)
        {
            return _applicationDbContext.SalesOrders.Include(c => c.Customer).ToList();
        }

        return new List<SalesOrder>();
    }

    public SalesOrder Create(SalesOrder order)
    {
        _applicationDbContext.SalesOrders?.Add(order);
        _applicationDbContext.SaveChanges();

        return order;
    }

    public SalesOrder Update(SalesOrder order)
    {
        _applicationDbContext.SalesOrders?.Update(order);
        _applicationDbContext.SaveChanges();

        return order;
    }

    public bool Remove(SalesOrder order)
    {
        _applicationDbContext.SalesOrders?.Remove(order);
        if (_applicationDbContext.SaveChanges() > 0)
        {
            return true;
        }

        return false;
    }

    public SalesOrder? GetById(int id)
    {
        return _applicationDbContext.SalesOrders?.Include(o => o.Customer).FirstOrDefault(o => o.Id.Equals(id));
    }

    public bool IsExist(int id)
    {
        return (_applicationDbContext.SalesOrders?.Any(order => order.Id == id)).GetValueOrDefault();
    }
}