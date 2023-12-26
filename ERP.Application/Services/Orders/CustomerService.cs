using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;

namespace ERP.Application.Services.Orders;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Customer Create(Customer customer)
    {
        return _customerRepository.Create(customer);
    }

    public Customer Update(Customer customer)
    {
        return _customerRepository.Update(customer);
    }

    public bool Remove(Customer customer)
    {
        return _customerRepository.Remove(customer);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public Customer GetById(int id)
    {
        return _customerRepository.GetById(id);
    }

    public bool IsExist(int id)
    {
        return _customerRepository.IsExist(id);
    }
}