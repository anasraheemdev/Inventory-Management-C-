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
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  Handle the button click here (e.g., navigate to another window)
            MessageBox.Show("Button_Click event triggered!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //  Handle the button click here
            MessageBox.Show("Button_Click_1 event triggered!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //  Handle the button click here
            MessageBox.Show("Button_Click_2 event triggered!");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //  Handle the button click here
            MessageBox.Show("Button_Click_3 event triggered!");
        }
    }
}
