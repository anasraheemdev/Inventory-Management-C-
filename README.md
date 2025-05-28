# Inventory Management System (C# WPF)

A comprehensive inventory management system built with C# and WPF, designed to streamline product management, user administration, and sales tracking for businesses.

## 🚀 Features

### Core Functionality
- **Product Management**: Add, edit, and track products with unique IDs
- **User Management**: Admin and cashier role-based access control
- **Invoice Generation**: Create and manage sales invoices
- **Stock Tracking**: Monitor inventory levels and stock movements
- **Purchase Records**: Track and manage purchase history
- **Dashboard**: Centralized view of key metrics and operations

### User Roles
- **Admin**: Full system access including user management and system configuration
- **Cashier**: Access to sales operations and product information

## 🛠️ Technology Stack

- **Framework**: .NET 8.0 (Windows)
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Database**: Entity Framework Core with SQL Server
- **Architecture**: MVVM Pattern
- **Language**: C#

## 📁 Project Structure

```
Inventory-Management-C-/
├── Models/                     # Data models and entities
├── Views/                      # XAML user interface files
│   ├── MainWindow.xaml         # Main application window
│   ├── LoginPage.xaml          # User authentication
│   ├── ProductsPage.xaml       # Product management interface
│   ├── AddProductPage.xaml     # Add new products
│   ├── Invoice.xaml            # Invoice generation
│   └── ...
├── ViewModels/                 # Business logic and data binding
├── Utilities/                  # Helper classes and converters
├── App.xaml                    # Application configuration
└── FinalDB.csproj             # Project configuration
```

## 🎯 Key Components

### Authentication System
- Role-based login (Admin/Cashier)
- Secure user registration and management
- Session management

### Product Management
- Add new products with detailed information
- Edit existing product details by ID
- Real-time data fetching and updates
- Product categorization and organization

### Inventory Tracking
- Stock level monitoring
- Purchase record management
- Automated inventory updates
- Low stock alerts

### Sales & Invoicing
- Generate professional invoices
- Track sales transactions
- Customer management
- Payment processing

## 🚦 Getting Started

### Prerequisites
- Windows 10/11
- .NET 8.0 SDK
- SQL Server (LocalDB or Express)
- Visual Studio 2022 (recommended)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/anasraheemdev/Inventory-Management-C-.git
   cd Inventory-Management-C-
   ```

2. **Open the project**
   ```bash
   # Using Visual Studio
   start FinalDB.sln
   
   # Or using command line
   dotnet restore
   ```

3. **Configure Database**
   - Update connection string in `App.config` or `appsettings.json`
   - Run database migrations
   ```bash
   dotnet ef database update
   ```

4. **Build and Run**
   ```bash
   dotnet build
   dotnet run
   ```

## 💻 Usage

### First Time Setup
1. Launch the application
2. Create an admin account through the registration process
3. Login with admin credentials
4. Set up initial product categories and users
5. Begin adding products to inventory

### Daily Operations
- **Cashiers**: Handle sales transactions and generate invoices
- **Admins**: Manage inventory, users, and view comprehensive reports
- **Stock Management**: Monitor levels and create purchase orders

## 🔧 Configuration

### Database Configuration
Update the connection string in your configuration file:
```xml
<connectionStrings>
    <add name="DefaultConnection" 
         connectionString="Server=(localdb)\\mssqllocaldb;Database=InventoryDB;Trusted_Connection=true" />
</connectionStrings>
```

### User Roles
- **Admin**: Full system access
- **Cashier**: Limited to sales and basic product viewing

## 📊 Recent Updates

- ✅ **Product Data Fetching**: Enhanced product section with real-time data
- ✅ **Edit by ID**: Product editing functionality using unique identifiers
- ✅ **Database Integration**: Complete user registration and management
- ✅ **UI Improvements**: Consistent theming across all pages
- ✅ **Model Integration**: Robust data models for all entities

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Anas Raheem**
- GitHub: [@anasraheemdev](https://github.com/anasraheemdev)

## 📞 Support

If you encounter any issues or have questions:
1. Check the [Issues](https://github.com/anasraheemdev/Inventory-Management-C-/issues) section
2. Create a new issue with detailed description
3. Contact the developer through GitHub

## 🎯 Future Enhancements

- [ ] Barcode scanning integration
- [ ] Advanced reporting and analytics
- [ ] Multi-location inventory support
- [ ] Mobile app companion
- [ ] Cloud synchronization
- [ ] Advanced user permissions
- [ ] Automated reorder points
- [ ] Integration with accounting software

---

⭐ **Star this repository if you find it helpful!**
