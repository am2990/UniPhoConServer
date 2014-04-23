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
using InputManager;

namespace RemoteServer
{
    public partial class mainForm : Form
    {
        private int modifiedStrokeFlag = 0;
        private bool setval = false;
        float _roll = 0;
        float _pitch = 0;
        float _yaw = 0;

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
                    
                    if (click > 99)
                    {
                        string keys = str.Split(':')[1];
                        processModifiedStroke(click, keys);
                        continue;
                    }
                    int key = int.Parse(str.Split(':')[1]);
                    if (click == 2)
                    {
                        processGameKey(click, key);
                        continue;
                    }
                    if (click == 8 || click == 9)
                    {
                        processStaticKey(click, key);
                        continue;
                    }
                    processKey(click,key);
                    continue;
                }
                else if (count == 3)
                {
                    float roll = float.Parse(str.Split(':')[0]);
                    float pitch = float.Parse(str.Split(':')[1]);
                    float yaw = float.Parse(str.Split(':')[2]);
                    Console.WriteLine(str + "|roll:" + roll + "|pitch:" + pitch + "|yaw: " + yaw);
                    processValues(pitch, roll, yaw);


                }

            }

        }

        private void processStaticKey(int click, int key)
        {
            if (click == 9)
            {
                if (!InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    InputSimulator.SimulateKeyDown((VirtualKeyCode)key);
                    System.Console.WriteLine("Button Down {0}", key);

                }

            }
            else
            {
                if (InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    InputSimulator.SimulateKeyUp((VirtualKeyCode)key);
                    System.Console.WriteLine("Button Up {0}", key);
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
        
        private void processKey(int click,int key) {
            if (click == 1)
            {
                if (!InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    //InputSimulator.SimulateKeyDown((VirtualKeyCode)key);
                    System.Console.WriteLine("Button Down {0}", key);
                    Keyboard.KeyDown((Keys)key);

                }

            }
            else
            {
                if (InputSimulator.IsKeyDown((VirtualKeyCode)key))
                {
                    //InputSimulator.SimulateKeyUp((VirtualKeyCode)key);
                    System.Console.WriteLine("Button Up {0}", key);
                   Keyboard.KeyUp((Keys)key);
                }

            }
        }

        private void processValues(float pitch, float roll, float yaw)
        {

            string data;

            if (roll > 20)
            {
                //right arrow
                //data = "1:" + "39";
                //prev = "39";
                //int c = 0;
                System.Diagnostics.Debug.WriteLine("Right Arrow {0}", pitch);

                //while (c < 10)
                // {
                //data = "1:32";

                processGameKey(1, 39);
                //c++;
                // }
            }
            else if (roll < -20)
            {
                //left arrow
                //data = "1:37";
                //prev = "37";
                //int c = 0;
                //System.Diagnostics.Debug.WriteLine("Left Arrow {0}", delta_pitch);
                //while (c < 10)
                //{
                    //System.Diagnostics.Debug.WriteLine("Fired down {0}", c++);
                    //data = "1:32";
                processGameKey(1, 37);
                  //  c++;
                //}
            }
            else if (roll > -20 && roll < 20)
            {
                processGameKey(0, 37);
                processGameKey(0, 39);
            }
            if (pitch < -15)
            {
                //down arrow
                //data = "1:40";
                //prev = "40";
               // int c = 0;
                System.Diagnostics.Debug.WriteLine("Down Arrow {0}", roll);
               // while (c < 10)
               // {
                    //System.Diagnostics.Debug.WriteLine("Fired down {0}", c++);
                    //data = "1:32";
                    //sendData.Send(serverName, portNumber, data);
                    //c++;
                //}
                processGameKey(1,40);
            }
            else if (pitch > 10)
            {
                //up arrow
               // data = "1:38";
              // // prev = "38";
              //  int c = 0;
                System.Diagnostics.Debug.WriteLine("Up Arrow {0}", pitch);
               // while (c < 10)
              //  {
                    //System.Diagnostics.Debug.WriteLine("Fired down {0}", c++);
                    //data = "1:32";
               //     sendData.Send(serverName, portNumber, data);
                //    c++;
               // }
                processGameKey(1,38);
            }
            else if( pitch >= -15 && pitch<= 10 )
            {
                processGameKey(0, 38);
                processGameKey(0, 40);
            }
            /*
            
            else if (delta_yaw < -20)
            {
                //E arrow
                data = "1:69";
                prev = "69";
                int c = 0;
                System.Diagnostics.Debug.WriteLine("E {0}", delta_yaw);
                while (c < 10)
                {
                    //System.Diagnostics.Debug.WriteLine("Fired down {0}", c++);
                    //data = "1:32";
                    sendData.Send(serverName, portNumber, data);
                    c++;
                }
            }
            else if (delta_yaw > 20)
            {
                //Q arrow
                data = "1:81";
                prev = "81";
                int c = 0;
                System.Diagnostics.Debug.WriteLine("Q {0}", delta_yaw);
                while (c < 10)
                {
                    //System.Diagnostics.Debug.WriteLine("Fired down {0}", c++);
                    //data = "1:32";
                    sendData.Send(serverName, portNumber, data);
                    c++;
                }
            }
            else
            {
                data = "0:" + prev;
                int c = 0;
                System.Diagnostics.Debug.WriteLine("KeyUp {0}", data);
                while (c < 10)
                {
                    //System.Diagnostics.Debug.WriteLine("Fired down {0}", c++);
                    //data = "1:32";
                    sendData.Send(serverName, portNumber, data);
                    c++;
                }
            }*/


        }

        private void processGameKey(int click, int key)
        {
            if (click == 1)
            {
                
                    //InputSimulator.SimulateKeyDown((VirtualKeyCode)key);
                    Keyboard.KeyDown((Keys)key);
                    //System.Console.WriteLine("Key Down {0}", key);
                

            }
            else
            {
                
                    //InputSimulator.SimulateKeyUp((VirtualKeyCode)key);
                    Keyboard.KeyUp((Keys)key);
                    //System.Console.WriteLine("Key Up {0}", key);
                

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
