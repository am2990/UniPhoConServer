using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using RemoteServer;

namespace RemoteServer
{
    static class Discovery
    {
        private const int listenPort = 11225;
        private static string ip;
        public static void UdpDiscoveryServer()
        {

            bool done = false;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            string received_data;
            byte[] receive_byte_array;
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    // this is the line of code that receives the broadcase message.
                    // It calls the receive function from the object listener (class UdpClient)
                    // It passes to listener the end point groupEP.
                    // It puts the data from the broadcast message into the byte array
                    // named received_byte_array.
                    // I don't know why this uses the class UdpClient and IPEndPoint like this.
                    // Contrast this with the talker code. It does not pass by reference.
                    // Note that this is a synchronous or blocking call.
                    receive_byte_array = listener.Receive(ref groupEP);
                    //Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    Console.WriteLine("data follows \n{0}\nfrom {1}\n", received_data, groupEP.ToString());
                    string[] temp = received_data.Split(':');
                    Device d = new Device();
                    d.hostname = temp[0];
                    d.ip = groupEP.Address.ToString();
                    d.port = temp[1];
                    Program.connectedDevices.Add(d);
                    string name = "ApurvPC";
                    int port = Program.connectPort;
                    string text_to_send = name + ":" + getMmyIp() + ":" + port;
                    byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);

                    listener.Send(send_buffer , send_buffer.Length , groupEP);
                    //DiscoveryUDPReply(d);
                    

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        private static void DiscoveryUDPReply(Device d)
        {
            Boolean done = false;
            Boolean exception_thrown = false;
            string ip = getMmyIp();
            int c = 0;
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.Udp);
            
            IPAddress send_to_address = IPAddress.Parse(d.ip);
            
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, Convert.ToInt32(d.port));
            
            
            while (c<10)
            {
                c++;
                string name = "ApurvPC";    
                int port = Program.connectPort;
                string text_to_send = name+":"+ip+":"+port;
                if (text_to_send.Length == 0)
                {
                    done = true;
                }
                else
                {
                    // the socket object must have an array of bytes to send.
                    // this loads the string entered by the user into an array of bytes.
                    byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);

                    // Remind the user of where this is going.
                    Console.WriteLine("sending to address: {0} port: {1}",
                    sending_end_point.Address,
                    sending_end_point.Port);
                    try
                    {
                        sending_socket.SendTo(send_buffer, sending_end_point);
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception send_exception)
                    {
                        exception_thrown = true;
                        Console.WriteLine(" Exception {0}", send_exception.Message);
                    }
                    if (exception_thrown == false)
                    {
                        //Console.WriteLine("Message has been sent to the broadcast address");
                    }
                    else
                    {
                        exception_thrown = false;
                        Console.WriteLine("The exception indicates the message was not sent.");
                    }
                }
            } // end of while (!done)
        }

        public static void DiscoveryTCPReply(Device d)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse(d.ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, Convert.ToInt32(d.port));

                // Create a TCP/IP  socket.
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());
                    
                    string ip = getMmyIp();
                    string name = "ApurvPC";
                    int port = Program.connectPort;
                    string text_to_send = name + ":" + ip + ":" + port;
                    
                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes(text_to_send);

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.
                   // int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Sent = {0} of size {1}",
                        text_to_send , bytesSent);
                    //Console.ReadKey();
                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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


    }
}
