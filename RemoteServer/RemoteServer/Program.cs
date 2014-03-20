using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RemoteServer;
using System.Threading;

namespace RemoteServer
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        public const int connectPort = 11224;

        public static List<Device> connectedDevices = new List<Device>();
        //[STAThread]
        static void Main()
        {
            Console.WriteLine("Starting Discovery Thread");
            ThreadStart udpServerThread = new ThreadStart(Discovery.UdpDiscoveryServer);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread udpSevrThrdHandle = new Thread(udpServerThread);
            udpSevrThrdHandle.Start();
            //stop the main thread for some time


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}
