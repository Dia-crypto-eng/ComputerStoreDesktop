# ComputerStore WPF Application

> **⚠️ Work in Progress**  
> This project is currently under active development. Some features are incomplete or not yet implemented.

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue.svg)](https://dotnet.microsoft.com/download/dotnet-framework)
[![WPF](https://img.shields.io/badge/WPF-Windows%20Presentation%20Foundation-purple.svg)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![MVVM](https://img.shields.io/badge/Pattern-MVVM-green.svg)](https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern)
[![License](https://img.shields.io/badge/License-Unlicense-lightgrey.svg)](LICENSE)

A desktop inventory and point-of-sale management system for computer stores, built with WPF and following the MVVM architectural pattern. The application communicates with a Django REST API backend for data persistence and business logic.

## Table of Contents

- [Architecture Overview](#architecture-overview)
- [Key Components](#key-components)
- [Key Design Decisions](#key-design-decisions)
- [Getting Started](#getting-started)
- [Roadmap](#roadmap)

## Architecture Overview

The application follows the **Model-View-ViewModel (MVVM)** pattern, providing clear separation of concerns and enabling testable, maintainable code.

### MVVM Pattern

- **Models** (`Models/`): Data structures representing business entities (Product, Invoice, Client, Inventory, etc.)
- **Views** (`Views/`): XAML user interfaces organized by feature area (Home, Invoices, Inventory, Clients)
- **ViewModels** (`ViewModels/`): Presentation logic that mediates between Views and Models, implementing `INotifyPropertyChanged` for data binding
- **BaseViewModel**: Provides common functionality for all ViewModels, including property change notification

### Service Layer

- **Services** (`Services/`): Data access layer that handles HTTP communication with the Django backend API
- Services encapsulate API endpoints and JSON serialization/deserialization using `Newtonsoft.Json`
- Each service is responsible for a specific domain (ProductData, ClientData, InvoiceData, etc.)

### Cache Layer

- **Cache** (`Cache/`): Singleton pattern implementation (`CreateCache`) that provides centralized caching
- Reduces redundant API calls and improves application performance
- Cache instances are lazily initialized and shared across the application
- Available caches: `ProductCache`, `InvoiceCache`, `ClientCache`, `InventoryCache`, `DashboardCache`, `ExpensesCache`, `ReportCache`

## Key Components

| Component | Purpose | Location |
|-----------|---------|----------|
| **CreateCache** | Singleton factory for cache instances | `Cache/CreateCache.cs` |
| **BaseViewModel** | Base class for all ViewModels with property change notification | `ViewModels/BaseViewModel.cs` |
| **IInvoiceData** | Generic interface for invoice data operations | `Services/IInvoiceData.cs` |
| **MenuControl** | Navigation menu with expandable sections | `MenuControl.xaml` |
| **NumberToWordsConverter** | Converts numeric values to French words (for invoices) | `NumberToWordsConverter.cs` |

### ViewModels

- `BuyInvoiceViewModel` - Purchase invoice management
- `SellInoiceViewModel` - Sales invoice management
- `ProductViewModel` - Product catalog management
- `InventoryViewModel` - Inventory tracking
- `ClientViewModel` / `ProviderViewModel` - Customer and supplier management
- `DashboardViewModel` - Dashboard analytics (placeholder)
- `ExpensesViewModel` - Operating expenses tracking
- `ReportViewModel` - Reporting functionality (not implemented)

### Services

- `ProductData` - Product CRUD operations
- `ClientData` - Client and financial status data
- `FactureData` / `BonsData` - Invoice and receipt operations
- `InventoryData` - Inventory management
- `DashboardData` - Dashboard metrics
- `ExpensesData` - Expense tracking
- `ReportData` - Report generation (empty implementation)
- `StockData` / `PanneData` - Stock and damage tracking

## Key Design Decisions

1. **Singleton Cache Pattern**: Centralized caching via `CreateCache` singleton ensures consistent data access and reduces API load
2. **HTTP Client Reuse**: Single `HttpClient` instance shared across services for efficient connection management
3. **Material Design UI**: Uses MaterialDesignThemes for modern, consistent user interface
4. **Data Binding**: Heavy reliance on WPF data binding to minimize code-behind logic
5. **Generic Invoice Interface**: `IInvoiceData<TModel, TItemModel>` provides reusable invoice operations for both buy and sell invoices
6. **French Number Conversion**: `NumberToWordsConverter` converts invoice amounts to French text (Algerian Dinar context)
7. **API-First Architecture**: All data operations go through REST API calls to Django backend (`http://127.0.0.1:8000/`)

## Getting Started

### Prerequisites

- **.NET Framework 4.7.2** or higher
- **Visual Studio 2017** or later (with WPF workload)
- **Django Backend API** running at `http://127.0.0.1:8000/`

### Dependencies

The project uses the following NuGet packages (see `packages.config`):

- **MvvmLightLibs** (5.4.1.1) - MVVM framework
- **MaterialDesignThemes** (4.9.0) - Material Design UI components
- **MaterialDesignColors** (2.1.4) - Material Design color palette
- **LiveCharts.Wpf** (0.9.7) - Charting library
- **Newtonsoft.Json** (13.0.3) - JSON serialization
- **Microsoft.Xaml.Behaviors.Wpf** (1.1.77) - XAML behaviors
- **MathConverter** (2.2.1) - Mathematical value converters

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd ComputerStore
   ```

2. **Restore NuGet packages**
   ```bash
   nuget restore ComputerStore.sln
   ```
   Or use Visual Studio: Right-click solution → Restore NuGet Packages

3. **Configure Backend API**
   - Ensure Django backend is running at `http://127.0.0.1:8000/`
   - Update API URL in `Cache/CreateCache.cs` if needed (line 17)

4. **Build the solution**
   ```bash
   msbuild ComputerStore.sln /p:Configuration=Debug
   ```
   Or open `ComputerStore.sln` in Visual Studio and build (F6)

5. **Run the application**
   - Press F5 in Visual Studio, or
   - Execute `bin\Debug\ComputerStore.exe`

### Project Structure

```
ComputerStore/
├── Cache/              # Singleton cache implementations
├── Models/             # Data models (entities)
├── Services/           # Data access layer (API clients)
├── ViewModels/         # MVVM ViewModels
├── Views/              # XAML views
│   ├── Clients/        # Client management views
│   ├── Home/           # Dashboard and expenses
│   ├── Invoices/       # Invoice views (buy/sell)
│   └── Inventory/      # Inventory management views
├── App.xaml            # Application entry point
├── MainWindow.xaml     # Main application window
└── MenuControl.xaml    # Navigation menu
```

## Roadmap

The following features are planned or partially implemented:

### High Priority

- [ ] **Reports Module**
  - [ ] Sales Reports (`Views/Reports/` folder exists but empty)
  - [ ] Purchase Reports
  - [ ] Inventory Reports
  - [ ] Customer Reports
  - [ ] Implement `ReportViewModel` with business logic
  - [ ] Implement `ReportData` service methods

- [ ] **Delivery Management**
  - [ ] Delivery tracking feature (listed in menu but not implemented)
  - [ ] Delivery ViewModel and View
  - [ ] Delivery service integration

- [ ] **Dashboard Enhancement**
  - [ ] Replace placeholder content with live charts
  - [ ] Implement `DashboardViewModel` with real data
  - [ ] Integrate LiveCharts for visualizations

### Medium Priority

- [ ] **Product Management**
  - [ ] Complete `deleteProduct()` implementation in `ProductData`
  - [ ] Implement Firebase product sync (`getFirebaseProduct()`)

- [ ] **Number Converter**
  - [ ] Implement `ConvertBack()` method in `NumberToWordsConverter`

- [ ] **Error Handling**
  - [ ] Replace console logging with proper error handling
  - [ ] Add user-friendly error messages
  - [ ] Implement retry logic for API calls

### Low Priority

- [ ] **Code Quality**
  - [ ] Remove debug console output statements
  - [ ] Add XML documentation comments
  - [ ] Implement unit tests for ViewModels and Services
  - [ ] Add integration tests for API communication

---

**Note**: This README is based on the current codebase state. Features and implementation details may change as development progresses.
