namespace ERP.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task RollBackChangesAsync();
        ICustomerRepository Customers { get; }
        ISalesOrderRepository SalesOrders { get; }
        IPurchaseOrderRepository PurchaseOrders { get; }
        // IBaseRepository<T> Repository<T>() where T : class;
    }
}