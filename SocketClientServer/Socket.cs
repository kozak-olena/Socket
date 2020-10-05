using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using SocketClientServer;

namespace SocketTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = MyServer.CreateSocketForServer();
        }
    }
}

