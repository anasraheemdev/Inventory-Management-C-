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
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        public Invoice()
        {
            InitializeComponent();
            // Example: Set the current date for the DatePicker (if not already handled by Binding)
            // If you have a specific ViewModel or data context, you might not need this.
            // invoiceDatePicker.SelectedDate = DateTime.Today;
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
            // This is the current window, so no action needed or you can refresh if applicable
            // For now, it simply means you're already on this page.
        }

        private void TransactionButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Transaction window. If not, create Transaction.xaml and Transaction.xaml.cs.
            // Or if it's part of another window, navigate there.
            MessageBox.Show("Transaction window functionality to be implemented.");
            // Example: TransactionWindow transactionWindow = new TransactionWindow();
            // transactionWindow.Show();
            // this.Close();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e) // Renamed from InventoryAddItemButton_Click for consistency
        {
            AddProductPage addProductPage = new AddProductPage();
            addProductPage.Show();
            this.Close();
        }

        private void ProductsListButton_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage productsPage = new ProductsPage();
            productsPage.Show();
            this.Close();
        }

        private void PurchaseOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming this button will open ProductsPage or a specific PurchaseOrder window
            // If PurchaseOrder is a separate window, replace ProductsPage with your PurchaseOrderWindow class
            MessageBox.Show("Purchase Order window/functionality to be implemented.");
            // Example: PurchaseOrderWindow purchaseOrderWindow = new PurchaseOrderWindow();
            // purchaseOrderWindow.Show();
            // this.Close();
        }

        private void PurchaseRecordButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            this.Close();
        }

        private void StockTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            this.Close();
        }

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
            // Assuming "Issued" in the "More Inventory" context refers to StockTrackingWindow or a related view within it
            // Or a dedicated "Issued Items" window.
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            this.Close();
        }

        private void MasterPriceButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming MasterPrice is a separate window. If not, create MasterPriceWindow.xaml and .xaml.cs.
            MessageBox.Show("Master Price window to be implemented.");
            // MasterPriceWindow masterPriceWindow = new MasterPriceWindow();
            // masterPriceWindow.Show();
            // this.Close();
        }

        private void AddCashierButton_Click(object sender, RoutedEventArgs e)
        {
            // This is the method that was missing based on your error.
            AddCashier addCashierWindow = new AddCashier();
            addCashierWindow.Show();
            this.Close();
        }

        // Note: The original XAML had "CashiersButton_Invoice" and "AdministratorsButton_Invoice" under "USERS" TextBlock.
        // I've added handlers for them below, but it's important to clarify which actual windows they should open.
        // For now, I'm linking them to AddCashier and LoginAsAdmin respectively, as they relate to user management.
        private void CashiersButton_Click(object sender, RoutedEventArgs e)
        {
            AddCashier addCashierWindow = new AddCashier(); // Or a dedicated CashierListWindow
            addCashierWindow.Show();
            this.Close();
        }

        private void AdministratorsButton_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin(); // Or a dedicated AdministratorListWindow
            loginAsAdminWindow.Show();
            this.Close();
        }

        private void UserManagerButton_Click(object sender, RoutedEventArgs e)
        {
            // This is a more general User Manager button. Link it to a comprehensive user management window.
            // For now, linking to LoginAsAdmin as an example.
            LoginAsAdmin loginAsAdminWindow = new LoginAsAdmin(); // Or new UserManagerWindow();
            loginAsAdminWindow.Show();
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
            // For demonstration, it's included here.
            EditProduct editProductWindow = new EditProduct();
            editProductWindow.Show();
            this.Close();
        }

        // --- Invoice Specific Button Handlers (from your original XAML) ---

        private void SaveAndPrintButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save and Print Invoice functionality triggered.");
            // Implement your logic to save the invoice data and trigger printing.
        }

        private void PreviewInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Preview Invoice functionality triggered.");
            // Implement logic to show a preview of the invoice.
        }

        private void AddNewItemToInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add New Item to Invoice functionality triggered.");
            // Implement logic to add a new row or open a dialog for adding items.
        }

        private void SaveDraftButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save Draft functionality triggered.");
            // Implement logic to save the current invoice as a draft.
        }

        private void CancelInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancel Invoice functionality triggered.");
            // Implement logic to clear the invoice or return to a previous state.
        }

        private void FinalPrintInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Final Print Invoice functionality triggered.");
            // Implement final printing logic.
        }

        private void EmailInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email Invoice functionality triggered.");
            // Implement logic to email the invoice.
        }
    }
}