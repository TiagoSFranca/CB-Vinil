using System;
using System.Text;

namespace CBVinil.Common.Helpers
{
    public static class Base64Helper
    {
        public static string Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
