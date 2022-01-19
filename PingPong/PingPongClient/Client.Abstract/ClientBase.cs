using System;
using System.Collections.Generic;
using System.Text;

namespace PingPongClient.Client.Abstract
{
    public abstract class ClientBase
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public abstract void ConnectToServer();
        public abstract void Job();

    }
}
