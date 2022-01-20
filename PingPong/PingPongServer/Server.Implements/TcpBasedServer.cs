using System;
using System.Collections.Generic;
using System.Text;
using PingPongServer.Server.Implements;
using PingPongServer.Factories;
using PingPongServer.Server.Abstract;

namespace PingPongServer.Server.Implements
{
    public class TcpBasedServer : ServerBase
    {
        public TcpBasedServer(string ip, int port, IClientHandlerFactory factory) : base(ip, port, factory)
        {
        }

        public override IClientConnection Accept()
        {
            throw new NotImplementedException();
        }

        public override void BindServerSocket()
        {
            throw new NotImplementedException();
        }
    }
}
