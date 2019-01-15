using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(ReverseString(text));
        }
        static string ReverseString(string text)
        {
            char[] ch = text.ToCharArray();
            string newText=string.Empty;
            for (int i = ch.Length-1; i >=0; i--)
            {
                newText += ch[i];
            }
            return newText;
            
        }
    }
}

