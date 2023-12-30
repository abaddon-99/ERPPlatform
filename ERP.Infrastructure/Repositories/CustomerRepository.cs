using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Orders;
using ERP.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository, IAsyncDisposable
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CustomerRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        if (_applicationDbContext.Customers is null)
        {
            throw new NullReferenceException("Customers should not be null");
        }

        return await _applicationDbContext.Customers.ToListAsync();
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        if (_applicationDbContext.Customers is null)
        {
            throw new NullReferenceException("Customers should not be null");
        }
        
        await _applicationDbContext.Customers.AddAsync(customer);
        
        return customer;
    }

    public Customer Update(Customer customer)
    {
        if (_applicationDbContext.Customers is null)
        {
            throw new NullReferenceException("Customers should not be null");
        }
        
        _applicationDbContext.Customers.Update(customer);

        return customer;
    }

    public void Remove(Customer customer)
    {
        if (_applicationDbContext.Customers is null)
        {
            throw new NullReferenceException("Customers should not be null");
        }
        
        _applicationDbContext.Customers.Remove(customer);
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        if (_applicationDbContext.Customers is null)
        {
            throw new NullReferenceException("Customers should not be null");
        }
        
        return await _applicationDbContext.Customers.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        if (_applicationDbContext.Customers is null)
        {
            throw new NullReferenceException("Customers should not be null");
        }

        return await _applicationDbContext.Customers.AnyAsync(customer => customer.Id.Equals(id));
    }

    public void Dispose()
    {
        _applicationDbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _applicationDbContext.DisposeAsync();
    }
}