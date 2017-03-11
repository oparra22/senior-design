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
using System.IO;
using System.Diagnostics;

namespace GCITester
{
    /// <summary>
    /// Interaction logic for productionReport.xaml
    /// </summary>
    public partial class productionReport : Window
    {
        public productionReport()
        {
            InitializeComponent();
            //var myListBox = new ListBox();
             DirectoryInfo dinfo = new DirectoryInfo(@"C:\Users\Seth Pearce\Desktop\TestDirectory");
            FileInfo[] Files = dinfo.GetFiles();
           
            foreach (FileInfo file in Files)
            {
                listBox.Items.Add(file);
            }

          
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string file = listBox.SelectedItem.ToString();
            string fullFileName = System.IO.Path.Combine(@"C:\Users\Seth Pearce\Desktop\TestDirectory", file);
            Process.Start(fullFileName);
        }
    }
}
