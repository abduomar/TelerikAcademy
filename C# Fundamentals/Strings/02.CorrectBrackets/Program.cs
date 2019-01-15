using System;

namespace CorrectBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(CheckForCorrectBrackets(text));
        }
        static string CheckForCorrectBrackets(string text)
        {
            char leftBracket = '(';
            char rightBracket = ')';
            string result = string.Empty;

            if (text.IndexOf(leftBracket) > text.IndexOf(rightBracket))
            {
                result = "Incorrect";
            }
            else
            {
                result = "Correct";
            }
            return result;
        }
    }
}
