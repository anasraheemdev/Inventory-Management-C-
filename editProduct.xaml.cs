using Microsoft.Win32;
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
using System.Windows.Media.Imaging;// Needed for BitmapImage
using System.Windows.Navigation;
using System.Windows.Shapes; 

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window // Ensure this inherits from Window
    {
        public EditProduct()
        {
            InitializeComponent();
            // Optional: Load existing product data here if it's passed via constructor or a data service
            // For example, if you pass a product ID:
            // LoadProductData(productId);
        }

        // --- Sidebar Navigation Handlers ---

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Close the current EditProduct window
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
            // If not, you'll need to create it and ensure it's a Window type.
            // For now, linking to Invoice as a placeholder if no specific Transaction window exists.
            // TransactionWindow transactionWindow = new TransactionWindow();
            // transactionWindow.Show();
            Invoice transactionWindow = new Invoice(); // Placeholder if no dedicated TransactionWindow
            transactionWindow.Show();
            this.Close();
        }

        private void ProductsList_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage productsPageWindow = new ProductsPage();
            productsPageWindow.Show();
            this.Close();
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseOrderWindow = new PurchaseRecordWindow(); // Assuming this is for purchase order
            purchaseOrderWindow.Show();
            this.Close();
        }

        private void PurchaseRecord_Click(object sender, RoutedEventArgs e)
        {
            // Assuming PurchaseRecordWindow handles both new orders and records, or is a separate record view.
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            this.Close();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Category window (e.g., CategoryWindow.xaml)
            // If not, you'll need to create it and ensure it's a Window type.
            // Using ProductsPage as a placeholder if Category window doesn't exist.
            // CategoryWindow categoryWindow = new CategoryWindow();
            // categoryWindow.Show();
            ProductsPage categoryWindow = new ProductsPage(); // Placeholder for Category
            categoryWindow.Show();
            this.Close();
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Brand window (e.g., BrandWindow.xaml)
            // If not, you'll need to create it and ensure it's a Window type.
            // Using ProductsPage as a placeholder if Brand window doesn't exist.
            // BrandWindow brandWindow = new BrandWindow();
            // brandWindow.Show();
            ProductsPage brandWindow = new ProductsPage(); // Placeholder for Brand
            brandWindow.Show();
            this.Close();
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Units window (e.g., UnitsWindow.xaml)
            // If not, you'll need to create it and ensure it's a Window type.
            // Using ProductsPage as a placeholder if Units window doesn't exist.
            // UnitsWindow unitsWindow = new UnitsWindow();
            // unitsWindow.Show();
            ProductsPage unitsWindow = new ProductsPage(); // Placeholder for Units
            unitsWindow.Show();
            this.Close();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Supplier window (e.g., SupplierWindow.xaml)
            // If not, you'll need to create it and ensure it's a Window type.
            // Using ProductsPage as a placeholder if Supplier window doesn't exist.
            // SupplierWindow supplierWindow = new SupplierWindow();
            // supplierWindow.Show();
            ProductsPage supplierWindow = new ProductsPage(); // Placeholder for Supplier
            supplierWindow.Show();
            this.Close();
        }

        private void Issued_Click(object sender, RoutedEventArgs e)
        {
            // Assuming StockTrackingWindow handles "Issued" or is a dedicated Issued window.
            StockTrackingWindow issuedWindow = new StockTrackingWindow(); // Assuming this handles 'Issued'
            issuedWindow.Show();
            this.Close();
        }

        private void Cashiers_Click(object sender, RoutedEventArgs e)
        {
            AddCashier addCashierWindow = new AddCashier();
            addCashierWindow.Show();
            this.Close();
        }

        private void Administrators_Click(object sender, RoutedEventArgs e)
        {
            // Assuming LoginAsAdmin or a dedicated Admin window for managing administrators
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            this.Close();
        }

        private void UserManager_Click(object sender, RoutedEventArgs e)
        {
            // This button might lead to a more comprehensive user management window,
            // or perhaps the same as Administrators. Using LoginAsAdmin as a placeholder.
            LoginAsAdmin userManagerWindow = new LoginAsAdmin(); // Or a dedicated UserManagerWindow
            userManagerWindow.Show();
            this.Close();
        }

        // --- Form Action Buttons ---

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic here to update the product data from the form fields.
            // Example:
            // string productName = ProductNameTextBox.Text;
            // string productCode = ProductCodeTextBox.Text;
            // ... get other values ...

            MessageBox.Show("Product data updated!", "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);

            // After updating, you might want to:
            // 1. Navigate back to a Products list page.
            // 2. Stay on this page with a confirmation.
            // For now, let's navigate back to the ProductsPage as an example.
            ProductsList_Click(sender, e); // Re-use the ProductsList navigation
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // When cancelled, navigate back to the previous context, typically the ProductsList or Dashboard.
            ProductsList_Click(sender, e); // Re-use the ProductsList navigation
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Load the selected image into the Image control
                    ProductImage.Source = new BitmapImage(new System.Uri(openFileDialog.FileName));
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Image Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}