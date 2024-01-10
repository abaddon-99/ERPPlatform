using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Inventory;

namespace ERP.Application.Services.Inventory;

public class SupplierService : ISupplierService
{
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Supplier> CreateAsync(Supplier supplier)
    {
        var result = await _unitOfWork.Suppliers.CreateAsync(supplier);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public Supplier Update(Supplier supplier)
    {
        var result = _unitOfWork.Suppliers.Update(supplier);
        _unitOfWork.SaveChangesAsync();
        return result;
    }

    public void Remove(Supplier supplier)
    {
        _unitOfWork.Suppliers.Remove(supplier);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        return await _unitOfWork.Suppliers.GetAllAsync();
    }

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Suppliers.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.Suppliers.IsExistAsync(id);
    }
}