using System;
using System.Collections.Generic;
using System.Text;

namespace SocketClientServer
{
    class Brigades
    {
        static Dictionary<int, string> brigadeAndSurnames = new Dictionary<int, string>();
        public static Dictionary<int, string> CreateBrigades()
        {
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
    }
}
