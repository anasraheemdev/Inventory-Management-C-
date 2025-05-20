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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddProductPage addProductPage = new AddProductPage();
            addProductPage.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // This button is labeled "Issued" in XAML
            // Consider if LoginPage is the correct navigation here.
            // If you have an "IssuedItemsPage":
            // IssuedItemsPage issuedItemsPage = new IssuedItemsPage();
            // issuedItemsPage.Show();
            // this.Close();

            // Current implementation:
            LoginPage loginPage = new LoginPage(); // Or perhaps IssuedPage?
            loginPage.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddCashier addCashier = new AddCashier();
            addCashier.Show();
            this.Close();
        }

        // --- Missing method added below ---
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // This handler is used by both "Brand" and "Units" buttons.
            // You need to implement the logic for what should happen when these buttons are clicked.

            // You can distinguish which button was clicked if necessary:
            if (sender is Button clickedButton)
            {
                // Access the content of the button to determine which one it is.
                // The content is a StackPanel, so you might need to inspect its children.
                var stackPanel = clickedButton.Content as StackPanel;
                if (stackPanel != null)
                {
                    var textBlock = stackPanel.Children.OfType<TextBlock>().LastOrDefault();
                    if (textBlock != null)
                    {
                        string buttonText = textBlock.Text;
                        if (buttonText == "Brand")
                        {
                            MessageBox.Show("Brand button clicked. Implement navigation or action for Brands.");
                            // Example:
                            // BrandPage brandPage = new BrandPage();
                            // brandPage.Show();
                            // this.Close();
                        }
                        else if (buttonText == "Units")
                        {
                            MessageBox.Show("Units button clicked. Implement navigation or action for Units.");
                            // Example:
                            // UnitsPage unitsPage = new UnitsPage();
                            // unitsPage.Show();
                            // this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Button_Click_5 called by an unexpected button.");
                        }
                        return;
                    }
                }
            }
            // Fallback or general action
            MessageBox.Show("Button_Click_5 executed. Define specific actions for Brand/Units.");
        }
    }
}