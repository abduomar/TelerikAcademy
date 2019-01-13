using System;
using System.Linq;

namespace LargerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(CheckIfBiggerThanNeighbours(numbers));
        }
        static int CheckIfBiggerThanNeighbours(int[] numbers)
        {
            int counter = 0;

            for (int i = 0; i <numbers.Length-1; i++)
            {
                if(i>0)
                {
                    if(numbers[i]>numbers[i+1] && numbers[i]>numbers[i-1])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
