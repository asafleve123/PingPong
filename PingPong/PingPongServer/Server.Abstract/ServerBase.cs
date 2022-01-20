using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.Server.Abstract
{
    public abstract class ServerBase
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public IClientHandlerFactory Factory { get; set; }
        protected ServerBase(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
        public abstract void BindServerSocket();
        public abstract IClientConnection Accept();
        public void AcceptClients() 
        {
            while (true) 
            {
                IClientConnection clientConnection = Accept();
                ClientHandlerBase clientHandler = Factory.getClientHandler(clientConnection);
                Task.Run(()=> { clientHandler.Job(); });
            }
        }
    }
}
