using System;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {
        public static void DisplayOptions()
        {
            Console.Write("To get my brigade's number press 1");
            Console.Write("To get surnames of my brigade press 2");
            Console.Write("To get surnames by brigade's ID press 3");
            Console.Write("To exit press 4");

        }

        public static int ReadUserInput()
        {
            string input;
            input = Console.ReadLine();
            bool successes = int.TryParse(input, out int result);
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Input server's IP adress ");
            string IPAdressOfServer = Console.ReadLine();
            DisplayOptions();
            int input = ReadUserInput();
            do
            {
                Socket socketForClient = MyClient.CreateSocketForClient(IPAdressOfServer);
                string JSONConverted = ConvertedToJSON.CovnertToJSON(input);

                MyClient.SendReceiveClient(socketForClient, JSONConverted);
            }
            while (input != 4);
        }

    }
}


