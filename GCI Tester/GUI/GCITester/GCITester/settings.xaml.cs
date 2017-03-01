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
    }
}
