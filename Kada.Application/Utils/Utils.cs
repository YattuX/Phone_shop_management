using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Utils
{
    public static class Utils
    {
        static Random random = new Random();

        public static string GenerateRandomIdentifier(string startWith)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder identifier = new StringBuilder(startWith);

            for (int i = 0; i < 8; i++)
            {
                char randomChar = chars[random.Next(chars.Length)];
                identifier.Append(randomChar);
            }

            return identifier.ToString();
        }

    }
}
