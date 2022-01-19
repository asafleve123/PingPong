using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.Server.Abstract
{
    public abstract class ServerBase
    {

        public string IP { get; set; }
        public int Port { get; set; }
        protected ServerBase(string iP, int port)
        {
            IP = iP;
            Port = port;
        }
        public abstract void Connect(string ip, int Port);
        public abstract void ListenToSocket();
        public abstract Task Job();

    }
}
