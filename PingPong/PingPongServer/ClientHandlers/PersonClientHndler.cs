using PingPongServer.Server.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Commons;
namespace PingPongServer.ClientHandlers
{
    public class PersonClientHndler : ClientHandlerBase
    {
        public PersonClientHndler(IClientConnection clientConnection) : base(clientConnection)
        {
        }

        public override Task Job()
        {
            while (true)
            {
                byte[] bytes = MyClientConnection.Recive();
                MemoryStream memStream = new MemoryStream();
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(bytes, 0, bytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                memStream.Position = 0;
                object o= binForm.Deserialize(memStream);
                Person person = (Person)o;
                Console.WriteLine(person.ToString());
                memStream = new MemoryStream();
                binForm = new BinaryFormatter();
                binForm.Serialize(memStream, person);
                MyClientConnection.Send(memStream.ToArray());
            }
        }
    }
}
