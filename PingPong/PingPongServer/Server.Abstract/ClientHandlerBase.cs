using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace PingPongServer.Server.Abstract
{
    public abstract class ClientHandlerBase
    {
        public IClientConnection MyClientConnection { get; set; }
        public ClientHandlerBase(IClientConnection clientConnection)
        {
            MyClientConnection = clientConnection;
        }
        public abstract Task Job();
    }
}
