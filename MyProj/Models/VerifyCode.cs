using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProj.Models
{
    public static class VerifyCode
    {
        static Random rand = new Random();
        static string vc = "";
        static char[] alphabet = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public static string GetVerifyCode(int lenght)
        {
            
            vc = "";
            for(int i = 0; i < lenght; i++)
            {
                //выбираем случайный символ из алфавита и пишем его в конец строки
                vc += alphabet[rand.Next(0, alphabet.Length)];
            }
            return vc;
        }
    }
}