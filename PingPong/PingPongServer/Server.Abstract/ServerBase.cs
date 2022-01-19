using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.Server.Abstract
{
    public abstract class ServerBase<T>
    {

        public string Ip { get; set; }
        public int Port { get; set; }
        protected ServerBase(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
        public abstract void Connect();
        public abstract void ListenToSocket();
        public abstract Task Job(T client);

    }
}
