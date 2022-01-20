using System;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using PingPongServer.Server.Abstract;
using System.Collections.Generic;
using System.Text;
namespace PingPongServer.Server.Implements
{
    public class SocketServer : ServerBase<Socket>
    {
        public Socket Listener { get; set; }
        public SocketServer(string ip, int port) : base(ip, port)
        {
        }

        public override void Connect()
        {

            IPAddress ipAddr = IPAddress.Parse(Ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Port);
            Listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(localEndPoint);
        }
        public override async void ListenToSocket()
        {
            Console.WriteLine("Start lisening to socket");
            Listener.Listen(10);
            while (true)
            {
                Socket clientSocket = Listener.Accept();
                Task.Run(()=> { return Job(clientSocket); });
            }
        }

        public override async Task Job(Socket clientSocket)
        {
            Console.WriteLine("Get a client reuest");
            while (true)
            {
                byte[] bytes = new Byte[1024];
                string data = null;
                int numByte = clientSocket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, numByte);
                Console.WriteLine(data);
                byte[] message = Encoding.ASCII.GetBytes(data);
                clientSocket.Send(message);
            }
        }

    }
}
