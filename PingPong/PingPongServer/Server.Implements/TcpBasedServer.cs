using PingPongServer.ClientConncetion.Implements;
using PingPongServer.Server.Abstract;
using System.Net;
using System.Net.Sockets;
namespace PingPongServer.Server.Implements
{
    public class TcpBasedServer : ServerBase
    {
        public TcpListener Server { get; set; }
        public TcpBasedServer(string ip, int port, IClientHandlerFactory factory) : base(ip, port, factory)
        {
        }
        public override void BindServerSocket()
        {
            IPAddress localAddr = IPAddress.Parse(Ip);
            Server = new TcpListener(localAddr, Port);
            Server.Start();
        }

        public override IClientConnection Accept()
        {
            TcpClient tcpClient = Server.AcceptTcpClient();
            return new TcpClientConnection(tcpClient);
        }

    }
}
