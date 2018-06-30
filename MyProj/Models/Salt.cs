using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProj.Models
{
    public static class USalt
    {
        private static string salt = "";
        private static Random rand = new Random();
        public static string GenSalt(int length)
        {
            salt = "";
            for (int i = 0; i < length; i++)
            {
                salt += Char.ConvertFromUtf32(rand.Next(33, 126));
            }
            return salt;
        }
    }
}