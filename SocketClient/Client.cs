using System;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input server's IP adress ");
            string IPAdressOfServer = Console.ReadLine();
            string input;
            do
            {
                Console.Write("Input bigade's number: ");
                input = Console.ReadLine();

                Socket socketForClient = MyClient.CreateSocketForClient(IPAdressOfServer);
                MyClient.SendReceiveClient(socketForClient, input);
            }
            while (input != "close");
        }
    }
}

