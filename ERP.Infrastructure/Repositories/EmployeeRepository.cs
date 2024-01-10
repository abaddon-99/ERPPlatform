using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Employees;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        if (_dbContext.Employees is null)
        {
            throw new NullReferenceException("Employees should not be null");
        }

        return await _dbContext.Employees.ToListAsync();
    }

    public async Task<Employee> CreateAsync(Employee employee)
    {
        if (_dbContext.Employees is null)
        {
            throw new NullReferenceException("Employees should not be null");
        }

        await _dbContext.Employees.AddAsync(employee);
        return employee;
    }

    public Employee Update(Employee employee)
    {
        if (_dbContext.Employees is null)
        {
            throw new NullReferenceException("Employees should not be null");
        }

        _dbContext.Employees.Update(employee);
        return employee;
    }

    public void Remove(Employee employee)
    {
        if (_dbContext.Employees is null)
        {
            throw new NullReferenceException("Employees should not be null");
        }

        _dbContext.Employees.Remove(employee);
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        if (_dbContext.Employees is null)
        {
            throw new NullReferenceException("Employees should not be null");
        }

        return await _dbContext.Employees.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_dbContext.Employees is null)
        {
            throw new NullReferenceException("Employees should not be null");
        }

        return await _dbContext.Employees.AnyAsync(e => e.Id.Equals(id));
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }
}