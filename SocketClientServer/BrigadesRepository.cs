using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SocketServer
{
    class BrigadesRepository
    {
        static Dictionary<int, string[]> brigadeAndSurnames =
            new Dictionary<int, string[]>
            {
                [1] = new[] { "МЕЛЬНИК", "БОЙКО", "КОВАЛЕНКО", "КОВАЛЬ" },
                [2] = new[] { "ПОЛІЩУК", "ТКАЧУК", "МОРОЗ", "ПЕТРЕНКО" },
                [3] = new[] { "РУДЕНКО", "СЕМЕНЮК", "КРАВЕЦЬ", "МАКАРЕНКО" }
            };
        public static Dictionary<int, string[]> Get()
        {
            return brigadeAndSurnames;
        }
    }
}
