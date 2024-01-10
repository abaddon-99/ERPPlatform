using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Application.Services.Employees;
using ERP.Application.Services.Inventory;
using ERP.Application.Services.Orders;
using ERP.Infrastructure.Repositories;

namespace ERP.WebAPI.Extensions;

public static class DependencyInjections
{
    public static void AddOrdersModule(this IServiceCollection services)
    {
        services.AddScoped<IPurchaseOrderService, PurchaseOrderService>().AddScoped<Lazy<IPurchaseOrderService>>(
            provider => new Lazy<IPurchaseOrderService>(provider.GetRequiredService<IPurchaseOrderService>()));

        services.AddScoped<ISalesOrderService, SalesOrderService>()
            .AddScoped<Lazy<ISalesOrderService>>(provider =>
                new Lazy<ISalesOrderService>(provider.GetRequiredService<ISalesOrderService>()));

        services.AddScoped<ICustomerService, CustomerService>().AddScoped<Lazy<ICustomerService>>(provider =>
            new Lazy<ICustomerService>(provider.GetRequiredService<ICustomerService>()));

        services.AddScoped<IOrderItemService, OrderItemService>().AddScoped<Lazy<IOrderItemService>>(provider =>
            new Lazy<IOrderItemService>(provider.GetRequiredService<IOrderItemService>()));

        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
        services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
    }

    public static void AddInventoryModule(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>().AddScoped<Lazy<ICategoryService>>(provider =>
            new Lazy<ICategoryService>(provider.GetRequiredService<ICategoryService>()));
        services.AddScoped<IProductService, ProductService>().AddScoped<Lazy<IProductService>>(provider =>
            new Lazy<IProductService>(provider.GetRequiredService<IProductService>()));
        services.AddScoped<ISupplierService, SupplierService>().AddScoped<Lazy<ISupplierService>>(provider =>
            new Lazy<ISupplierService>(provider.GetRequiredService<ISupplierService>()));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
    }

    public static void AddEmployeeModule(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>().AddScoped<Lazy<IDepartmentService>>(provider =>
            new Lazy<IDepartmentService>(provider.GetRequiredService<IDepartmentService>()));
        services.AddScoped<IEmployeeService, EmployeeService>().AddScoped<Lazy<IEmployeeService>>(provider =>
            new Lazy<IEmployeeService>(provider.GetRequiredService<IEmployeeService>()));

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }

    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>().AddTransient<Lazy<IUnitOfWork>>(provider =>
            new Lazy<IUnitOfWork>(provider.GetRequiredService<IUnitOfWork>()));
    }
}