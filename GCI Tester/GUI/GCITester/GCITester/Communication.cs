using System;
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
        //public delegate void ResultComplete();
        //public static event ResultComplete OnResultComplete;
        //public delegate void OverFlowError();
        //public static event OverFlowError OnOverFlowError;
        public static String PortName = String.Empty;
        public static int BaudRate = 9600;
        public static int DataBits = 8;
        public static Parity Parity = System.IO.Ports.Parity.None;
        public static StopBits StopBit = StopBits.One;

        public static bool DelegateInitialized = false;

        private static bool ReadingResult = false;
        private static int StartLoc = 0;
        private static Byte PinId = 0;
        public static int PinValue = 0;




    }
}
