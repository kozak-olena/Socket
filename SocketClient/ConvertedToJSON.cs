using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SocketClient
{
    class ConvertedToJSON
    {
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
    }
}
