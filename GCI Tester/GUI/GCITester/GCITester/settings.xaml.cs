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

namespace GCITester
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        //This is the logic to occur when the "Open Port" Button is pressed
        private void port_settings_button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"open port - sender: {sender} \n e: {e}");
            //We will be opening the port with the following command, meaning we need to create a Communication.cs file
            //Communication.OpenPort();
            
        }

        //This is the logic to occur when the "Back To Menu" Button is pressed
        private void back_to_menu_button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"back to menu - sender: {sender} \n e: {e}");

            // MainWindow window = new MainWindow();
            // window.Show();
            //this.Close();
        }
        //Com Port Label and Box
        private void comPort_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void comPort_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Need to populate the list so lets create a list of items
            List<string> data = new List<string>();
            data.Add("COM3");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        //methods for the Baud rate
        private void baudRate_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void baudRate_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("9600");
            data.Add("14400");
            data.Add("19200");
            data.Add("28800");
            data.Add("38400");
            data.Add("56000");
            data.Add("57600");
            data.Add("115200");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        //methods for the data Bits
        private void dataBits_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dataBits_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("5");
            data.Add("6");
            data.Add("7");
            data.Add("8");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 3;

        }

        //methods for the parity
        private void parity_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void parity_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("None");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;

        }

        //methods for the stop Bits
        private void stopBits_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void stopBits_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("1");
            data.Add("1.5");
            data.Add("2");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
    }
}
