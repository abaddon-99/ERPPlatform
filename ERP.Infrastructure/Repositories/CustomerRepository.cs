using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities.Orders;
using ERP.Infrastructure.Migrations;

namespace ERP.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CustomerRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<Customer> GetAll()
    {
        if (_applicationDbContext.Customers != null)
        {
            return _applicationDbContext.Customers.ToList();
        }

        return new List<Customer>();
    }

    public Customer Create(Customer customer)
    {
        _applicationDbContext.Customers?.Add(customer);
        _applicationDbContext.SaveChanges();

        return customer;
    }

    public Customer Update(Customer customer)
    {
        _applicationDbContext.Customers?.Update(customer);
        _applicationDbContext.SaveChanges();

        return customer;
    }

    public bool Remove(Customer customer)
    {
        _applicationDbContext.Customers?.Remove(customer);
        if (_applicationDbContext.SaveChanges() > 0)
        {
            return true;
        }

        return false;
    }

    public Customer? GetById(int id)
    {
        return _applicationDbContext.Customers?.Find(id);
    }

    public bool IsExist(int id)
    {
        return (_applicationDbContext.Customers?.Any(customer => customer.Id == id)).GetValueOrDefault();
    }
}