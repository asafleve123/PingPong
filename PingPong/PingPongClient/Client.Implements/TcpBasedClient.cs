using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using PingPongClient.Client.Abstract;
using Commons;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PingPongClient.Client.Implements
{
    class TcpBasedClient : ClientBase
    {
        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }
        public override void ConnectToServer()
        {
            //Console.WriteLine("Enter Server IP:Port");
            //string input = Console.ReadLine();
            //string [] socket = input.Split(':');
            string[] socket = new string[] { "127.0.0.1", "8080" };
            Client = new TcpClient(socket[0], int.Parse(socket[1]));
            Stream = Client.GetStream();
        }

        public override void Job()
        {
            IFormatter formatter = new BinaryFormatter();
            while (true) 
            {
                Console.WriteLine("Enter Person Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Person Age:");
                int age = int.Parse(Console.ReadLine());
                Person person = new Person(name,age);
                formatter.Serialize(Stream, person);
                Console.WriteLine("Message sent");

                Person p = (Person)formatter.Deserialize(Stream);
                
                Console.WriteLine("Message from Server -> {0}", p.ToString());
            }
        }
    }
}
