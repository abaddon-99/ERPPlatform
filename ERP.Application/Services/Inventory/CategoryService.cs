using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Inventory;

namespace ERP.Application.Services.Inventory;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        var result = await _unitOfWork.Categories.CreateAsync(category);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public Category Update(Category category)
    {
        var result = _unitOfWork.Categories.Update(category);
        _unitOfWork.SaveChangesAsync();
        return result;
    }

    public void Remove(Category category)
    {
        _unitOfWork.Categories.Remove(category);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _unitOfWork.Categories.GetAllAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Categories.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.Categories.IsExistAsync(id);
    }
}