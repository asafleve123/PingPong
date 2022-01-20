using System;
using PingPongClient.Client.Implements;
namespace PingPongClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcpBasedClient();
            client.ConnectToServer();
            client.Job();
        }
    }
}
