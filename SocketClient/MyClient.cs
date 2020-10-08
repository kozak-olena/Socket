using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace SocketClient
{
    class MyClient
    {
        static int port = 5544;

        public static Socket CreateSocketForClient(string IPAdressOfServer)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IPAdressOfServer), port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);
            if (socket.Connected)
            {
                Console.WriteLine("Connected to server");
            }

            return socket;
        }
        public static string CovnertToJSON(int input)
        {
            if (input == 1)
            {
                return JsonConvert.SerializeObject(new ServerRequest { Operation = "GetMyBrigadeNumber" });
            }
            else if (input == 2)
            {
                return JsonConvert.SerializeObject(new ServerRequest { Operation = " GetSurnamesOfMyBrigade" });
            }
            else if (input == 3)
            {
                return JsonConvert.SerializeObject(new ServerRequest { Operation = "GetSurnamesByBrigade'sID" });
            }
            else if (input == 4)
            {
                return JsonConvert.SerializeObject(new ServerRequest { Operation = "exit" });
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        class ServerRequest
        {
            public string Operation { get; set; }

        }

        public static void SendReceiveClient(Socket socket, string converted)
        {


            socket.Send(new[] { bytess });

            byte[] data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);

            Console.WriteLine(builder.ToString());

        }
    }
}
