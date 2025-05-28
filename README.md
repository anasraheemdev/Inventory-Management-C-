# 🏪 Inventory Management System (C# WPF)

<div align="center">

![Inventory Management Database Design](https://www.outsystems.com/blog/-/media/images/blog/posts/designing-a-database/image-inside-bp-designing-your-first-database.png?updated=20211109152408&h=358&w=750&hash=6FE71FF77837DD052AA85D917448DB88)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![WPF](https://img.shields.io/badge/WPF-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

[![GitHub stars](https://img.shields.io/github/stars/anasraheemdev/Inventory-Management-C-?style=social)](https://github.com/anasraheemdev/Inventory-Management-C-/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/anasraheemdev/Inventory-Management-C-?style=social)](https://github.com/anasraheemdev/Inventory-Management-C-/network/members)
[![GitHub issues](https://img.shields.io/github/issues/anasraheemdev/Inventory-Management-C-?color=red)](https://github.com/anasraheemdev/Inventory-Management-C-/issues)
[![GitHub license](https://img.shields.io/github/license/anasraheemdev/Inventory-Management-C-?color=blue)](https://github.com/anasraheemdev/Inventory-Management-C-/blob/main/LICENSE)

🎯 **A comprehensive inventory management system built with C# and WPF, designed to streamline product management, user administration, and sales tracking for businesses.**

[🚀 Getting Started](#-getting-started) • [📖 Documentation](#-key-components) • [🤝 Contributing](#-contributing) • [⭐ Star](#-inventory-management-system-c-wpf)

</div>

---

## 🌟 Features Overview

<table>
<tr>
<td>

### 🛍️ **Product Management**
- ✅ Add new products with detailed info
- ✅ Edit existing products by ID
- ✅ Real-time data synchronization
- ✅ Advanced product categorization
- ✅ Bulk operations support

</td>
<td>

### 👥 **User Management** 
- ✅ Role-based access control
- ✅ Admin & Cashier permissions
- ✅ Secure authentication system
- ✅ User activity tracking
- ✅ Account management portal

</td>
</tr>
<tr>
<td>

### 📊 **Inventory Tracking**
- ✅ Real-time stock monitoring
- ✅ Low stock alerts
- ✅ Purchase history tracking
- ✅ Automated inventory updates
- ✅ Stock movement reports

</td>
<td>

### 🧾 **Sales & Invoicing**
- ✅ Professional invoice generation
- ✅ Transaction history
- ✅ Customer management
- ✅ Payment processing
- ✅ Sales analytics dashboard

</td>
</tr>
</table>

---

## 🎨 User Interface Preview

<div align="center">

```mermaid
graph TD
    A[🏠 Main Dashboard] --> B[👤 Login System]
    A --> C[📦 Product Management]
    A --> D[📊 Inventory Tracking]
    A --> E[🧾 Invoice Generation]
    
    B --> F[👑 Admin Panel]
    B --> G[💼 Cashier Panel]
    
    C --> H[➕ Add Products]
    C --> I[✏️ Edit Products]
    C --> J[🗑️ Delete Products]
    
    D --> K[📈 Stock Levels]
    D --> L[⚠️ Low Stock Alerts]
    D --> M[📋 Purchase Records]
    
    E --> N[🧾 Create Invoice]
    E --> O[👥 Customer Management]
    E --> P[💰 Payment Processing]
    
    style A fill:#e1f5fe
    style B fill:#f3e5f5
    style C fill:#e8f5e8
    style D fill:#fff3e0
    style E fill:#fce4ec
```

</div>

---

## 🛠️ Technology Stack

<div align="center">

| Category | Technology | Version | Purpose |
|----------|------------|---------|---------|
| 🖥️ **Framework** | ![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet) | 8.0 | Application Runtime |
| 🎨 **UI Framework** | ![WPF](https://img.shields.io/badge/WPF-Latest-0078D4?style=flat-square&logo=windows) | Latest | User Interface |
| 🗄️ **Database** | ![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?style=flat-square&logo=microsoft-sql-server) | 2022 | Data Storage |
| 🔧 **ORM** | ![Entity Framework](https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=flat-square) | 8.0 | Database Access |
| 🏗️ **Architecture** | ![MVVM](https://img.shields.io/badge/MVVM-Pattern-orange?style=flat-square) | - | Design Pattern |
| 💻 **Language** | ![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat-square&logo=c-sharp) | 12.0 | Programming Language |

</div>

---

## 📁 Project Architecture

<details>
<summary>🔍 <strong>Click to expand project structure</strong></summary>

```
🏪 Inventory-Management-C-/
├── 📂 Models/                          # 🏗️ Data models and entities
│   ├── 📄 Product.cs                   # Product entity model
│   ├── 📄 User.cs                      # User management model
│   ├── 📄 Invoice.cs                   # Invoice data model
│   └── 📄 Stock.cs                     # Inventory tracking model
├── 📂 Views/                           # 🎨 XAML user interface files
│   ├── 📄 MainWindow.xaml              # 🏠 Main application window
│   ├── 📄 LoginPage.xaml               # 🔐 User authentication
│   ├── 📄 ProductsPage.xaml            # 📦 Product management
│   ├── 📄 AddProductPage.xaml          # ➕ Add new products
│   ├── 📄 Invoice.xaml                 # 🧾 Invoice generation
│   ├── 📄 StockTrackingWindow.xaml     # 📊 Inventory monitoring
│   └── 📄 ViewAllUsersWindow.xaml      # 👥 User management
├── 📂 ViewModels/                      # 🧠 Business logic layer
├── 📂 Utilities/                       # 🔧 Helper classes
│   └── 📄 AlternatingRowBackgroundConverter.cs
├── 📂 bin/                             # 🏗️ Compiled binaries
├── 📂 obj/                             # 🔨 Build objects
├── 📄 App.xaml                         # ⚙️ Application config
├── 📄 FinalDB.csproj                   # 📋 Project file
└── 📄 README.md                        # 📖 This file
```

</details>

---

## 🚀 Getting Started

### 📋 Prerequisites

<div align="center">

| Requirement | Version | Download Link |
|-------------|---------|---------------|
| 🪟 **Windows** | 10/11 | [Download](https://www.microsoft.com/windows) |
| 🔧 **.NET SDK** | 8.0+ | [![Download](https://img.shields.io/badge/Download-.NET%208.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/download) |
| 🗄️ **SQL Server** | 2019+ | [![Download](https://img.shields.io/badge/Download-SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)](https://www.microsoft.com/sql-server/sql-server-downloads) |
| 🛠️ **Visual Studio** | 2022 | [![Download](https://img.shields.io/badge/Download-Visual%20Studio-5C2D91?style=for-the-badge&logo=visual-studio)](https://visualstudio.microsoft.com/) |

</div>

### 📥 Installation Steps

<details>
<summary>🔧 <strong>Step-by-step installation guide</strong></summary>

#### 1️⃣ **Clone the Repository**
```bash
# 📥 Clone using HTTPS
git clone https://github.com/anasraheemdev/Inventory-Management-C-.git

# 📁 Navigate to project directory
cd Inventory-Management-C-
```

#### 2️⃣ **Setup Development Environment**
```bash
# 🔄 Restore NuGet packages
dotnet restore

# 🏗️ Build the solution
dotnet build
```

#### 3️⃣ **Database Configuration**
```bash
# 🗄️ Update database connection string in App.config
# 🔄 Run Entity Framework migrations
dotnet ef database update
```

#### 4️⃣ **Run the Application**
```bash
# 🚀 Start the application
dotnet run

# 🎯 Or use Visual Studio
# Press F5 or Ctrl+F5
```

</details>

---

## 🎯 Key Components

### 🔐 **Authentication System**

<div align="center">

```mermaid
flowchart LR
    A[👤 User Login] --> B{🔍 Validate Credentials}
    B -->|✅ Valid| C[🚪 Grant Access]
    B -->|❌ Invalid| D[🚫 Access Denied]
    C --> E{👑 Check Role}
    E -->|Admin| F[🎛️ Full Access]
    E -->|Cashier| G[💼 Limited Access]
    
    style A fill:#e3f2fd
    style F fill:#e8f5e8
    style G fill:#fff3e0
```

</div>

- 🔒 **Secure Login**: Multi-factor authentication support
- 👑 **Role Management**: Admin, Cashier, and custom roles
- 🔐 **Session Control**: Automatic timeout and security
- 📝 **User Registration**: Streamlined onboarding process

### 📦 **Product Management Dashboard**

<table align="center">
<tr>
<td align="center">

**🏷️ Product Information**
- Name & Description
- SKU & Barcode
- Category & Brand
- Images & Specifications

</td>
<td align="center">

**💰 Pricing & Cost**
- Purchase Price
- Selling Price
- Profit Margins
- Bulk Pricing Tiers

</td>
<td align="center">

**📊 Stock Management**
- Current Quantity
- Minimum Stock Level
- Reorder Points
- Stock Locations

</td>
</tr>
</table>

### 🧾 **Advanced Invoice System**

<div align="center">

| Feature | Description | Status |
|---------|-------------|--------|
| 📄 **Invoice Creation** | Generate professional invoices | ✅ Active |
| 🎨 **Custom Templates** | Multiple invoice designs | ✅ Active |
| 💳 **Payment Tracking** | Multiple payment methods | ✅ Active |
| 📧 **Email Integration** | Send invoices via email | 🔄 Coming Soon |
| 📱 **Mobile Preview** | Responsive invoice view | 🔄 Coming Soon |

</div>

---

## 🎮 Interactive Usage Guide

<details>
<summary>🚀 <strong>First-Time Setup Wizard</strong></summary>

### 🎯 **Initial Configuration Steps**

1. **🚀 Launch Application**
   ```
   ┌─────────────────────────────────────┐
   │  🏪 Inventory Management System     │
   │                                     │
   │  👋 Welcome! Let's get started...   │
   │                                     │
   │  [ 🎯 Begin Setup ]                 │
   └─────────────────────────────────────┘
   ```

2. **👤 Create Admin Account**
   - Enter admin credentials
   - Set security questions
   - Configure system preferences

3. **🏪 Business Information**
   - Company name and details
   - Tax configuration
   - Currency settings

4. **📦 Initial Inventory**
   - Import existing products
   - Set up categories
   - Configure stock levels

</details>

<details>
<summary>💼 <strong>Daily Operations Guide</strong></summary>

### 🏬 **For Cashiers**
```mermaid
graph LR
    A[🛒 Start Sale] --> B[📦 Scan/Select Products]
    B --> C[💰 Calculate Total]
    C --> D[💳 Process Payment]
    D --> E[🧾 Generate Receipt]
    E --> F[📊 Update Inventory]
    
    style A fill:#e8f5e8
    style E fill:#e1f5fe
```

### 👑 **For Administrators**
```mermaid
graph TD
    A[🎛️ Admin Dashboard] --> B[📊 View Reports]
    A --> C[👥 Manage Users]
    A --> D[📦 Inventory Control]
    A --> E[⚙️ System Settings]
    
    B --> F[📈 Sales Analytics]
    B --> G[📉 Stock Reports]
    C --> H[➕ Add Users]
    C --> I[🔧 Edit Permissions]
    
    style A fill:#f3e5f5
    style B fill:#e8f5e8
    style C fill:#fff3e0
```

</details>

---

## 🔥 Recent Updates & Changelog

<div align="center">

| 📅 Date | 🎯 Feature | 📝 Description | 🏷️ Status |
|---------|------------|----------------|-----------|
| **2 days ago** | 🔄 **Data Fetching** | Enhanced product section with real-time updates | ![Completed](https://img.shields.io/badge/Status-Completed-success) |
| **2 days ago** | ✏️ **Edit by ID** | Product editing functionality using unique IDs | ![Completed](https://img.shields.io/badge/Status-Completed-success) |
| **3 days ago** | 🗄️ **Database Integration** | Complete user registration and management | ![Completed](https://img.shields.io/badge/Status-Completed-success) |
| **1 week ago** | 🎨 **UI Improvements** | Consistent theming across all pages | ![Completed](https://img.shields.io/badge/Status-Completed-success) |
| **1 week ago** | 🔗 **Page Navigation** | All pages connected successfully | ![Completed](https://img.shields.io/badge/Status-Completed-success) |

</div>

---

## 🎯 Roadmap & Future Enhancements

<div align="center">

```mermaid
timeline
    title 🚀 Development Roadmap
    
    section 🎯 Phase 1 - Core Features
        Current Release : ✅ Product Management
                        : ✅ User Authentication
                        : ✅ Basic Invoicing
    
    section 📈 Phase 2 - Advanced Features
        Next Quarter    : 📱 Mobile App
                        : 🔍 Barcode Scanning
                        : 📊 Advanced Analytics
    
    section 🌐 Phase 3 - Enterprise
        Q3 2025        : ☁️ Cloud Integration
                       : 🏢 Multi-location Support
                       : 🔗 API Development
    
    section 🚀 Phase 4 - Innovation
        Q4 2025        : 🤖 AI Predictions
                       : 📱 IoT Integration
                       : 🌍 Global Expansion
```

</div>

<details>
<summary>📋 <strong>Detailed Feature Roadmap</strong></summary>

### 🎯 **Immediate Priorities** (Next 30 Days)
- [ ] 📱 **Mobile Responsive Design**
- [ ] 🔍 **Advanced Search & Filters**
- [ ] 📊 **Enhanced Reporting Dashboard**
- [ ] 🔔 **Real-time Notifications**
- [ ] 💾 **Data Backup & Recovery**

### 📈 **Short-term Goals** (Next 3 Months)
- [ ] 📱 **Mobile App Development**
- [ ] 🎯 **Barcode Scanner Integration**
- [ ] 📧 **Email Automation**
- [ ] 🔗 **Third-party Integrations**
- [ ] 🌐 **Multi-language Support**

### 🚀 **Long-term Vision** (6-12 Months)
- [ ] ☁️ **Cloud Migration**
- [ ] 🤖 **AI-powered Analytics**
- [ ] 🏢 **Enterprise Features**
- [ ] 🔐 **Advanced Security**
- [ ] 🌍 **Global Deployment**

</details>

---

## 🤝 Contributing

<div align="center">

[![Contributors Welcome](https://img.shields.io/badge/Contributors-Welcome-brightgreen?style=for-the-badge&logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/graphs/contributors)

**🎉 We love contributions! Here's how you can help make this project even better:**

</div>

### 🌟 **Ways to Contribute**

<table>
<tr>
<td align="center">

### 🐛 **Bug Reports**
Found a bug? Let us know!
- Use issue templates
- Provide detailed steps
- Include screenshots
- Test environment info

[![Report Bug](https://img.shields.io/badge/Report-Bug-red?style=for-the-badge&logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/issues/new)

</td>
<td align="center">

### 💡 **Feature Requests**
Have a great idea?
- Describe the feature
- Explain the use case
- Provide mockups if possible
- Discuss implementation

[![Request Feature](https://img.shields.io/badge/Request-Feature-blue?style=for-the-badge&logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/issues/new)

</td>
</tr>
<tr>
<td align="center">

### 🔧 **Code Contributions**
Ready to code?
- Fork the repository
- Create feature branch
- Write clean code
- Add tests if needed

[![Fork Now](https://img.shields.io/badge/Fork-Repository-green?style=for-the-badge&logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/fork)

</td>
<td align="center">

### 📖 **Documentation**
Help improve docs!
- Fix typos
- Add examples
- Improve clarity
- Translate content

[![Edit Docs](https://img.shields.io/badge/Edit-Documentation-orange?style=for-the-badge&logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/edit/main/README.md)

</td>
</tr>
</table>

### 🔄 **Contribution Process**

```mermaid
gitgraph
    commit id: "🍴 Fork Repository"
    branch feature-branch
    checkout feature-branch
    commit id: "✨ Add New Feature"
    commit id: "🧪 Add Tests"
    commit id: "📝 Update Docs"
    checkout main
    merge feature-branch
    commit id: "🎉 Feature Merged!"
```

---

## 👨‍💻 Meet the Developer

<div align="center">

<img src="https://github.com/anasraheemdev.png" width="150" height="150" style="border-radius: 50%;" alt="Anas Raheem">

### **Anas Raheem** 🚀
*Full-Stack Developer & Software Engineer*

[![GitHub](https://img.shields.io/badge/GitHub-anasraheemdev-181717?style=for-the-badge&logo=github)](https://github.com/anasraheemdev)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-0077B5?style=for-the-badge&logo=linkedin)](https://linkedin.com/in/anasraheemdev)
[![Portfolio](https://img.shields.io/badge/Portfolio-Visit-FF5722?style=for-the-badge&logo=google-chrome)](https://anasraheemdev.github.io)
[![Email](https://img.shields.io/badge/Email-Contact-D14836?style=for-the-badge&logo=gmail)](mailto:anasraheemdev@gmail.com)

*"Building efficient solutions for complex business problems"*

</div>

---

## 📞 Support & Community

<div align="center">

### 🤝 **Get Help**

| Platform | Purpose | Link |
|----------|---------|------|
| 🐛 **GitHub Issues** | Bug reports & Feature requests | [![Issues](https://img.shields.io/badge/Open-Issues-red?logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/issues) |
| 💬 **Discussions** | Community support & Q&A | [![Discussions](https://img.shields.io/badge/Join-Discussions-green?logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/discussions) |
| 📧 **Email Support** | Direct developer contact | [![Email](https://img.shields.io/badge/Send-Email-blue?logo=gmail)](mailto:anasraheemdev@gmail.com) |
| 📖 **Documentation** | Comprehensive guides | [![Docs](https://img.shields.io/badge/Read-Docs-orange?logo=gitbook)](https://github.com/anasraheemdev/Inventory-Management-C-/wiki) |

### 📊 **Project Statistics**

![GitHub repo size](https://img.shields.io/github/repo-size/anasraheemdev/Inventory-Management-C-?color=blue)
![GitHub code size](https://img.shields.io/github/languages/code-size/anasraheemdev/Inventory-Management-C-?color=green)
![GitHub last commit](https://img.shields.io/github/last-commit/anasraheemdev/Inventory-Management-C-?color=red)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/anasraheemdev/Inventory-Management-C-?color=orange)

</div>

---

## 📄 License

<div align="center">

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

*Free to use, modify, and distribute for personal and commercial projects*

</div>

---

<div align="center">

## 🌟 **Show Your Support**

**If this project helped you, please consider:**

[![Star this repository](https://img.shields.io/badge/⭐-Star%20this%20repository-yellow?style=for-the-badge&logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/stargazers)
[![Fork this repository](https://img.shields.io/badge/🍴-Fork%20this%20repository-blue?style=for-the-badge&logo=github)](https://github.com/anasraheemdev/Inventory-Management-C-/fork)
[![Follow developer](https://img.shields.io/badge/👤-Follow%20@anasraheemdev-green?style=for-the-badge&logo=github)](https://github.com/anasraheemdev)

---

### 💝 **Thank you for your interest in our Inventory Management System!**

<img src="https://raw.githubusercontent.com/BEPb/BEPb/5c63fa170d1cbbb0b1974f05a3dbe6aca3f5b7f3/assets/Bottom_up.svg" width="100%" />

*Made with ❤️ by [Anas Raheem](https://github.com/anasraheemdev)*

</div>
