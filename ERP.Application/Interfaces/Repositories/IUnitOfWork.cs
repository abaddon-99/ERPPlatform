namespace ERP.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task RollBackChangesAsync();
        ICustomerRepository Customers { get; }
        ISalesOrderRepository SalesOrders { get; }
        IPurchaseOrderRepository PurchaseOrders { get; }
        IOrderItemRepository OrderItems { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        // IBaseRepository<T> Repository<T>() where T : class;
    }
}