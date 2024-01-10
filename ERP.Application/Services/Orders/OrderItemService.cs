using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;

namespace ERP.Application.Services.Orders;

public class OrderItemService : IOrderItemService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderItem> CreateAsync(OrderItem item)
    {
        var result = await _unitOfWork.OrderItems.CreateAsync(item);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public OrderItem Update(OrderItem item)
    {
        var result = _unitOfWork.OrderItems.Update(item);
        _unitOfWork.SaveChangesAsync();
        return result;
    }

    public void Remove(OrderItem item)
    {
        _unitOfWork.OrderItems.Remove(item);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
    {
        return await _unitOfWork.OrderItems.GetAllAsync();
    }

    public async Task<OrderItem?> GetByIdAsync(int id)
    {
        return await _unitOfWork.OrderItems.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.OrderItems.IsExistAsync(id);
    }
}