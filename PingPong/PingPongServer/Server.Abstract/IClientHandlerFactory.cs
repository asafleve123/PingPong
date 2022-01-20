using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongServer.Server.Abstract
{
    public interface IClientHandlerFactory
    {
        public ClientHandlerBase getClientHandler(IClientConnection clientConnection);
    }
}
