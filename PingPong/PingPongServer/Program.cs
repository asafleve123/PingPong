using System;
using PingPongServer.Server.Implements;
namespace PingPongServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //string ip = args[1];
            //int port = int.Parse(args[2]);
            string ip = "127.0.0.1";
            int port = 8080;
            var server = new SocketServer(ip,port);
            server.Connect();
            server.ListenToSocket();
        }
    }
}
