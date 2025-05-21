using System.Linq; // Added for potential use in Button_Click_5
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Optionally, you can set the initial title for the dashboard when MainWindow loads
            PageTitle.Text = "DASHBOARD";
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            // If you want to explicitly refresh or ensure the dashboard is the active content,
            // you might re-instantiate or just ensure this window is active.
            // Since this is the MainWindow, clicking Dashboard means keeping this window visible.
            PageTitle.Text = "DASHBOARD";
            // If other windows are open, you might want to bring this one to front or close others.
            // For simplicity, we assume this is the main hub and other windows are opened as needed.
        }

        private void MakeInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show();
            this.Close(); // Close the current MainWindow
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddProductPage addProductPage = new AddProductPage();
            addProductPage.Show();
            this.Close();
        }

        private void ProductsPage_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage productsPage = new ProductsPage();
            productsPage.Show();
            this.Close();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            // You might open EditProductPage with an item to edit,
            // but for simple navigation, we'll just open it.
            EditProduct editProduct = new EditProduct();
            editProduct.Show();
            this.Close();
        }

        private void Cashiers_Click(object sender, RoutedEventArgs e)
        {
            AddCashier addCashier = new AddCashier();
            addCashier.Show();
            this.Close();
        }

        private void MasterPrice_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a MasterPrice window
            // If not, you'll need to create a MasterPrice.xaml and MasterPrice.xaml.cs
            // For now, I'll link to ProductsPage as a placeholder if a specific MasterPrice page doesn't exist yet.
            // MasterPrice masterPrice = new MasterPrice();
            ProductsPage productsPage = new ProductsPage(); // Placeholder
            productsPage.Show(); // Placeholder
            // masterPrice.Show(); // Uncomment and use this if you create MasterPrice window
            this.Close();
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            this.Close();
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a Supplier window
            // If not, you'll need to create a Supplier.xaml and Supplier.xaml.cs
            // For now, I'll link to ProductsPage as a placeholder if a specific Supplier page doesn't exist yet.
            // Supplier supplier = new Supplier();
            ProductsPage productsPage = new ProductsPage(); // Placeholder
            productsPage.Show(); // Placeholder
            // supplier.Show(); // Uncomment and use this if you create Supplier window
            this.Close();
        }

        private void StockTrackingWindow_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
            this.Close();
        }

        // Note: The original XAML had "Receive" and "Issued" as separate buttons.
        // I've consolidated them under a single "Stock Tracking" button which opens StockTrackingWindow,
        // assuming StockTrackingWindow will handle both receiving and issuing logic internally.
        // If you need separate windows for Receive and Issued, you'd create them.

        private void LoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginAsAdmin loginAsAdmin = new LoginAsAdmin();
            loginAsAdmin.Show();
            this.Close();
        }

        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        // The "new expression can be simplified" warning means that
        // you can often omit the type name when calling a constructor
        // if the type can be inferred from the context (e.g., `new Invoice()` instead of `new Invoice()`).
        // This is a C# 9 feature. The code I provided uses the full `new ClassName()` syntax,
        // which is compatible with older C# versions as well and is perfectly valid.
        // You can simplify it if your project targets C# 9 or newer.
    }
}