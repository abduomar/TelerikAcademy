using System;

namespace SubstringInText
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            char[] ch = text.ToCharArray();
            int counter = 0;
            for (int i = 0; i < ch.Length-1; i++)
            {
                string word = (ch[i].ToString() + ch[i + 1].ToString()).ToString();
                if(word==pattern)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
