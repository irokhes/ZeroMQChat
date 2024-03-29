﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace _0Mq.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ZmqContext context = ZmqContext.Create())
            using (ZmqSocket server = context.CreateSocket(SocketType.SUB))
            {
                server.SubscribeAll();
                for (int i = 1; i < 255; i++)
                {
                    string address = string.Format("tcp://192.168.11.{0}:9000", i);

                    server.Connect(address);

                }

                while (true)
                {
                    // Wait for next request from client
                    string message = server.Receive(Encoding.ASCII);
                    Console.WriteLine("{0}: {1}", DateTime.Now.ToShortTimeString(), message);

                }
            }

        }
    }
}
