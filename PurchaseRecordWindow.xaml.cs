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

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for PurchaseRecordWindow.xaml
    /// </summary>
    public partial class PurchaseRecordWindow : Window
    {
        public PurchaseRecordWindow()
        {
            InitializeComponent();
            // You can add logic here to load purchase records into the DataGrid if needed.
        }

        // --- Sidebar Navigation Event Handlers ---

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming MainWindow is your main dashboard
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MakeInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoiceWindow = new Invoice();
            invoiceWindow.Show();
            this.Close();
        }

        private void TransactionButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Transaction window, replace "TransactionWindow" with its actual name
            // If "Transaction" functionality is part of Invoice or another window, adjust accordingly.
            MessageBox.Show("Transaction window functionality to be implemented.");
            // Example: TransactionWindow transactionWindow = new TransactionWindow();
            // transactionWindow.Show();
            // this.Close();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductPage addProductPage = new AddProductPage();
            addProductPage.Show();
            this.Close();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage productsPage = new ProductsPage();
            productsPage.Show();
            this.Close();
        }

        private void PurchaseRecordButton_Click(object sender, RoutedEventArgs e)
        {
            // This is the current window, so no action needed or you can refresh if applicable
            // For now, it simply means you're already on this page.
        }

        private void StockTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            this.Close();
        }

        // Example for "More Inventory" items (Category, Brand, Units, Supplier, Issued)
        // You would typically have separate windows or dialogs for these.
        // For demonstration, I'm just showing a message box.
        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Category management window to be implemented.");
            // Example: CategoryWindow categoryWindow = new CategoryWindow();
            // categoryWindow.Show();
            // this.Close();
        }

        private void BrandButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Brand management window to be implemented.");
            // Example: BrandWindow brandWindow = new BrandWindow();
            // brandWindow.Show();
            // this.Close();
        }

        private void UnitsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Units management window to be implemented.");
            // Example: UnitsWindow unitsWindow = new UnitsWindow();
            // unitsWindow.Show();
            // this.Close();
        }

        private void SupplierButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Supplier management window to be implemented.");
            // Example: SupplierWindow supplierWindow = new SupplierWindow();
            // supplierWindow.Show();
            // this.Close();
        }

        private void IssuedButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming this refers to StockTrackingWindow or a similar "Issued Items" window
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            this.Close();
        }

        private void AddCashierButton_Click(object sender, RoutedEventArgs e)
        {
            AddCashier addCashierWindow = new AddCashier();
            addCashierWindow.Show();
            this.Close();
        }

        private void LoginAsAdminButton_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin();
            loginAsAdminWindow.Show();
            this.Close();
        }

        private void LoginPageButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void HomeLoginAsButton_Click(object sender, RoutedEventArgs e)
        {
            HomeLoginAs homeLoginAsWindow = new HomeLoginAs();
            homeLoginAsWindow.Show();
            this.Close();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            // This is typically opened from a list of products, not a direct sidebar button.
            // For demonstration, I'm showing it here.
            EditProduct editProductWindow = new EditProduct();
            editProductWindow.Show();
            this.Close();
        }

        // Existing button clicks from your original XAML (if any, will be renamed/handled above)
        // private void Button_Click_1(object sender, RoutedEventArgs e) { /* Existing logic */ }
        // private void Button_Click(object sender, RoutedEventArgs e) { /* Existing logic */ }
        // private void Button_Click_2(object sender, RoutedEventArgs e) { /* Existing logic */ }
        // private void Button_Click_3(object sender, RoutedEventArgs e) { /* Existing logic */ }

        // You might have other event handlers for the data grid or filters,
        // which are not part of the sidebar navigation. Keep those as they are.
    }
}