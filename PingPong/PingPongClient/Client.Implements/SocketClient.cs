using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using PingPongClient.Client.Abstract;
namespace PingPongClient.Client.Implements
{
    public class SocketClient : ClientBase
    {
        public Socket Sender { get; set; }

        public override void ConnectToServer()
        {
            Console.WriteLine("Enter IP:Port");
            string input = Console.ReadLine();
            string [] socket = input.Split(':');

            IPAddress ipAddr = IPAddress.Parse(socket[0]);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, int.Parse(socket[1]));

            Sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Sender.Connect(localEndPoint);
        }

        public override void Job()
        {
            while (true) 
            {
                string input = Console.ReadLine();
                byte[] messageSent = Encoding.ASCII.GetBytes(input);
                Sender.Send(messageSent);

                byte[] bytes = new Byte[1024];
                string data = null;
                while (true)
                {
                    int numByte = Sender.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, numByte);
                    if (data.IndexOf("\n") > -1)
                    {
                        break;
                    }
                }
                Console.WriteLine("Message from Server -> {0}",data);
            }

        }
    }
}
