using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using PingPongServer.Server.Abstract;
using System.Linq;
namespace PingPongServer.ClientConncetion.Implements
{
    public class TcpClientConnection : IClientConnection
    {

        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }
        public TcpClientConnection(TcpClient client)
        {
            Client = client;
            Stream = Client.GetStream();
        }
        public byte[] Recive()
        {
            byte[] bytes = new Byte[1024];
            int numByte = Stream.Read(bytes, 0, bytes.Length);
            return bytes.Take(numByte).ToArray();
        }

        public void Send(byte[] bytes)
        {
            Stream.Write(bytes, 0, bytes.Length);
        }
    }
}
