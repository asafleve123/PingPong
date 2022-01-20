using PingPongServer.Server.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.ClientHandlers
{
    public class PersonClientHndler : ClientHandlerBase
    {
        public PersonClientHndler(IClientConnection clientConnection) : base(clientConnection)
        {
        }

        public override Task Job()
        {
            
        }
    }
}
