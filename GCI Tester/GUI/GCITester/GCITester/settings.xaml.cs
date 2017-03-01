using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms;
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
            InitializeValues();


        }

        private void InitializeValues()
        {
            this.serialPortSettings = new GCITester.SerialPortSettings();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSerialConfig = new System.Windows.Forms.TabPage();
            this.serialPortSettings = new GCITester.SerialPortSettings();
            this.tabA2DConfig = new System.Windows.Forms.TabPage();
            this.textVRef = new System.Windows.Forms.TextBox();
            this.labelVref = new System.Windows.Forms.Label();
            this.tabLearn = new System.Windows.Forms.TabPage();
            this.numericSigmaForFlyers = new System.Windows.Forms.NumericUpDown();
            //this.label4 = new System.Windows.Forms.Label();
            this.numericSigmaRange = new System.Windows.Forms.NumericUpDown();
            //this.label3 = new System.Windows.Forms.Label();
            this.numericNumberOfParts = new System.Windows.Forms.NumericUpDown();
            //this.label2 = new System.Windows.Forms.Label();
            this.numericLearnIterations = new System.Windows.Forms.NumericUpDown();
            //this.label1 = new System.Windows.Forms.Label();
            this.tabProduction = new System.Windows.Forms.TabPage();
            this.numericProductionIterations = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tabLifetime = new System.Windows.Forms.TabPage();
            this.numericLifetimeTemperature = new System.Windows.Forms.NumericUpDown();
            //this.label5 = new System.Windows.Forms.Label();
            this.numericLifetimeIterations = new System.Windows.Forms.NumericUpDown();
            //this.label6 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabDatabaseConnection = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.textDBHost = new System.Windows.Forms.TextBox();
            this.textDBName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textDBUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textDBPassWord = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabSerialConfig.SuspendLayout();
            this.tabA2DConfig.SuspendLayout();
            this.tabLearn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSigmaForFlyers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSigmaRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLearnIterations)).BeginInit();
            this.tabProduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericProductionIterations)).BeginInit();
            this.tabLifetime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLifetimeTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLifetimeIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabDatabaseConnection.SuspendLayout();
            //this.SuspendLayout();
            // 
            serialPortSettings.COMPort = "COM3";
        }

        //LoadSettings block taken from the previous program code
        private void LoadSettings()
        {
            serialPortSettings.COMPort = Properties.Settings.Default.ComPort;
            serialPortSettings.BaudRate = Properties.Settings.Default.BaudRate;
            serialPortSettings.DataBits = Properties.Settings.Default.DataBits;
            serialPortSettings.Parity = Properties.Settings.Default.Parity;
            serialPortSettings.StopBit = Properties.Settings.Default.StopBits;

            textVRef.Text = Properties.Settings.Default.VoltageReference.ToString();

            numericLearnIterations.Value = Properties.Settings.Default.Learn_DefaultIterations;
            numericNumberOfParts.Value = Properties.Settings.Default.Learn_DefaultNumberOfParts;
            numericSigmaRange.Value = Properties.Settings.Default.ProductionLimit_DefaultSigma;

            numericSigmaForFlyers.Value = Properties.Settings.Default.Learn_SigmaRangeForFlyers;

            numericProductionIterations.Value = Properties.Settings.Default.Production_DefaultIterations;

            numericLifetimeIterations.Value = Properties.Settings.Default.Lifetime_DefaultIterations;
            numericLifetimeTemperature.Value = (decimal)Properties.Settings.Default.Lifetime_DefaultTemperature;

            textDBHost.Text = Properties.Settings.Default.Database_Server;
            textDBName.Text = Properties.Settings.Default.Database_Name;
            textDBUserName.Text = Properties.Settings.Default.Database_Username;
            textDBPassWord.Text = Properties.Settings.Default.Database_Password;
        }
        //Save settings method to save the settings
        private void SaveSettings()
        {
            
            Properties.Settings.Default.ComPort = serialPortSettings.COMPort;
            Properties.Settings.Default.BaudRate = serialPortSettings.BaudRate;
            Properties.Settings.Default.DataBits = serialPortSettings.DataBits;
            Properties.Settings.Default.Parity = serialPortSettings.Parity;
            Properties.Settings.Default.StopBits = serialPortSettings.StopBit;

            Properties.Settings.Default.VoltageReference = double.Parse(textVRef.Text);

            Properties.Settings.Default.Learn_DefaultIterations = (int)numericLearnIterations.Value;
            Properties.Settings.Default.Learn_DefaultNumberOfParts = (int)numericNumberOfParts.Value;
            Properties.Settings.Default.ProductionLimit_DefaultSigma = (int)numericSigmaRange.Value;

            Properties.Settings.Default.Learn_SigmaRangeForFlyers = (int)numericSigmaForFlyers.Value;

            Properties.Settings.Default.Production_DefaultIterations = (int)numericProductionIterations.Value;

            Properties.Settings.Default.Lifetime_DefaultIterations = (int)numericLifetimeIterations.Value;
            Properties.Settings.Default.Lifetime_DefaultTemperature = (double)numericLifetimeTemperature.Value;

            Properties.Settings.Default.Database_Server = textDBHost.Text;
            Properties.Settings.Default.Database_Name = textDBName.Text;
            Properties.Settings.Default.Database_Username = textDBUserName.Text;
            Properties.Settings.Default.Database_Password = textDBPassWord.Text;

            Properties.Settings.Default.Save();
        }
        //This is the logic to occur when the "Open Port" Button is pressed
        private void open_port_button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"open port - sender: {sender} \n e: {e}");
            //We will be opening the port with the following command, meaning we need to create a Communication.cs file
            Communication.OpenPort();
            
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
            /* List<string> data = new List<string>();
             data.Add("COM3");
             var comboBox = sender as ComboBox;
             comboBox.ItemsSource = data;
             comboBox.SelectedIndex = 0;*/
            //this.serialPortSettings.COMPort = "COM3";
            //this.serialPortSettings.TabIndex = 0;
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = serialPortSettings.ComPortList;


        }

        //methods for the Baud rate
        private void baudRate_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void baudRate_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            /*List<string> data = new List<string>();
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
            comboBox.SelectedIndex = 0;*/
            //serialPortSettings.BaudRate = 9600;
        }

        //methods for the data Bits
        private void dataBits_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dataBits_comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            /*List<string> data = new List<string>();
            data.Add("5");
            data.Add("6");
            data.Add("7");
            data.Add("8");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 3;*/

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

        private void save_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
            this.Close();

        }

       

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();
        }
    }
    public partial class Settings
    {
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSerialConfig;
        private System.Windows.Forms.TabPage tabA2DConfig;
        private SerialPortSettings serialPortSettings;
        private System.Windows.Forms.Label labelVref;
        private System.Windows.Forms.TextBox textVRef;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabLearn;
        private System.Windows.Forms.NumericUpDown numericNumberOfParts;
        //private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericLearnIterations;
        //private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabProduction;
        private System.Windows.Forms.NumericUpDown numericSigmaRange;
        //private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabLifetime;
        private System.Windows.Forms.NumericUpDown numericSigmaForFlyers;
        //private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericLifetimeTemperature;
        //private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericLifetimeIterations;
        //private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericProductionIterations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabDatabaseConnection;
        private System.Windows.Forms.TextBox textDBName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textDBHost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textDBUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textDBPassWord;
        private System.Windows.Forms.Label label11;
        

    }
}
