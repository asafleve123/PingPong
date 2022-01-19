using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.Server.Abstract
{
    public abstract class ServerBase<T>
    {

        public string IP { get; set; }
        public int Port { get; set; }
        protected ServerBase(string ip, int port)
        {
            IP = ip;
            Port = port;
        }
        public abstract void Connect(string ip, int Port);
        public abstract void ListenToSocket();
        public abstract Task Job(T client);

    }
}
