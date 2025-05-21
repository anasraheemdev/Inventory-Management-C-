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
    /// Interaction logic for AddCashier.xaml
    /// </summary>
    public partial class AddCashier : Window // Ensure this inherits from Window
    {
        public AddCashier()
        {
            InitializeComponent();
        }

        // --- Sidebar Navigation Handlers ---

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); // Close the current AddCashier window
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
            // For now, I'll link to Invoice as a placeholder if no specific Transaction window exists.
            // TransactionWindow transactionWindow = new TransactionWindow();
            // transactionWindow.Show();
            Invoice transactionWindow = new Invoice(); // Placeholder if no dedicated TransactionWindow
            transactionWindow.Show();
            this.Close();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddProductPage addProductPageWindow = new AddProductPage();
            addProductPageWindow.Show();
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

        // The "Cashiers" button is for the current window, so it doesn't navigate away.
        // If it were meant to open a *list* of cashiers, you'd navigate to that list window.
        // private void Cashiers_Click(object sender, RoutedEventArgs e) { /* Do nothing or refresh current view */ }

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

        // --- Main Content Area Buttons (e.g., "View All", "Save", "Cancel") ---

        private void ViewAllCashiers_Click(object sender, RoutedEventArgs e)
        {
            // Assuming "View All" on the Add Cashier page should take you to a list/view of cashiers.
            // If ProductsPage is used as a generic list, replace with an actual CashierListWindow if you have one.
            ProductsPage cashierListWindow = new ProductsPage(); // Placeholder: replace with actual CashierListWindow
            cashierListWindow.Show();
            this.Close();
        }

        private void SaveCashier_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic here to save the cashier data from the form fields.
            MessageBox.Show("Cashier data saved!", "Save Successful", MessageBoxButton.OK, MessageBoxImage.Information);

            // After saving, you might want to:
            // 1. Clear the form fields to add another cashier.
            // 2. Navigate back to the Dashboard or a Cashier list page.
            // For now, let's navigate back to the Dashboard as an example.
            Dashboard_Click(sender, e); // Re-use the Dashboard navigation
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // When cancelled, navigate back to the Dashboard or previous window.
            Dashboard_Click(sender, e); // Re-use the Dashboard navigation
        }
    }
}