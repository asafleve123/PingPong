using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongServer.Server.Abstract
{
    public interface IClientConnection
    {
        public void Send(byte[] bytes);
        public byte[] Recive();
    }
}
