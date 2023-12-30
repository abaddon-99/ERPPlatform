using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;

namespace ERP.Application.Services.Orders;

public class SalesOrderService : ISalesOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public SalesOrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<SalesOrder> CreateAsync(SalesOrder order)
    {
        await _unitOfWork.SalesOrders.CreateAsync(order);
        await _unitOfWork.SaveChangesAsync();

        return order;
    }

    public SalesOrder Update(SalesOrder order)
    {
        _unitOfWork.SalesOrders.Update(order);
        _unitOfWork.SaveChangesAsync();
        
        return order;
    }

    public void Remove(SalesOrder order)
    {
        _unitOfWork.SalesOrders.Remove(order);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<SalesOrder>> GetAllAsync()
    {
        return await _unitOfWork.SalesOrders.GetAllAsync();
    }

    public async Task<SalesOrder?> GetByIdAsync(int id)
    {
        return await _unitOfWork.SalesOrders.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.SalesOrders.IsExistAsync(id);
    }
}