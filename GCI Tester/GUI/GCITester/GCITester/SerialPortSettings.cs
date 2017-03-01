﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace GCITester
{
    public partial class SerialPortSettings : UserControl
    {
        String _COMPort = String.Empty;
        int _BaudRate = 9600;
        int _DataBits = 8;
        StopBits _StopBit = StopBits.One;
        Parity _Parity = Parity.None;

        public String[] ComPortList
        {
            get
            {
                return SerialPort.GetPortNames();
            }
        }

        public String COMPort
        {
            get
            {
                return _COMPort;
            }
            set
            {
                _COMPort = value;
                //MessageBox.Show($"_Comport = {_COMPort}");
                //MessageBox.Show($"comboCOMPort {comboCOMPort}");
                comboCOMPort.Text = _COMPort;
            }
        }

        public int BaudRate
        {
            get
            {
                return _BaudRate;
            }
            set
            {
                _BaudRate = value;
                comboBaudRate.Text = _BaudRate.ToString();
            }
        }

        public int DataBits
        {
            get
            {
                return _DataBits;
            }
            set
            {
                _DataBits = value;
                comboDataBits.Text = _DataBits.ToString();
            }
        }

        public StopBits StopBit
        {
            get
            {
                return _StopBit;
            }
            set
            {
                _StopBit = value;
                comboStopBits.Text = _StopBit.ToString();
            }
        }

        public Parity Parity
        {
            get
            {
                return _Parity;
            }
            set
            {
                _Parity = value;
                comboParity.Text = _Parity.ToString();
            }
        }


        public SerialPortSettings()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboCOMPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            _COMPort = comboCOMPort.Text;
        }

        private void PopulateCOMPorts()
        {
            comboCOMPort.Items.Clear();
            comboCOMPort.Items.AddRange(ComPortList);
            if (comboCOMPort.Items.Count > 0)
            {
                comboCOMPort.SelectedIndex = 0;
            }

        }

        private void SerialPortSettings_Load(object sender, EventArgs e)
        {
            PopulateCOMPorts();
        }

        private void comboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboParity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
