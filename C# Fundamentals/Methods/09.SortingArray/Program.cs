using System;
using System.Linq;
namespace SortingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ", SortArray(numbers)));
        }
        static int[] SortArray(int[] numbers)
        {
            Array.Sort(numbers);
            return numbers;
        }
    }
}
