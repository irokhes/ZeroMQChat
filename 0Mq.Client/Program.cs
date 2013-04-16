using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeroMQ;
namespace _0Mq.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // ZMQ Context and client socket
            using (ZmqContext context = ZmqContext.Create())
            using (ZmqSocket client = context.CreateSocket(SocketType.PUB))
            {
                client.Bind("tcp://*:9000");
                Console.WriteLine("Starting Zmq chat...");
                while (true)
                {
                    var message = Console.ReadLine();
                    client.Send("jorge: " + message, Encoding.ASCII);
                }
            }
        }

    } 
}
