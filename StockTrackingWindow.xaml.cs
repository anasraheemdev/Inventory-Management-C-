using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // For ObservableCollection
using System.ComponentModel; // For INotifyPropertyChanged
using System.Linq;
using System.Windows;
using System.Windows.Media; // Added this using directive to resolve 'Color' and 'SolidColorBrush' errors
using LiveCharts; // LiveCharts namespace
using LiveCharts.Wpf; // LiveCharts WPF controls

namespace FinalDB
{
    /// <summary>
    /// Represents a single product for the low stock list.
    /// </summary>
    public class LowStockProduct
    {
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public int AlertQuantity { get; set; }
    }

    /// <summary>
    /// Represents an item in the latest stock receipts list.
    /// </summary>
    public class StockReceiptItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Represents an item in the latest stock issued list.
    /// </summary>
    public class StockIssuedItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Interaction logic for StockTrackingWindow.xaml
    /// </summary>
    public partial class StockTrackingWindow : Window, INotifyPropertyChanged
    {
        // Database connection string
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;"; // IMPORTANT: In a real application, consider externalizing this.

        // Implement INotifyPropertyChanged for data binding
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Properties for Metrics
        private string _totalItems;
        public string TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; OnPropertyChanged(nameof(TotalItems)); }
        }

        private string _itemsInStock;
        public string ItemsInStock
        {
            get { return _itemsInStock; }
            set { _itemsInStock = value; OnPropertyChanged(nameof(ItemsInStock)); }
        }

        private string _lowStockItems;
        public string LowStockItems
        {
            get { return _lowStockItems; }
            set { _lowStockItems = value; OnPropertyChanged(nameof(LowStockItems)); }
        }

        private string _outOfStockItems;
        public string OutOfStockItems
        {
            get { return _outOfStockItems; }
            set { _outOfStockItems = value; OnPropertyChanged(nameof(OutOfStockItems)); }
        }

        // Properties for Charts/Lists
        public SeriesCollection StockLevelSeries { get; set; }
        public string[] StockLevelLabels { get; set; }

        public ObservableCollection<StockReceiptItem> LatestStockReceipts { get; set; }
        public ObservableCollection<StockIssuedItem> LatestStockIssued { get; set; }
        public ObservableCollection<LowStockProduct> LowStockProducts { get; set; }


        public StockTrackingWindow()
        {
            InitializeComponent();
            this.DataContext = this; // Set DataContext to this window for data binding

            // Initialize collections
            StockLevelSeries = new SeriesCollection();
            StockLevelLabels = new string[] { };
            LatestStockReceipts = new ObservableCollection<StockReceiptItem>();
            LatestStockIssued = new ObservableCollection<StockIssuedItem>();
            LowStockProducts = new ObservableCollection<LowStockProduct>();

            LoadStockMetrics();
            LoadChartAndListData();
        }

        /// <summary>
        /// Fetches and updates the main stock metrics (Total, In Stock, Low Stock, Out of Stock).
        /// </summary>
        private void LoadStockMetrics()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Query for Total Items
                    string totalItemsQuery = "SELECT COUNT(*) FROM products";
                    using (MySqlCommand cmd = new MySqlCommand(totalItemsQuery, connection))
                    {
                        TotalItems = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }

                    // Query for Items In Stock (stock_quantity > 0)
                    string itemsInStockQuery = "SELECT COUNT(*) FROM products WHERE stock_quantity > 0";
                    using (MySqlCommand cmd = new MySqlCommand(itemsInStockQuery, connection))
                    {
                        ItemsInStock = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }

                    // Query for Low Stock Items (stock_quantity > 0 AND stock_quantity <= alert_quantity)
                    string lowStockItemsQuery = "SELECT COUNT(*) FROM products WHERE stock_quantity > 0 AND stock_quantity <= alert_quantity";
                    using (MySqlCommand cmd = new MySqlCommand(lowStockItemsQuery, connection))
                    {
                        LowStockItems = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }

                    // Query for Out of Stock Items (stock_quantity = 0)
                    string outOfStockItemsQuery = "SELECT COUNT(*) FROM products WHERE stock_quantity = 0";
                    using (MySqlCommand cmd = new MySqlCommand(outOfStockItemsQuery, connection))
                    {
                        OutOfStockItems = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading stock metrics: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred loading stock metrics: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Fetches data for charts and lists (Stock Level Changes, Latest Receipts, Latest Issued, Low Stock Products).
        /// </summary>
        private void LoadChartAndListData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // --- Stock Level Changes (Line Chart) ---
                    // This query aggregates total stock quantity by month for the last 12 months.
                    // It's a simplified representation; a real system might track stock movements (in/out)
                    // in a dedicated transactions table to get precise historical stock levels.
                    string stockLevelChangesQuery = @"
                        SELECT
                            DATE_FORMAT(created_at, '%Y-%m') AS month,
                            SUM(stock_quantity) AS total_stock
                        FROM products
                        GROUP BY month
                        ORDER BY month ASC
                        LIMIT 12;
                    ";
                    var stockValues = new ChartValues<double>();
                    var monthLabels = new List<string>();

                    using (MySqlCommand cmd = new MySqlCommand(stockLevelChangesQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                monthLabels.Add(reader.GetString("month"));
                                stockValues.Add(reader.GetDouble("total_stock"));
                            }
                        }
                    }
                    // Clear existing series and add new ones
                    StockLevelSeries.Clear();
                    StockLevelSeries.Add(new LineSeries
                    {
                        Title = "Total Stock",
                        Values = stockValues,
                        PointGeometrySize = 10,
                        StrokeThickness = 2,
                        Fill = new SolidColorBrush(Color.FromArgb(50, 30, 90, 175)) // Light blue fill
                    });
                    StockLevelLabels = monthLabels.ToArray();
                    OnPropertyChanged(nameof(StockLevelSeries));
                    OnPropertyChanged(nameof(StockLevelLabels));


                    // --- Latest Stock Receipts (DataGrid) ---
                    // Fetches the most recent product receipts.
                    // Assuming 'purchase_records' table exists with product_id, quantity, and purchase_date.
                    // If not, you'd need to adapt this to your actual data source for stock receipts.
                    string latestReceiptsQuery = @"
                        SELECT
                            p.product_name,
                            ii.quantity, -- Assuming invoice_items quantity represents stock movement for simplicity
                            i.invoice_date
                        FROM invoice_items ii
                        JOIN products p ON ii.product_id = p.product_id
                        JOIN invoices i ON ii.invoice_id = i.invoice_id
                        ORDER BY i.invoice_date DESC, ii.invoice_item_id DESC
                        LIMIT 5;
                    ";
                    LatestStockReceipts.Clear(); // Clear existing items
                    using (MySqlCommand cmd = new MySqlCommand(latestReceiptsQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LatestStockReceipts.Add(new StockReceiptItem
                                {
                                    ProductName = reader.GetString("product_name"),
                                    Quantity = reader.GetInt32("quantity"),
                                    Date = reader.GetDateTime("invoice_date")
                                });
                            }
                        }
                    }


                    // --- Latest Stock Issued (DataGrid) ---
                    // Fetches the most recent product issues (sales).
                    string latestIssuedQuery = @"
                        SELECT
                            p.product_name,
                            ii.quantity,
                            i.invoice_date
                        FROM invoice_items ii
                        JOIN products p ON ii.product_id = p.product_id
                        JOIN invoices i ON ii.invoice_id = i.invoice_id
                        ORDER BY i.invoice_date DESC, ii.invoice_item_id DESC
                        LIMIT 5;
                    ";
                    LatestStockIssued.Clear(); // Clear existing items
                    using (MySqlCommand cmd = new MySqlCommand(latestIssuedQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LatestStockIssued.Add(new StockIssuedItem
                                {
                                    ProductName = reader.GetString("product_name"),
                                    Quantity = reader.GetInt32("quantity"),
                                    Date = reader.GetDateTime("invoice_date")
                                });
                            }
                        }
                    }

                    // --- Low Stock Items (DataGrid) ---
                    // Fetches products that are currently in low stock.
                    string lowStockProductsQuery = @"
                        SELECT product_name, stock_quantity, alert_quantity
                        FROM products
                        WHERE stock_quantity > 0 AND stock_quantity <= alert_quantity
                        ORDER BY stock_quantity ASC
                        LIMIT 5;
                    ";
                    LowStockProducts.Clear(); // Clear existing items
                    using (MySqlCommand cmd = new MySqlCommand(lowStockProductsQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LowStockProducts.Add(new LowStockProduct
                                {
                                    ProductName = reader.GetString("product_name"),
                                    StockQuantity = reader.GetInt32("stock_quantity"),
                                    AlertQuantity = reader.GetInt32("alert_quantity")
                                });
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading chart/list data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred loading chart/list data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // --- Sidebar Navigation Event Handlers (Copied from previous instruction) ---
        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
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
            MessageBox.Show("Transaction window functionality to be implemented.");
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
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            this.Close();
        }

        private void StockTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            // Already on this window
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Category management window to be implemented.");
        }

        private void BrandButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Brand management window to be implemented.");
        }

        private void UnitsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Units management window to be implemented.");
        }

        private void SupplierButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Supplier management window to be implemented.");
        }

        private void IssuedButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Issued items view/window to be implemented.");
        }

        private void MasterPriceButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Master Price window to be implemented.");
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
            EditProduct editProductWindow = new EditProduct();
            editProductWindow.Show();
            this.Close();
        }
    }
}
