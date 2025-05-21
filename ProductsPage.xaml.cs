using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel; // For ObservableCollection, useful for DataGrid data
using System.Linq; // For LINQ operations if filtering/pagination is implemented

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Window // Ensure this inherits from Window
    {
        // Example: A simple Product class (you would have a more complex one)
        public class Product
        {
            public string SKU { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Brand { get; set; }
            public decimal Price { get; set; }
            public decimal Cost { get; set; }
            public int Stock { get; set; }
            public string Status { get; set; } // e.g., "In Stock", "Out of Stock", "Low Stock"
        }

        // Example data for the DataGrid (replace with actual data loading from DB)
        public ObservableCollection<Product> Products { get; set; }

        public ProductsPage()
        {
            InitializeComponent();
            this.DataContext = this; // Set DataContext for binding if you use Properties

            // Load some dummy data for demonstration
            Products = new ObservableCollection<Product>
            {
                new Product { SKU = "PROD001", Name = "Laptop X1", Category = "Electronics", Brand = "Dell", Price = 1200.00m, Cost = 900.00m, Stock = 50, Status = "In Stock" },
                new Product { SKU = "PROD002", Name = "Smartphone Pro", Category = "Electronics", Brand = "Samsung", Price = 800.00m, Cost = 600.00m, Stock = 120, Status = "In Stock" },
                new Product { SKU = "PROD003", Name = "Wireless Earbuds", Category = "Accessories", Brand = "Sony", Price = 150.00m, Cost = 100.00m, Stock = 10, Status = "Low Stock" },
                new Product { SKU = "PROD004", Name = "Gaming Mouse", Category = "Peripherals", Brand = "Logitech", Price = 50.00m, Cost = 30.00m, Stock = 0, Status = "Out of Stock" },
                new Product { SKU = "PROD005", Name = "4K Monitor", Category = "Electronics", Brand = "LG", Price = 350.00m, Cost = 250.00m, Stock = 75, Status = "In Stock" },
                // Add more dummy data as needed
            };
            ProductsDataGrid.ItemsSource = Products; // Assign the ObservableCollection to the DataGrid
        }

        // --- Sidebar Navigation Handlers ---

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Close the current ProductsPage window
        }

        private void MakeInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoiceWindow = new Invoice();
            invoiceWindow.Show();
            this.Close();
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Transaction window (e.g., TransactionWindow.xaml)
            // For now, linking to Invoice as a placeholder if no specific Transaction window exists.
            MessageBox.Show("Transaction window functionality to be implemented.");
            // Example: TransactionWindow transactionWindow = new TransactionWindow();
            // transactionWindow.Show();
            // this.Close();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e) // Corrected method name
        {
            AddProductPage addProductPageWindow = new AddProductPage();
            addProductPageWindow.Show();
            this.Close();
        }

        // Products List is the current page, so no navigation needed for this button
        // private void ProductsList_Click(object sender, RoutedEventArgs e) { /* Do nothing or refresh current view */ }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            // Assuming this button will open ProductsPage or a specific PurchaseOrder window
            // If PurchaseOrder is a separate window, replace with your PurchaseOrderWindow class
            MessageBox.Show("Purchase Order window/functionality to be implemented.");
            // Example: PurchaseOrderWindow purchaseOrderWindow = new PurchaseOrderWindow();
            // purchaseOrderWindow.Show();
            // this.Close();
        }

        private void PurchaseRecord_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            this.Close();
        }

        private void StockTracking_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            this.Close();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Category window (e.g., CategoryWindow.xaml)
            // Using ProductsPage as a placeholder if Category window doesn't exist.
            MessageBox.Show("Category management window to be implemented.");
            // CategoryWindow categoryWindow = new CategoryWindow();
            // categoryWindow.Show();
            // this.Close();
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Brand window (e.g., BrandWindow.xaml)
            // Using ProductsPage as a placeholder if Brand window doesn't exist.
            MessageBox.Show("Brand management window to be implemented.");
            // BrandWindow brandWindow = new BrandWindow();
            // brandWindow.Show();
            // this.Close();
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Units window (e.g., UnitsWindow.xaml)
            // Using ProductsPage as a placeholder if Units window doesn't exist.
            MessageBox.Show("Units management window to be implemented.");
            // UnitsWindow unitsWindow = new UnitsWindow();
            // unitsWindow.Show();
            // this.Close();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Supplier window (e.g., SupplierWindow.xaml)
            // Using ProductsPage as a placeholder if Supplier window doesn't exist.
            MessageBox.Show("Supplier management window to be implemented.");
            // SupplierWindow supplierWindow = new SupplierWindow();
            // supplierWindow.Show();
            // this.Close();
        }

        private void Issued_Click(object sender, RoutedEventArgs e)
        {
            // Assuming StockTrackingWindow handles "Issued" or is a dedicated Issued window.
            StockTrackingWindow issuedWindow = new StockTrackingWindow();
            issuedWindow.Show();
            this.Close();
        }

        private void MasterPrice_Click(object sender, RoutedEventArgs e)
        {
            // Assuming MasterPrice is a separate window. If not, create MasterPriceWindow.xaml and .xaml.cs.
            MessageBox.Show("Master Price window to be implemented.");
            // MasterPriceWindow masterPriceWindow = new MasterPriceWindow();
            // masterPriceWindow.Show();
            // this.Close();
        }

        private void AddCashier_Click(object sender, RoutedEventArgs e) // Corrected from Cashiers_Click
        {
            AddCashier addCashierWindow = new AddCashier();
            addCashierWindow.Show();
            this.Close();
        }

        private void LoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            this.Close();
        }

        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void HomeLoginAs_Click(object sender, RoutedEventArgs e)
        {
            HomeLoginAs homeLoginAsWindow = new HomeLoginAs();
            homeLoginAsWindow.Show();
            this.Close();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            // This is just a general link to EditProduct from the sidebar for demonstration.
            EditProduct editProductWindow = new EditProduct();
            editProductWindow.Show();
            this.Close();
        }

        // --- Main Content Area Buttons ---

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductPage addProductPageWindow = new AddProductPage();
            addProductPageWindow.Show();
            this.Close(); // Close the current ProductsPage
        }

        private void ExportProducts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exporting products to CSV/Excel... (Implementation needed)", "Export", MessageBoxButton.OK, MessageBoxImage.Information);
            // Implement logic to export product data (e.g., to CSV, Excel)
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Applying filters to products list... (Implementation needed)", "Filter");
            // Implement logic to filter the products displayed in the DataGrid
        }

        private void EditProductInGrid_Click(object sender, RoutedEventArgs e)
        {
            // This is a button *inside* the DataGrid row.
            // We need to get the data item associated with the clicked button.
            Button button = sender as Button;
            if (button != null)
            {
                Product selectedProduct = button.DataContext as Product;
                if (selectedProduct != null)
                {
                    MessageBox.Show($"Editing product: {selectedProduct.Name} (SKU: {selectedProduct.SKU})", "Edit Product", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Open the EditProduct window, potentially passing the product data
                    EditProduct editProductWindow = new EditProduct();
                    // You would typically pass the selectedProduct object or its ID to the EditProduct window
                    // editProductWindow.LoadProduct(selectedProduct); // Assuming a method in EditProduct
                    editProductWindow.Show();
                    this.Close(); // Close the current ProductsPage
                }
            }
        }

        private void DeleteProductInGrid_Click(object sender, RoutedEventArgs e)
        {
            // This is a button *inside* the DataGrid row.
            // We need to get the data item associated with the clicked button.
            Button button = sender as Button;
            if (button != null)
            {
                Product selectedProduct = button.DataContext as Product;
                if (selectedProduct != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete product: {selectedProduct.Name} (SKU: {selectedProduct.SKU})?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Implement deletion logic here
                        Products.Remove(selectedProduct); // Remove from ObservableCollection to update UI
                        MessageBox.Show($"Product {selectedProduct.Name} deleted!", "Delete Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        // --- Pagination Buttons (Example placeholders) ---
        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigate to previous page (pagination logic needed).", "Pagination", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigate to Page 1 (pagination logic needed).", "Pagination", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigate to Page 2 (pagination logic needed).", "Pagination", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigate to Page 3 (pagination logic needed).", "Pagination", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Navigate to next page (pagination logic needed).", "Pagination", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}