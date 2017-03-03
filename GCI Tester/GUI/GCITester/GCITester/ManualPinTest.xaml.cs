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
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void testPinButton_Click(object sender, RoutedEventArgs e)
        {
            byte Pin = (byte)Convert.ToInt32(pinNumberTextBox.Text);
            Communication.TestPin(Pin);
        }


        //background methods
        //This runs at the end of each 
        void Communication_OnResultComplete()
        {
            Double VoltageRef = Properties.Settings.Default.VoltageReference;
            Byte TestedPin = Communication.PinID;
            Double Voltage = Math.Round((Communication.PinValue * VoltageRef) / 1023.0, 3);

            AddLog("Testing");
            //AddLog("Pin " + TestedPin.ToString() + " Measured: " + Voltage.ToString() + "V  [0x" + Communication.PinValue.ToString("X4") + "]");
        }

        private void openPortBtn_Click(object sender, RoutedEventArgs e)
        {
            //Calls the Open Port method in the Communicatin.cs file which opens the port that is chosen. (This works correctly)
            Communication.OpenPort();
            manualTestPinResults.Items.Add("Port Opened");
            MessageBox.Show("Open Port Method has finished Running! You may now test a pin!");
            
        }


        private void AddLog(String Text)
        {
            //This block was given from GCI Old code
            //this.Invoke(new MethodInvoker(delegate
            //{
            //    listLog.Items.Add(Text);
            //}));
            manualTestPinResults.Items.Add(Text);
        }

        private void frmManualTest_Load(object sender, EventArgs e)
        {
            Communication.OnResultComplete += new Communication.ResultComplete(Communication_OnResultComplete);
        }

        //private void frmManualTest_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Communication.OnResultComplete -= new Communication.ResultComplete(Communication_OnResultComplete);
        //}

    }
}
