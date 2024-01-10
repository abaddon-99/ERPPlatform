using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Employees;

namespace ERP.Application.Services.Employees;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Department> CreateAsync(Department department)
    {
        var result = await _unitOfWork.Departments.CreateAsync(department);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public Department Update(Department department)
    {
        var result = _unitOfWork.Departments.Update(department);
        _unitOfWork.SaveChangesAsync();
        return result;
    }

    public void Remove(Department department)
    {
        _unitOfWork.Departments.Remove(department);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _unitOfWork.Departments.GetAllAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Departments.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.Departments.IsExistAsync(id);
    }
}