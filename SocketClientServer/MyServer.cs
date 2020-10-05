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

        public static Dictionary<int, string> CreateBrigades()
        {
            Dictionary<int, string> brigadeAndSurnames = new Dictionary<int, string>();
            brigadeAndSurnames.Add(1, "МЕЛЬНИК");
            brigadeAndSurnames.Add(1, "БОЙКО ");
            brigadeAndSurnames.Add(1, "КОВАЛЕНКО");
            brigadeAndSurnames.Add(1, "КОВАЛЬ");
            brigadeAndSurnames.Add(2, "ПОЛІЩУК");
            brigadeAndSurnames.Add(2, "ТКАЧУК");
            brigadeAndSurnames.Add(2, "МОРОЗ");
            brigadeAndSurnames.Add(2, "ПЕТРЕНКО");
            brigadeAndSurnames.Add(3, "РУДЕНКО");
            brigadeAndSurnames.Add(3, "СЕМЕНЮК");
            brigadeAndSurnames.Add(3, "КРАВЕЦЬ");
            brigadeAndSurnames.Add(3, "МАКАРЕНКО");
            return brigadeAndSurnames;
        }

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
