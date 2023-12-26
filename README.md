**Monolithic ERP Platform Overview:**

In a monolithic architecture, all modules and functionalities of the ERP system are tightly integrated into a single application.

**Architecture:**

1. **ASP .NET Web Application:**
   - The entire ERP system is contained within a single ASP .NET web application.
   - Handles all modules, including inventory management, order processing, and employee management.

2. **EF Core and SQL Server:**
   - **Monolithic Database:** A single database stores all inventory, orders, and employee data.
   - Manages data relationships and transactions within the monolith.

**Workflow:**

1. **User Authentication and Authorization:**
   - Users log in through the ASP .NET web application.
   - The application authenticates users and authorizes access to different modules.

2. **Inventory Management:**
   - The monolithic application manages the product catalog, stock levels, and order fulfillment.
   - Users can view product details, check stock levels, and place orders.
   - Changes in stock levels are directly managed within the monolithic application.

3. **Order Processing:**
   - The application handles order creation, processing, and fulfillment.
   - Manages communication with the inventory system directly within the monolith.
   - Sends order status updates without relying on a separate service.

4. **Employee Management:**
   - Manages employee records, and payroll directly within the monolithic application.
   - Users can view and update employee information.
   - Attendance records and payroll updates are managed within the monolith.

**Technology Stack:**
- ASP .NET for the monolithic web application.
- EF Core for database access.
- SQLite for storing all data.
