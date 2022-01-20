using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongServer.Server.Abstract
{
    public abstract class ClientHandlerBase
    {
        public IClientConnection ClientConnection { get; set; }
        public ClientHandlerBase(IClientConnection clientConnection)
        {
            ClientConnection = clientConnection;
        }
        public abstract 
    }
}
