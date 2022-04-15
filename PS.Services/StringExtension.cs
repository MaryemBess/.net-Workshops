using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public static class StringExtension
    {
        public static void FirstCharToUpper(this string s) // on ajoute this , pour que le compilateur considere ceci comme une fonction extended
        {
            string a = s[0].ToString();
            
            s = a.ToUpper() + s.Substring(1);
            Console.WriteLine(s);
        }
    }
}
