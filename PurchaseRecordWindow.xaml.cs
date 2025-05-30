using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // For ObservableCollection
using System.ComponentModel; // For INotifyPropertyChanged
using System.Linq;
using System.Text; // Added this using directive for StringBuilder
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media; // Required for Color and SolidColorBrush
using LiveCharts; // LiveCharts namespace
using LiveCharts.Wpf; // LiveCharts WPF controls

namespace FinalDB
{
    /// <summary>
    /// Data model for a single purchase record (representing a sales invoice in this context).
    /// </summary>
    public class PurchaseRecordDisplayModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerName { get; set; } // Using CustomerName as "Supplier" in UI
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        // Property for status color in DataGrid
        public SolidColorBrush StatusColor
        {
            get
            {
                switch (Status?.ToLower())
                {
                    case "paid":
                        return new SolidColorBrush(Color.FromRgb(76, 175, 80)); // Green
                    case "pending":
                        return new SolidColorBrush(Color.FromRgb(255, 152, 0)); // Orange
                    case "cancelled":
                        return new SolidColorBrush(Color.FromRgb(244, 67, 54)); // Red
                    case "refunded":
                        return new SolidColorBrush(Color.FromRgb(33, 150, 243)); // Blue
                    default:
                        return new SolidColorBrush(Color.FromRgb(158, 158, 158)); // Grey
                }
            }
        }
    }

    /// <summary>
    /// Interaction logic for PurchaseRecordWindow.xaml
    /// </summary>
    public partial class PurchaseRecordWindow : Window, INotifyPropertyChanged
    {
        // Database connection string
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=sultani;" +
            "Uid=root;" +
            "Pwd=anas786MALIK@;"; // IMPORTANT: In a real application, consider externalizing this.

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Properties for Filters
        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; OnPropertyChanged(nameof(FromDate)); }
        }

        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get { return _toDate; }
            set { _toDate = value; OnPropertyChanged(nameof(ToDate)); }
        }

        private string _selectedSupplier; // Corresponds to CustomerName
        public string SelectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value; OnPropertyChanged(nameof(SelectedSupplier)); }
        }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set { _selectedStatus = value; OnPropertyChanged(nameof(SelectedStatus)); }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { _searchQuery = value; OnPropertyChanged(nameof(SearchQuery)); }
        }

        // Collections for ComboBoxes
        public ObservableCollection<string> Suppliers { get; set; } // Populated with Customer Names
        public ObservableCollection<string> StatusOptions { get; set; }

        // Properties for Metrics
        private string _totalPurchasesAmount;
        public string TotalPurchasesAmount
        {
            get { return _totalPurchasesAmount; }
            set { _totalPurchasesAmount = value; OnPropertyChanged(nameof(TotalPurchasesAmount)); }
        }

        private string _totalItemsPurchased;
        public string TotalItemsPurchased
        {
            get { return _totalItemsPurchased; }
            set { _totalItemsPurchased = value; OnPropertyChanged(nameof(TotalItemsPurchased)); }
        }

        // Collection for DataGrid
        public ObservableCollection<PurchaseRecordDisplayModel> PurchaseRecords { get; set; }

        // Properties for Charts
        public SeriesCollection MonthlyPurchaseSeries { get; set; }
        public string[] MonthlyPurchaseLabels { get; set; }

        public PurchaseRecordWindow()
        {
            InitializeComponent();
            this.DataContext = this; // Set DataContext for data binding

            // Initialize collections
            Suppliers = new ObservableCollection<string>();
            StatusOptions = new ObservableCollection<string> { "All", "Paid", "Pending", "Cancelled", "Refunded" };
            PurchaseRecords = new ObservableCollection<PurchaseRecordDisplayModel>();
            MonthlyPurchaseSeries = new SeriesCollection();
            MonthlyPurchaseLabels = new string[] { };

            // Set default filter values
            FromDate = DateTime.Today.AddMonths(-1); // Last month
            ToDate = DateTime.Today;
            SelectedStatus = "All";

            LoadInitialData();
        }

        /// <summary>
        /// Loads initial data including suppliers, metrics, and purchase records.
        /// </summary>
        private void LoadInitialData()
        {
            LoadSuppliers();
            LoadPurchaseRecords(); // This will also load metrics and charts based on current filters
        }

        /// <summary>
        /// Fetches distinct customer names (acting as "suppliers" for sales records) from the database.
        /// </summary>
        private void LoadSuppliers()
        {
            Suppliers.Clear();
            Suppliers.Add("All"); // Add "All" option
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT customer_name FROM customers ORDER BY customer_name";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Suppliers.Add(reader.GetString("customer_name"));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading suppliers: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred loading suppliers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Fetches purchase records (sales invoices) from the database based on current filters.
        /// Also updates metrics and chart data.
        /// </summary>
        private void LoadPurchaseRecords()
        {
            PurchaseRecords.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append(@"
                        SELECT
                            i.invoice_id,
                            i.invoice_number,
                            i.invoice_date,
                            c.customer_name,
                            i.total_amount,
                            i.status,
                            SUM(ii.quantity) AS total_items_sold_per_invoice
                        FROM invoices i
                        JOIN customers c ON i.customer_id = c.customer_id
                        LEFT JOIN invoice_items ii ON i.invoice_id = ii.invoice_id
                        WHERE 1=1
                    ");

                    // Apply date filters
                    if (FromDate.HasValue)
                    {
                        queryBuilder.Append($" AND i.invoice_date >= '{FromDate.Value:yyyy-MM-dd}'");
                    }
                    if (ToDate.HasValue)
                    {
                        queryBuilder.Append($" AND i.invoice_date <= '{ToDate.Value:yyyy-MM-dd}'");
                    }

                    // Apply supplier (customer) filter
                    if (!string.IsNullOrEmpty(SelectedSupplier) && SelectedSupplier != "All")
                    {
                        queryBuilder.Append($" AND c.customer_name = '{MySqlHelper.EscapeString(SelectedSupplier)}'");
                    }

                    // Apply status filter
                    if (!string.IsNullOrEmpty(SelectedStatus) && SelectedStatus != "All")
                    {
                        queryBuilder.Append($" AND i.status = '{MySqlHelper.EscapeString(SelectedStatus)}'");
                    }

                    queryBuilder.Append(" GROUP BY i.invoice_id, i.invoice_number, i.invoice_date, c.customer_name, i.total_amount, i.status");

                    // Apply search query (on invoice number or customer name)
                    if (!string.IsNullOrEmpty(SearchQuery))
                    {
                        queryBuilder.Append($" HAVING i.invoice_number LIKE '%{MySqlHelper.EscapeString(SearchQuery)}%' OR c.customer_name LIKE '%{MySqlHelper.EscapeString(SearchQuery)}%'");
                    }

                    queryBuilder.Append(" ORDER BY i.invoice_date DESC, i.invoice_id DESC");


                    using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            decimal currentTotalAmount = 0;
                            int currentTotalItems = 0;

                            while (reader.Read())
                            {
                                var record = new PurchaseRecordDisplayModel
                                {
                                    InvoiceId = reader.GetInt32("invoice_id"),
                                    InvoiceNumber = reader.GetString("invoice_number"),
                                    InvoiceDate = reader.GetDateTime("invoice_date"),
                                    CustomerName = reader.GetString("customer_name"),
                                    TotalAmount = reader.GetDecimal("total_amount"),
                                    Status = reader.GetString("status")
                                };
                                PurchaseRecords.Add(record);

                                // Aggregate for metrics (only for the currently filtered data)
                                currentTotalAmount += record.TotalAmount;
                                currentTotalItems += reader.IsDBNull(reader.GetOrdinal("total_items_sold_per_invoice")) ? 0 : reader.GetInt32("total_items_sold_per_invoice");
                            }

                            TotalPurchasesAmount = currentTotalAmount.ToString("C0"); // Currency format
                            TotalItemsPurchased = currentTotalItems.ToString("N0"); // Number format
                        }
                    }

                    LoadMonthlyPurchaseChartData(connection); // Pass connection to reuse
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error loading purchase records: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred loading purchase records: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Loads data for the monthly purchase trend chart.
        /// </summary>
        /// <param name="connection">An open MySqlConnection to reuse.</param>
        private void LoadMonthlyPurchaseChartData(MySqlConnection connection)
        {
            MonthlyPurchaseSeries.Clear();
            var salesValues = new ChartValues<double>();
            var monthLabels = new List<string>();

            // Query to get total sales amount per month, filtered by current date range
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"
                SELECT
                    DATE_FORMAT(invoice_date, '%Y-%m') AS month,
                    SUM(total_amount) AS monthly_sales
                FROM invoices
                WHERE 1=1
            ");

            if (FromDate.HasValue)
            {
                queryBuilder.Append($" AND invoice_date >= '{FromDate.Value:yyyy-MM-dd}'");
            }
            if (ToDate.HasValue)
            {
                queryBuilder.Append($" AND invoice_date <= '{ToDate.Value:yyyy-MM-dd}'");
            }

            queryBuilder.Append(" GROUP BY month ORDER BY month ASC;");

            using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monthLabels.Add(reader.GetString("month"));
                        salesValues.Add(reader.GetDouble("monthly_sales"));
                    }
                }
            }

            MonthlyPurchaseSeries.Add(new LineSeries
            {
                Title = "Monthly Sales (Rs.)",
                Values = salesValues,
                PointGeometrySize = 10,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Color.FromArgb(50, 30, 90, 175)) // Light blue fill
            });
            MonthlyPurchaseLabels = monthLabels.ToArray();
            OnPropertyChanged(nameof(MonthlyPurchaseSeries));
            OnPropertyChanged(nameof(MonthlyPurchaseLabels));
        }


        // --- Event Handlers for Filters and Actions ---

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPurchaseRecords(); // Reload data with current filter selections
        }

        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset filter properties
            FromDate = null;
            ToDate = null;
            SelectedSupplier = "All";
            SelectedStatus = "All";
            SearchQuery = string.Empty;

            LoadPurchaseRecords(); // Reload all data
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Export functionality to be implemented.", "Export Data");
            // Example: Logic to export PurchaseRecords to CSV/Excel
        }

        private void NewPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New Purchase entry window to be implemented.", "New Purchase");
            // Example: NewPurchaseWindow newPurchaseWindow = new NewPurchaseWindow();
            // newPurchaseWindow.ShowDialog(); // Show as dialog if you want to block parent
            // LoadPurchaseRecords(); // Refresh after adding new purchase
        }


        // --- Sidebar Navigation Event Handlers ---

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
            // This is the current window, no action needed
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
