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

        public override void Connect(string ip, int port)
        {

            IPAddress ipAddr = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);
            Listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(localEndPoint);
        }
        public override async void ListenToSocket()
        {
            Listener.Listen(10);
            List<Task> tasks = new List<Task>();
            while (true)
            {
                Socket clientSocket = Listener.Accept();
                tasks.Add(Job(clientSocket));
            }
        }

        public override async Task Job(Socket clientSocket)
        {
            while (true)
            {
                byte[] bytes = new Byte[1024];
                string data = null;

                while (true)
                {
                    int numByte = clientSocket.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, numByte);
                    if (data.IndexOf("\n") > -1)
                        break;
                }
                byte[] message = Encoding.ASCII.GetBytes(data);
                clientSocket.Send(message);
            }
        }

    }
}
