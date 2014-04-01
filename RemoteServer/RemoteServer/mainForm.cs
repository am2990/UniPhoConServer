using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WindowsInput;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace RemoteServer
{
    public partial class mainForm : Form
    {
        private int modifiedStrokeFlag = 0;
        public mainForm()
        {
            InitializeComponent();
        }

        Thread connection;
        bool conStart = false;
        bool udptest = false;
        UdpClient newsock;


        private void establishConnection(){
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 12424);
            if (udptest == false)
            {
                newsock = new UdpClient(ipep);
                udptest = true;
            }
            IPHostEntry hostname = Dns.GetHostEntry("");
            IPAddress[] ip = hostname.AddressList;
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                       
            while (conStart)
            {
                data = newsock.Receive(ref sender);
                string str = Encoding.ASCII.GetString(data, 0, data.Length);
                int count = str.Split(':').Length;
                if (count == 2)
                {
                    
                    int click = int.Parse(str.Split(':')[0]);
                    if (click > 2)
                    {
                        string keys = str.Split(':')[1];
                        processModifiedStroke(click, keys);
                        continue;
                    }
                    int key = int.Parse(str.Split(':')[1]);
                    processKey(click,key);
                    continue;
                }
                else if (count == 3)
                {
                    float x = float.Parse(str.Split(':')[0]);
                    float y = float.Parse(str.Split(':')[1]);
                    float z = float.Parse(str.Split(':')[0]);
                    //Console.WriteLine(str + "|X:" + x + "|Y:" + y + "|Z: " + z);
                }

            }

        }

        private void processModifiedStroke(int click, string keys)
        {
            
            int key_1 = int.Parse(keys.Split(',')[0]);
            int key_2 = int.Parse(keys.Split(',')[1]);

                if (modifiedStrokeFlag != click)
                {
                    InputSimulator.SimulateModifiedKeyStroke((VirtualKeyCode)key_1, (VirtualKeyCode)key_2);
                    modifiedStrokeFlag = click;
                }

            
        }

        private void processKey(int click,int key){
            if (click == 1)
            {
                if (!InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    InputSimulator.SimulateKeyDown((VirtualKeyCode)key);
                }

            }
            else
            {
                if (InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    InputSimulator.SimulateKeyUp((VirtualKeyCode)key);
                }

            }
        }

        private static string getMmyIp()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            IPHostEntry hostname = Dns.GetHostEntry("");
            IPAddress[] ip = hostname.AddressList;
            ipAddress_label.Text = "Disconnected";
            
            if (conStart)
            {
                Console.WriteLine("Ending Connection");
                connection.Abort();
                conStart = false;
                Button btn = (Button)sender;
                btn.Text = "Start Connection";
            }
            else
            {
                connection = new Thread(new ThreadStart(establishConnection));
                conStart=true;
                connection.Name = "conThread";
                connection.Start();
                Button btn = (Button)sender;
                //string iptoadd = ip[0].ToString();
                ipAddress_label.Text = "Connected IP= " + getMmyIp() + " Port = 12424";
                btn.Text="Stop Connection";
                //Application.Exit();
            }
           
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
