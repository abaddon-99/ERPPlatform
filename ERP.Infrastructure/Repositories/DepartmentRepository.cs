using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Employees;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _dbContext;

    public DepartmentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        if (_dbContext.Departments is null)
        {
            throw new NullReferenceException("Departments should not be null");
        }

        return await _dbContext.Departments.Include(d => d.Employees).ToListAsync();
    }

    public async Task<Department> CreateAsync(Department department)
    {
        if (_dbContext.Departments is null)
        {
            throw new NullReferenceException("Departments should not be null");
        }

        await _dbContext.Departments.AddAsync(department);
        return department;
    }

    public Department Update(Department department)
    {
        if (_dbContext.Departments is null)
        {
            throw new NullReferenceException("Departments should not be null");
        }

        _dbContext.Departments.Update(department);
        return department;
    }

    public void Remove(Department department)
    {
        if (_dbContext.Departments is null)
        {
            throw new NullReferenceException("Departments should not be null");
        }

        _dbContext.Departments.Remove(department);
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        if (_dbContext.Departments is null)
        {
            throw new NullReferenceException("Departments should not be null");
        }

        return await _dbContext.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id.Equals(id));
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_dbContext.Departments is null)
        {
            throw new NullReferenceException("Departments should not be null");
        }

        return await _dbContext.Departments.AnyAsync(d => d.Id.Equals(id));
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