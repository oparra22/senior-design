﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added Libraries
using System.IO.Ports;
using System.Threading;
using System.Windows;


namespace GCITester
{
    class Communication
    {
        //This class is responsible for Communication, mostly handling the serial port information!
        
        //Variables from previous system
        public static SerialPort comPort = new SerialPort();    //Create the port Object
        public static byte[] RecvBuffer = new Byte[0xFFFF];     //Initialize the Receiving Buffer to 0xFFFF - Why?
        public static int RecvBufferCurIndex = 0;               //Initialize index to 0

        public static bool PortOpen = false;

        //**********Need to go through these variables************
        public delegate void ResultComplete();
        public static event ResultComplete OnResultComplete;
        public delegate void OverFlowError();
        public static event OverFlowError OnOverFlowError;
        public static String PortName = String.Empty;
        public static int BaudRate = 9600;
        public static int DataBits = 8;
        public static Parity Parity = System.IO.Ports.Parity.None;
        public static StopBits StopBit = StopBits.One;

        public static bool DelegateInitialized = false;

        private static bool ReadingResult = false;
        private static int StartLoc = 0;
        public static Byte PinID = 0;
        public static int PinValue = 0;

        //Method for opening the port
        public static bool OpenPort()
        {
            //
            try
            {
                //If Portname is still empty just like it is when it is initialized
                if(PortName.Length == 0)
                {
                    //PortName = "COM1";//Just for Prototyping
                    PortName = Properties.Settings.Default.ComPort;//ComPort is grabbed from the automatically generated code so need to figure out how to get this to work. AKA Set up settings
                }
                if(comPort.IsOpen == true)
                {
                    PortOpen = true;
                    comPort.Close();//If it is open, then close it instead of having a separate close method(double check why later)
                }
                //Delay? why
                Thread.Sleep(100);
                //This block was directly Copied and pasted from previous code
                comPort.BaudRate = Properties.Settings.Default.BaudRate;    //BaudRate
                comPort.DataBits = Properties.Settings.Default.DataBits;    //DataBits
                comPort.StopBits = Properties.Settings.Default.StopBits;    //StopBits
                comPort.Parity = Properties.Settings.Default.Parity;    //Parity
                comPort.PortName = PortName;   //PortName
                comPort.Handshake = Handshake.None;
                comPort.ReadTimeout = 1000;
                comPort.WriteTimeout = 1000;
                //comPort.ReceivedBytesThreshold = 10;

                //This block was also copied, need to double check what it does
                if (DelegateInitialized == false)
                {
                    DelegateInitialized = true;
                    comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    comPort.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorHandler);
                }


                comPort.Open();
                comPort.DtrEnable = true;
                comPort.RtsEnable = true;
                ClearBuffers();
                return true;//If try block completes then it was opened successfully, return true
            }//End Try Block
            catch
            {
                //AddOutput(ex.Message) //Commented out of previous code. debugging purposes. Test!
                return false;
            }//End catch
        }//End Open Port

        public static void ClearBuffers()
        {
            RecvBuffer = new byte[0xFFFF];
            Array.Clear(RecvBuffer, 0, 0xFFFF);
            RecvBufferCurIndex = 0;
        }

        public static void ErrorHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Please screen shot this and send to amagner@abound.com - " + e.
            switch (e.EventType)
            {
                case SerialError.Frame:
                    System.Windows.Forms.MessageBox.Show("Framing error");
                    break;
                case SerialError.Overrun:
                    //System.Windows.Forms.MessageBox.Show("Overrun error");

                    if (OnOverFlowError != null)
                        OnOverFlowError();
                    break;
                case SerialError.RXOver:
                    System.Windows.Forms.MessageBox.Show("RX Over");
                    break;
                case SerialError.RXParity:
                    System.Windows.Forms.MessageBox.Show("RX Parity");
                    break;
                case SerialError.TXFull:
                    System.Windows.Forms.MessageBox.Show("TX Parity");
                    break;
            }
        }


        private static void ResetRecvBuffer()
        {
            ReadingResult = false;
            RecvBuffer = new byte[0xFFFF];
            RecvBufferCurIndex = 0;
            Array.Clear(RecvBuffer, 0, 0xFFFF);
        }



        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType != SerialData.Chars)
            {
                return;
            }
            SerialPort sp = (SerialPort)sender;
            //string indata = sp.ReadExisting();
            string indata = string.Empty;

            byte[] buffer = new byte[sp.BytesToRead];
            int bytesRead = sp.Read(buffer, 0, buffer.Length);


            // message has successfully been received
            //indata = Encoding.ASCII.GetString(buffer, 0, bytesRead);


            for (int i = 0; i < bytesRead; i++)
            {


                byte Byte = buffer[i];



                RecvBuffer[RecvBufferCurIndex] = Byte;


                if (RecvBuffer[RecvBufferCurIndex] == 'R' && ReadingResult == false)
                {
                    ReadingResult = true;
                    StartLoc = RecvBufferCurIndex;
                    /*PinID = (int)indata[i + 1];
                    PinValue = (indata[i + 2] << 8) | indata[i + 3];
                    if (OnResultComplete != null)
                        OnResultComplete();
                    RecvBuffer = new char[0xFFFF];
                    RecvBufferCurIndex = 0;
                    Array.Clear(RecvBuffer, 0, 0xFFFF);
                    return;*/

                }

                if (ReadingResult == true && RecvBufferCurIndex >= 5)
                {
                    PinID = (Byte)RecvBuffer[StartLoc + 1];
                    PinValue = (RecvBuffer[StartLoc + 2] << 8) | RecvBuffer[StartLoc + 3];

                    if (RecvBuffer[StartLoc + 4] == 255 && RecvBuffer[StartLoc + 5] == 255)
                    {
                        if (OnResultComplete != null)
                            OnResultComplete();
                    }
                    ResetRecvBuffer();
                    return;
                }

                RecvBufferCurIndex++;
            }
        }

        //Function for testing a pin, used in manually test a pin screen
        public static void TestPin(Byte PinID)
        {
            if(!(comPort.IsOpen == true))
            {
                OpenPort();
            }

            Byte[] Data = new Byte[2];
            Data[0] = (Byte)'T';
            Data[1] = PinID;

            comPort.Write(Data, 0, 2);
        }



    }
}
