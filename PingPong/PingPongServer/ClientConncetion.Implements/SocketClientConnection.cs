using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using PingPongServer.Server.Abstract;
using System.Linq;
namespace PingPongServer.ClientConncetion.Implements
{
    public class SocketClientConnection : IClientConnection
    {
        public Socket ClientSocket { get; set; }

        public SocketClientConnection(Socket clientSocket)
        {
            ClientSocket = clientSocket;
        }

        public byte[] recive()
        {
            byte[] bytes = new Byte[1024];
            int numByte = ClientSocket.Receive(bytes);
            return bytes.Take(numByte).ToArray();
        }

        public void send(byte[] bytes)
        {
            ClientSocket.Send(bytes);
        }
    }
}
