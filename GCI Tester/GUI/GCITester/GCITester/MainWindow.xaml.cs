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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GCITester
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

        private void openPort_Click(object sender, RoutedEventArgs e)
        {
            tests.IsEnabled = true; 
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            settings window = new settings();
            window.Show();
            //this.Close();
        }

        private void tests_Click(object sender, RoutedEventArgs e)
        {
            tests window = new tests();
            window.Show();
            this.Close();
        }

        private void reports_Click(object sender, RoutedEventArgs e)
        {
            reports window = new reports();
            window.Show();
            this.Close();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
