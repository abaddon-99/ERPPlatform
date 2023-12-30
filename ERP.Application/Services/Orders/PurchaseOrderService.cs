using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;

namespace ERP.Application.Services.Orders;

public class PurchaseOrderService : IPurchaseOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    public PurchaseOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PurchaseOrder> CreateAsync(PurchaseOrder order)
    {
        await _unitOfWork.PurchaseOrders.CreateAsync(order);
        await _unitOfWork.SaveChangesAsync(); // Add try catch and do rollback
        return order;
    }

    public PurchaseOrder Update(PurchaseOrder order)
    {
        _unitOfWork.PurchaseOrders.Update(order);
        _unitOfWork.SaveChangesAsync();
        return order;
    }

    public void Remove(PurchaseOrder order)
    {
        _unitOfWork.PurchaseOrders.Remove(order);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
    {
        return await _unitOfWork.PurchaseOrders.GetAllAsync();
    }

    public async Task<PurchaseOrder?> GetByIdAsync(int id)
    {
        return await _unitOfWork.PurchaseOrders.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.PurchaseOrders.IsExistAsync(id);
    }
}