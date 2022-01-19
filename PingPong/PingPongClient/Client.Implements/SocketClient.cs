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
            Console.WriteLine("Enter Server IP:Port");
            string input = Console.ReadLine();
            string [] socket = input.Split(':');
            //string[] socket = new string []{"127.0.0.1","8080"}; 
            IPAddress ipAddr = IPAddress.Parse(socket[0]);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, int.Parse(socket[1]));

            Sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Sender.Connect(localEndPoint);
            Console.WriteLine("Connected to server");

        }

        public override void Job()
        {
            while (true) 
            {
                Console.WriteLine("Enter message to send:");
                string input = Console.ReadLine();
                byte[] messageSent = Encoding.ASCII.GetBytes(input);
                Sender.Send(messageSent);
                Console.WriteLine("Message sent");
                byte[] bytes = new Byte[1024];
                string data = null;
                while (true)
                {
                    int numByte = Sender.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, numByte);
                    Console.WriteLine("Message from Server -> {0}",data);
                    
                }
            }

        }
    }
}
