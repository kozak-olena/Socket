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
                int bytes = 0;
                byte[] dataToReceive = new byte[256];
                StringBuilder builder = new StringBuilder();
                do
                {
                    bytes = handlerSocket.Receive(dataToReceive);
                    builder.Append(Encoding.UTF8.GetString(dataToReceive, 0, bytes));
                }
                while (handlerSocket.Available > 0);
                 


                Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());


                var brigadesAndSurnames = BrigadesRepository.Get();
                string[] surnames = brigadesAndSurnames[dataToReceive[0]];
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
