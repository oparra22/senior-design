﻿using System;
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

        private void button_Copy7_Click(object sender, RoutedEventArgs e)
        {
            //window.Visibility = Visibility.Visible;
            Settings window = new Settings();
            window.Show();
            //this.Close();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            ManualPinTest window = new ManualPinTest();
            window.Show();
        }
        private void label_Load(object sender, EventArgs e)
        {
            
        }
    }
}
