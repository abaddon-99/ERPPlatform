using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;

namespace ERP.Application.Services.Orders;

public class PurchaseOrderService : IPurchaseOrderService
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public PurchaseOrder Create(PurchaseOrder order)
    {
        return _purchaseOrderRepository.Create(order);
    }

    public PurchaseOrder Update(PurchaseOrder order)
    {
        return _purchaseOrderRepository.Update(order);
    }

    public bool Remove(PurchaseOrder order)
    {
        return _purchaseOrderRepository.Remove(order);
    }

    public IEnumerable<PurchaseOrder> GetAll()
    {
        return _purchaseOrderRepository.GetAll();
    }

    public PurchaseOrder GetById(int id)
    {
        var order = _purchaseOrderRepository.GetById(id);
        return order;
    }

    public bool IsExist(int id)
    {
        return _purchaseOrderRepository.IsExist(id);
    }
}