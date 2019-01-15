using System;

namespace StringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int left = 0;
            if(text.Length<20)
            {
                left = 20 - text.Length;
                text+=new string('*',left);
            }
            Console.WriteLine(text);
        }
    }
}
