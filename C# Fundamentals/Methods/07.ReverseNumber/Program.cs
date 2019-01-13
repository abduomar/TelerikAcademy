using System;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine(ReverseNumber(number));
        }
        static string ReverseNumber(string number)
        {
            char[] digits = number.ToCharArray();
            string newNumber = string.Empty;
            for (int i = digits.Length-1; i > -1; i--)
            {
                newNumber += digits[i];
            }
            return newNumber;
            
        }
    }
}
