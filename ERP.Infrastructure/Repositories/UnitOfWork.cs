using ERP.Application.Interfaces.Repositories;
using ERP.Infrastructure.Migrations;

namespace ERP.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;
    // private readonly IDictionary<Type, object> _repositories;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        Customers = new CustomerRepository(_applicationDbContext);
        SalesOrders = new SalesOrderRepository(_applicationDbContext);
        PurchaseOrders = new PurchaseOrderRepository(_applicationDbContext);
        // _repositories = new Dictionary<Type, object>();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _applicationDbContext.SaveChangesAsync();
    }

    public async Task RollBackChangesAsync()
    {
        await _applicationDbContext.Database.RollbackTransactionAsync();
    }

    public ICustomerRepository Customers { get; }
    public ISalesOrderRepository SalesOrders { get; }
    public IPurchaseOrderRepository PurchaseOrders { get; }

    // public IBaseRepository<T> Repository<T>() where T : class
    // {
    //     var entityType = typeof(T);
    //     if (_repositories.ContainsKey(entityType))
    //     {
    //         return (IBaseRepository<T>)_repositories[entityType]; //Ask about correctness
    //     }
    //
    //     var repositoryType = typeof(IBaseRepository<>);
    //
    //     var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _applicationDbContext);
    //     if (repository is null)
    //     {
    //         throw new NullReferenceException("Repository should not be null");
    //     }
    //     
    //     _repositories.Add(entityType, repository);
    //     return (IBaseRepository<T>)repository;
    // }
}