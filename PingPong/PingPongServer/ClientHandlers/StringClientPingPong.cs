using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using PingPongServer.Server.Abstract;
namespace PingPongServer.ClientHandlers
{
    public class StringClientPingPong : ClientHandlerBase
    {
        public StringClientPingPong(IClientConnection clientConnection) : base(clientConnection)
        {
        }

        public override Task Job()
        {
            while (true)
            {
                byte[] bytes = MyClientConnection.Recive();
                string data = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine(data);
                byte[] message = Encoding.ASCII.GetBytes(data);
                MyClientConnection.Send(message);
            }
        }
    }
}
