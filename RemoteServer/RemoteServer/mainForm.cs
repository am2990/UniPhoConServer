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
        public mainForm()
        {
            InitializeComponent();
            
        }
        Thread connection;
        bool conStart=false,xlocked=false,ylocked=false;
        float acclimit = 0.2f,xacclimit=0.13f;
        String[] t = new string[100];
        
        int up=65,down=66,right=67,left=68,pos_x=1,pos_y=1;
        int[] staticDegrees={-7,0,7};
        float acc_x=0, acc_y=0,ax=0,ay=0,acc_xOld,acc_yOld,alim=1f;
        float changeLimit=(float)3;
        private void establishConnection(){
           
            t[65] = "up";
            t[66] = "down";
            t[67] = "right";
            t[68] = "left";
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9908);
            UdpClient newsock = new UdpClient(ipep);
            IPHostEntry hostname = Dns.GetHostEntry("");
            IPAddress[] ip = hostname.AddressList;
            //ipAddress_label.Text = ip[0].ToString();
            Console.WriteLine("Waiting for a client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            
            //data = newsock.Receive(ref sender);

            //Console.WriteLine("Message received from {0}:", sender.ToString());
            //Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
            //conStart = true;
            //string welcome = "Welcome to my test server";
            //data = Encoding.ASCII.GetBytes(welcome);
            //newsock.Send(data, data.Length, sender);

            while (conStart)
            {
                //Console.WriteLine("waiting");
                data = newsock.Receive(ref sender);
                string str = Encoding.ASCII.GetString(data, 0, data.Length);
                int count = str.Split(':').Length;
                //while (count < str.Length && str[count] == ':') count++;
                //Console.WriteLine(str);
                //Console.Clear();
                if (count == 2)
                {
                    int key = int.Parse(str.Split(':')[1]);
                    int click = int.Parse(str.Split(':')[0]);
                    processKey(click,key);
                }
                else if (count == 3)
                {
                    
                    float x = float.Parse(str.Split(':')[0]);
                    float y = float.Parse(str.Split(':')[1]);
                    float z = float.Parse(str.Split(':')[0]);
                    //Console.WriteLine(str + "|X:" + x + "|Y:" + y + "|Z: " + z);
                    if (x > xacclimit)
                    {
                        processKey(1, up);
                    }
                    else
                    {
                        processKey(0, up);
                    }

                    if (x < (-1) * xacclimit)
                    {
                        processKey(1, down);
                    }
                    if (x > (-1) *xacclimit)
                    {
                        processKey(0, down);
                    }

                    if (y > acclimit)
                    {
                        processKey(1, left);
                    }
                    else
                    {
                        processKey(0, left);
                    }

                    if (y < (-1) * acclimit)
                    {
                        processKey(1, right);
                    }
                    if (y > (-1) * acclimit)
                    {
                        processKey(0,right);
                    }

                }
                
                //Console.WriteLine(str);
                //newsock.Send(data, data.Length, sender);
            }

            Console.WriteLine("this should be ending it");
        }

        private void processKey(int click,int key){
            if (click == 1)
            {
                if (!InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    InputSimulator.SimulateKeyDown((VirtualKeyCode)key);
                    Console.WriteLine("pressing: " + t[key]);
                }

            }
            else
            {
                if (InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    InputSimulator.SimulateKeyUp((VirtualKeyCode)key);
                    Console.WriteLine("Releasing : " + t[key]);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            IPHostEntry hostname = Dns.GetHostEntry("");
            IPAddress[] ip = hostname.AddressList;
            ipAddress_label.Text = ip[0].ToString();
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
                btn.Text="Stop Connection";
            }
           // InputSimulator.SimulateKeyDown((VirtualKeyCode)6);
            
            //Thread.Sleep(5000);
            //InputSimulator.SimulateKeyDown(VirtualKeyCode.VK_A);
            //Thread.Sleep(2000);
            //InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_A);
        }
    }
}
