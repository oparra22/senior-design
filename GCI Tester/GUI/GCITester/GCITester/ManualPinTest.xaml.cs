using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms;
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
    /// Interaction logic for ManualPinTest.xaml
    /// </summary>
    public partial class ManualPinTest : Window
    {
        public ManualPinTest()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Communication.OnResultComplete -= new Communication.ResultComplete(Communication_OnResultComplete);
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void testPinButton_Click(object sender, RoutedEventArgs e)
        {
            byte Pin = (byte)Convert.ToInt32(pinNumberTextBox.Text);
            //MessageBox.Show($"Pin to test = {Pin}");
            Communication.TestPin(Pin);
            
        }


        //background methods
        //This runs at the end of each 
        void Communication_OnResultComplete()
        {
            Double VoltageRef = Properties.Settings.Default.VoltageReference;
            Byte TestedPin = Communication.PinID;
            Double Voltage = Math.Round((Communication.PinValue * VoltageRef) / 1023.0, 3);
            //MessageBox.Show("Communication on result complete entered");
            //AddLog("Testing");
            //AddLog("Pin " + TestedPin.ToString() + " Measured: " + Voltage.ToString() + "V  [0x" + Communication.PinValue.ToString("X4") + "]");
            //this.Dispatcher.Invoke(new Action = () => manualTestPinResults.Items.Add("Testing"));
            //manualTestPinResults.Dispatcher.Invoke(new Action<int>)
            AddLog("Pin " + TestedPin.ToString() + " Measured: " + Voltage.ToString() + "V  [0x" + Communication.PinValue.ToString("X4") + "]");



            //manualTestPinResults.Items.Add("Pin " + TestedPin.ToString() + " Measured: " + Voltage.ToString() + "V  [0x" + Communication.PinValue.ToString("X4") + "]");
        }






        private void openPortBtn_Click(object sender, RoutedEventArgs e)
        {
            //Calls the Open Port method in the Communicatin.cs file which opens the port that is chosen. (This works correctly)
            Communication.OpenPort();
            manualTestPinResults.Items.Add("Port Opened");
            //MessageBox.Show("Open Port Method has finished Running! You may now test a pin!");
            
        }


        private void AddLog(String Text)
        {
            //This block was given from GCI Old code
            //this.Invoke(new MethodInvoker(delegate
            //{
            //    manualTestPinResults.Items.Add(Text);
            //}));


            Dispatcher.BeginInvoke(new Action(delegate ()
            {
                manualTestPinResults.Items.Add(Text);
            }));
        }
            //manualTestPinResults.Items.Add(Text);
        

        private void frmManualTest_Load(object sender, EventArgs e)
        {
            Communication.OnResultComplete += new Communication.ResultComplete(Communication_OnResultComplete);
        }

        private void testPinLoad(object sender, EventArgs e)
        {
            comLabel.Content = Properties.Settings.Default.ComPort;
            baudLabel.Content = Properties.Settings.Default.BaudRate;
            stopBitsLabel.Content = Properties.Settings.Default.StopBits;
            parityLabel.Content = Properties.Settings.Default.Parity;
            dataBitsLabel.Content = Properties.Settings.Default.DataBits;
        }
        //Not sure if this method is needed.
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Communication.OnResultComplete -= new Communication.ResultComplete(Communication_OnResultComplete);
        }

        //Old closing method.
        //private void frmManualTest_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Communication.OnResultComplete -= new Communication.ResultComplete(Communication_OnResultComplete);
        //}

    }
}
