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

        //
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //This method is ran when the "Test Pin" Button is clicked!
        //Takes in the value the user places in the textbox, then 
        //sends that pin to the Communication.TestPin() method which
        //will send the data to the microcontroller to be tested.
        private void testPinButton_Click(object sender, RoutedEventArgs e)
        {
            byte Pin = (byte)Convert.ToInt32(pinNumberTextBox.Text);
            MessageBox.Show($"Pin to test = {Pin}");
            Communication.TestPin(Pin);
            
        }


        //This occurs when the communication process with the microcontroller is complete
        //It prints out the results gathered during said communication
        void Communication_OnResultComplete()
        {
            Double VoltageRef = Properties.Settings.Default.VoltageReference;
            Byte TestedPin = Communication.PinID;
            Double Voltage = Math.Round((Communication.PinValue * VoltageRef) / 1023.0, 3);
           
            AddLog("Pin " + TestedPin.ToString() + " Measured: " + Voltage.ToString() + "V  [0x" + Communication.PinValue.ToString("X4") + "]" + "\t Voltage Drop: " + (double)(VoltageRef - Voltage) );
        }


        //This method runs when the Open Port button is clicked.
        private void openPortBtn_Click(object sender, RoutedEventArgs e)
        {
            Communication.OpenPort();
            manualTestPinResults.Items.Add("Port Opened");
        }


        private void AddLog(String Text)
        {
            //This block is the windows FORM version of the invoke method, as seen in GCI's code, 
            //this.Invoke(new MethodInvoker(delegate
            //{
            //    manualTestPinResults.Items.Add(Text);
            //}));

            //The adjusted invoke method needed to prevent a single thread being requested by multiple processes.
            //It does the same as the block commented out above, just converted for WPF
            Dispatcher.BeginInvoke(new Action(delegate ()
            {
                manualTestPinResults.Items.Add(Text);
                manualTestPinResults.Items.MoveCurrentToLast();
                manualTestPinResults.ScrollIntoView(manualTestPinResults.Items.CurrentItem);
            }));

        }
        

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
    }
}
