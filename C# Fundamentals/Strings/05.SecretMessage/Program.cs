using System;
using System.Text;

namespace SecretMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = Console.ReadLine();
            char[] characters = secretMessage.ToCharArray();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = characters.Length-1 ; i >=0; i--)
            {
                if(char.IsLetter(characters[i]))
                {
                    stringBuilder.Append(characters[i]);
                }
            }
            Console.WriteLine(stringBuilder);
        }
        
    }
}
