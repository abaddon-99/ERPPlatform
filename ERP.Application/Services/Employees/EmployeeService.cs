using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Employees;

namespace ERP.Application.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        var result = await _unitOfWork.Employees.CreateAsync(employee);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public Employee Update(Employee employee)
    {
        var result = _unitOfWork.Employees.Update(employee);
        _unitOfWork.SaveChangesAsync();
        return result;
    }

    public void Remove(Employee employee)
    {
        _unitOfWork.Employees.Remove(employee);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _unitOfWork.Employees.GetAllAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Employees.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.Employees.IsExistAsync(id);
    }
}