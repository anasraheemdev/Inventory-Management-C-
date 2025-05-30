using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // For ObservableCollection
using System.ComponentModel; // For INotifyPropertyChanged
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media; // Required for Color and SolidColorBrush
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts; // LiveCharts namespace
using LiveCharts.Wpf; // LiveCharts WPF controls

namespace FinalDB
{
    /// <summary>
    /// Data model for a single transaction to be displayed in the DataGrid.
    /// </summary>
    public class LatestTransactionItem
    {
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }

    /// <summary>
    /// Data model for a popular product.
    /// </summary>
    public class PopularProductItem
    {
        public string ProductName { get; set; }
        public int SalesCount { get; set; }
    }

    /// <summary>
    /// Data model for stock receipt/issued overview.
    /// </summary>
    public class StockMovementOverview
    {
        public string Type { get; set; } // e.g., "Receipt", "Issued"
        public int Quantity { get; set; }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
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
        private string _todayGrossProfit;
        public string TodayGrossProfit
        {
            get { return _todayGrossProfit; }
            set { _todayGrossProfit = value; OnPropertyChanged(nameof(TodayGrossProfit)); }
        }

        private string _todayNetProfit;
        public string TodayNetProfit
        {
            get { return _todayNetProfit; }
            set { _todayNetProfit = value; OnPropertyChanged(nameof(TodayNetProfit)); }
        }

        private string _todayItemReceipt;
        public string TodayItemReceipt
        {
            get { return _todayItemReceipt; }
            set { _todayItemReceipt = value; OnPropertyChanged(nameof(TodayItemReceipt)); }
        }

        private string _todayEstimationLoss;
        public string TodayEstimationLoss
        {
            get { return _todayEstimationLoss; }
            set { _todayEstimationLoss = value; OnPropertyChanged(nameof(TodayEstimationLoss)); }
        }

        private string _currentYear;
        public string CurrentYear
        {
            get { return _currentYear; }
            set { _currentYear = value; OnPropertyChanged(nameof(CurrentYear)); }
        }

        // Properties for Charts/Lists
        public SeriesCollection DailySellingActivitySeries { get; set; }
        public string[] DailySellingActivityLabels { get; set; }

        public ObservableCollection<LatestTransactionItem> LatestTransactions { get; set; }
        public ObservableCollection<PopularProductItem> PopularProducts { get; set; }
        public SeriesCollection StockMovementSeries { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this; // Set DataContext to this window for data binding

            // Initialize collections
            DailySellingActivitySeries = new SeriesCollection();
            DailySellingActivityLabels = new string[] { };
            LatestTransactions = new ObservableCollection<LatestTransactionItem>();
            PopularProducts = new ObservableCollection<PopularProductItem>();
            StockMovementSeries = new SeriesCollection();

            CurrentYear = DateTime.Now.Year.ToString(); // Set current year dynamically

            LoadDashboardData();
        }

        /// <summary>
        /// Fetches and updates all dashboard metrics and chart data from the backend.
        /// </summary>
        private void LoadDashboardData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // --- Fetch Metrics Data ---
                    DateTime today = DateTime.Today;
                    DateTime yesterday = today.AddDays(-1);

                    // Today Gross Profit (assuming total_amount from invoices for today)
                    // For actual Gross Profit, you'd need (selling_price - purchase_price) * quantity for each item.
                    // This query uses total_amount as a proxy for gross sales for simplicity.
                    string grossProfitQuery = $"SELECT SUM(total_amount) FROM invoices WHERE invoice_date = '{today:yyyy-MM-dd}'";
                    using (MySqlCommand cmd = new MySqlCommand(grossProfitQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        TodayGrossProfit = (result != DBNull.Value) ? Convert.ToDecimal(result).ToString("C0") : "Rs. 0"; // C0 for currency, no decimals
                    }

                    // Today Net Profit (more complex, requires expenses, discounts, taxes)
                    // For simplicity, let's assume Net Profit is Gross Profit - Tax Amount - Discount Amount for today's invoices.
                    // This is a simplified calculation.
                    string netProfitQuery = $"SELECT SUM(total_amount - discount_amount - tax_amount) FROM invoices WHERE invoice_date = '{today:yyyy-MM-dd}'";
                    using (MySqlCommand cmd = new MySqlCommand(netProfitQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        TodayNetProfit = (result != DBNull.Value) ? Convert.ToDecimal(result).ToString("C0") : "Rs. 0";
                    }

                    // Today Item Receipt (sum of quantities from invoice_items for today, assuming they represent items coming IN)
                    // In a real system, this would come from a 'purchase_receipts' or 'stock_in' table.
                    // Using invoice_items as a placeholder for now, which is typically for items going OUT.
                    // For a more accurate "Item Receipt", you'd query your purchase order/receipts table.
                    string itemReceiptQuery = $"SELECT SUM(ii.quantity) FROM invoice_items ii JOIN invoices i ON ii.invoice_id = i.invoice_id WHERE i.invoice_date = '{today:yyyy-MM-dd}'";
                    using (MySqlCommand cmd = new MySqlCommand(itemReceiptQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        TodayItemReceipt = (result != DBNull.Value) ? Convert.ToInt32(result).ToString("N0") : "0";
                    }

                    // Today Estimation Loss (e.g., from damaged goods, expired products - difficult to calculate without specific data)
                    // This is a placeholder. In a real system, you'd query a 'losses' or 'adjustments' table.
                    // Or, if 'discount_amount' on invoices represents a loss, you could sum that.
                    string estimationLossQuery = $"SELECT SUM(discount_amount) FROM invoices WHERE invoice_date = '{today:yyyy-MM-dd}'";
                    using (MySqlCommand cmd = new MySqlCommand(estimationLossQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        TodayEstimationLoss = (result != DBNull.Value) ? Convert.ToDecimal(result).ToString("C0") : "Rs. 0";
                    }


                    // --- Fetch Chart and List Data ---

                    // Daily Selling Activity (Line Chart - total sales amount per day for last 30 days)
                    DailySellingActivitySeries.Clear();
                    var salesValues = new ChartValues<double>();
                    var salesLabels = new List<string>();

                    string dailySalesQuery = @"
                        SELECT
                            DATE_FORMAT(invoice_date, '%Y-%m-%d') AS sale_date,
                            SUM(total_amount) AS daily_sales
                        FROM invoices
                        WHERE invoice_date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
                        GROUP BY sale_date
                        ORDER BY sale_date ASC;
                    ";
                    using (MySqlCommand cmd = new MySqlCommand(dailySalesQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                salesLabels.Add(reader.GetString("sale_date"));
                                salesValues.Add(reader.GetDouble("daily_sales"));
                            }
                        }
                    }
                    DailySellingActivitySeries.Add(new LineSeries
                    {
                        Title = "Daily Sales",
                        Values = salesValues,
                        PointGeometrySize = 8,
                        StrokeThickness = 2,
                        Fill = new SolidColorBrush(Color.FromArgb(50, 30, 90, 175))
                    });
                    DailySellingActivityLabels = salesLabels.ToArray();
                    OnPropertyChanged(nameof(DailySellingActivitySeries));
                    OnPropertyChanged(nameof(DailySellingActivityLabels));


                    // Latest Transactions (DataGrid - recent invoices)
                    LatestTransactions.Clear();
                    string latestTransactionsQuery = @"
                        SELECT
                            i.invoice_number,
                            c.customer_name,
                            i.total_amount,
                            i.invoice_date
                        FROM invoices i
                        JOIN customers c ON i.customer_id = c.customer_id
                        ORDER BY i.created_at DESC
                        LIMIT 5;
                    ";
                    using (MySqlCommand cmd = new MySqlCommand(latestTransactionsQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LatestTransactions.Add(new LatestTransactionItem
                                {
                                    InvoiceNumber = reader.GetString("invoice_number"),
                                    CustomerName = reader.GetString("customer_name"),
                                    TotalAmount = reader.GetDecimal("total_amount"),
                                    InvoiceDate = reader.GetDateTime("invoice_date")
                                });
                            }
                        }
                    }


                    // Popular Products (DataGrid - top 5 products by quantity sold)
                    PopularProducts.Clear();
                    string popularProductsQuery = @"
                        SELECT
                            p.product_name,
                            SUM(ii.quantity) AS sales_count
                        FROM invoice_items ii
                        JOIN products p ON ii.product_id = p.product_id
                        GROUP BY p.product_name
                        ORDER BY sales_count DESC
                        LIMIT 5;
                    ";
                    using (MySqlCommand cmd = new MySqlCommand(popularProductsQuery, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PopularProducts.Add(new PopularProductItem
                                {
                                    ProductName = reader.GetString("product_name"),
                                    SalesCount = reader.GetInt32("sales_count")
                                });
                            }
                        }
                    }

                    // Stock Receipt / Issued (Pie Chart - simple overview of movements)
                    StockMovementSeries.Clear();
                    // Get total quantity of items issued (sold)
                    string issuedQtyQuery = "SELECT SUM(quantity) FROM invoice_items";
                    int totalIssued = 0;
                    using (MySqlCommand cmd = new MySqlCommand(issuedQtyQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value) totalIssued = Convert.ToInt32(result);
                    }

                    // Get total quantity of items received (assuming from product creation or a purchase table)
                    // This is a very simplified 'receipt' count. A real system would have a dedicated purchase_items or stock_in table.
                    string receivedQtyQuery = "SELECT SUM(stock_quantity) FROM products"; // Total stock as a proxy for received
                    int totalReceived = 0;
                    using (MySqlCommand cmd = new MySqlCommand(receivedQtyQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value) totalReceived = Convert.ToInt32(result);
                    }

                    if (totalReceived > 0)
                    {
                        StockMovementSeries.Add(new PieSeries
                        {
                            Title = "Received",
                            Values = new ChartValues<double> { totalReceived },
                            DataLabels = true,
                            Fill = new SolidColorBrush(Color.FromRgb(76, 175, 80)) // Green
                        });
                    }
                    if (totalIssued > 0)
                    {
                        StockMovementSeries.Add(new PieSeries
                        {
                            Title = "Issued",
                            Values = new ChartValues<double> { totalIssued },
                            DataLabels = true,
                            Fill = new SolidColorBrush(Color.FromRgb(30, 90, 175)) // Primary Blue
                        });
                    }
                    OnPropertyChanged(nameof(StockMovementSeries));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading dashboard data: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred loading dashboard data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // --- Sidebar Navigation Event Handlers ---

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            LoadDashboardData(); // Refresh data if already on dashboard
        }

        private void MakeInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoiceWindow = new Invoice();
            invoiceWindow.Show();
            this.Close();
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
            EditProduct editProductWindow = new EditProduct();
            editProductWindow.Show();
            this.Close();
        }

        private void Cashiers_Click(object sender, RoutedEventArgs e)
        {
            ViewAllUsersWindow viewAllUsersWindow = new ViewAllUsersWindow();
            viewAllUsersWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Navigates to the PurchaseRecordWindow.
        /// </summary>
        private void PurchaseRecordWindow_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRecordWindow purchaseRecordWindow = new PurchaseRecordWindow();
            purchaseRecordWindow.Show();
            this.Close();
        }

        private void MasterPrice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Master Price window functionality to be implemented.");
        }

        private void PurchaseOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Purchase Order window functionality to be implemented.");
        }

        private void Supplier_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Supplier window functionality to be implemented.");
        }

        private void StockTrackingWindow_Click(object sender, RoutedEventArgs e)
        {
            StockTrackingWindow stockTrackingWindow = new StockTrackingWindow();
            stockTrackingWindow.Show();
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
    }
}
