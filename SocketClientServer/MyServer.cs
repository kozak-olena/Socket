using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace SocketServer
{
    class MyServer
    {
        static int Port = 5544;
        static string IPAdressOfServer = "127.0.0.1";

        public static Socket CreateSocketForServer()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IPAdressOfServer), Port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);

            Console.WriteLine("Server is running");
            return listenSocket;
        }

        public static void SendReceiveServer(Socket listenSocket)
        {
            while (true)
            {
                Socket handlerSocket = listenSocket.Accept();
                byte[] data = new byte[1];
                handlerSocket.Receive(data);

                Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + data[0].ToString());
                var brigadesAndSurnames = BrigadesRepository.Get();
                string[] surnames = brigadesAndSurnames[data[0]];
                StringBuilder stringBuilder = new StringBuilder();

                foreach (string surname in surnames)
                {
                    stringBuilder.Append($" {surname} ");           

                }
                string s = stringBuilder.ToString();
                byte[] dataToSend = Encoding.Unicode.GetBytes(s);

                handlerSocket.Send(dataToSend);

                //handlerSocket.Shutdown(SocketShutdown.Both);
                //handlerSocket.Close();
            }

        }
    }
}
