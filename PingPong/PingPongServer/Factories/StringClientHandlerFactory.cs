using System;
using System.Collections.Generic;
using System.Text;
using PingPongServer.Server.Abstract;
using PingPongServer.ClientHandlers;
namespace PingPongServer.Factories
{
    public class StringClientHandlerFactory : IClientHandlerFactory
    {
        public ClientHandlerBase getClientHandler(IClientConnection clientConnection)
        {
            return new StringClientPingPong(clientConnection);
        }
    }
}
