using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;

namespace ERP.Application.Services.Orders;

public class SalesOrderService : ISalesOrderService
{
    private readonly ISalesOrderRepository _salesOrderRepository;

    public SalesOrderService(ISalesOrderRepository salesOrderRepository)
    {
        _salesOrderRepository = salesOrderRepository;
    }

    public SalesOrder Create(SalesOrder order)
    {
        return _salesOrderRepository.Create(order);
    }

    public SalesOrder Update(SalesOrder order)
    {
        return _salesOrderRepository.Update(order);
    }

    public bool Remove(SalesOrder order)
    {
        return _salesOrderRepository.Remove(order);
    }

    public IEnumerable<SalesOrder> GetAll()
    {
        return _salesOrderRepository.GetAll();
    }

    public SalesOrder GetById(int id)
    {
        var order = _salesOrderRepository.GetById(id);
        return order;
    }

    public bool IsExist(int id)
    {
        return _salesOrderRepository.IsExist(id);
    }
}