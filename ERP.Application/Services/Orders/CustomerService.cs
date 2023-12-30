using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Domain.Entities.Orders;

namespace ERP.Application.Services.Orders;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _unitOfWork.Customers.CreateAsync(customer);
        await _unitOfWork.SaveChangesAsync();
        return customer;
    }

    public Customer Update(Customer customer)
    {
        _unitOfWork.Customers.Update(customer);
        _unitOfWork.SaveChangesAsync();
        return customer;
    }

    public void Remove(Customer customer)
    {
        _unitOfWork.Customers.Remove(customer);
        _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _unitOfWork.Customers.GetAllAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Customers.GetByIdAsync(id);
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _unitOfWork.Customers.IsExistAsync(id);
    }
}