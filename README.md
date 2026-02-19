## ComputerStore WPF Application

- **Architecture (MVVM)**  
  - Views, ViewModels, and Models are clearly separated for maintainable, testable code.  
  - Uses DataBinding and Commands to keep UI logic out of code-behind.

- **Technical Edge (Singleton Cache & Service Layer)**  
  - Centralized Singleton Cache layer minimizes redundant database and service calls.  
  - Dedicated Service layer handles business logic and data access, improving performance and reusability.

- **Core Features (Dynamic, Data-Driven UI)**  
  - Rich DataBinding for product and invoice data.  
  - Command-based actions for user operations (e.g., add/update invoices, manage products).  
  - Dynamic UI updates for product specifications and invoice details without manual refresh.

