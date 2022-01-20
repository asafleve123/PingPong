using System;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using PingPongServer.Server.Abstract;
using System.Collections.Generic;
using System.Text;
using PingPongServer.ClientConncetion.Implements;
namespace PingPongServer.Server.Implements
{
    public class SocketServer : ServerBase
    {

        public Socket Listener { get; set; }
        public SocketServer(string ip, int port, IClientHandlerFactory factory) : base(ip, port, factory)
        {
        }
        
        public override void BindServerSocket()
        {
            IPAddress ipAddr = IPAddress.Parse(Ip);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Port);
            Listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(localEndPoint);
            Listener.Listen(10);
        }

        public override IClientConnection Accept()
        {
            Socket clientSocket = Listener.Accept();
            return new SocketClientConnection(clientSocket);
        }

        /*
        
        
        public override async Task Job(Socket clientSocket)
        {
            Console.WriteLine("Get a client reuest");
            
        }
        */
    }
}
