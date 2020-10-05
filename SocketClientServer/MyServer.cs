using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace SocketClientServer
{
    class MyServer
    {
        static int Port = 5544;
        static string IPAdressOfServer = Console.ReadLine();

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
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байтов
                byte[] data = new byte[256]; // буфер для получаемых данных

                do
                {
                    bytes = handlerSocket.Receive(data);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (handlerSocket.Available > 0);

                Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                // отправляем ответ
                string message = "ваше сообщение доставлено";
                data = Encoding.Unicode.GetBytes(message);
                handlerSocket.Send(data);
                // закрываем сокет
                handlerSocket.Shutdown(SocketShutdown.Both);
                handlerSocket.Close();
            }

        }
    }
}
