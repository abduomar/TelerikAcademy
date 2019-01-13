using System;
using System.Linq;

namespace AppearanceCount
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numberX = int.Parse(Console.ReadLine());

            Console.WriteLine(AppearanceCount(numbers, numberX));
        }
        static int AppearanceCount(int[] numbers,int x)
        {
            int counter = 0;
            foreach (var item in numbers)
            {
                if(item==x)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
