using System;

namespace SayHello
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            PrintUserName(name);
        }
        static void PrintUserName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
