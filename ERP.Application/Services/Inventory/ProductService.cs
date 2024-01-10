using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Inventory;

namespace ERP.Application.Services.Inventory;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        var result = await _unitOfWork.Products.CreateAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public Product Update(Product product)
    {
        var result = _unitOfWork.Products.Update(product);
        _unitOfWork.SaveChangesAsync();
        return result;
    }

    public void Remove(Product product)
    {
        _unitOfWork.Products.Remove(product);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _unitOfWork.Products.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Products.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.Products.IsExistAsync(id);
    }
}