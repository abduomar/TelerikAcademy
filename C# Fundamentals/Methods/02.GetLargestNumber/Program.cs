using System;
using System.Linq;

namespace GetLargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
             int max = int.MinValue;
            Console.WriteLine(GetMax(numbers, max));
        }
        static int GetMax(int[] numbers, int max)
        {
            foreach (var item in numbers)
            {
                if(item>max)
                {
                    max = item;
                }
            }
            return max;
        }
    }
}
