using System;
using System.Linq;

namespace FirstLargerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(ReturnIndexOfFirstBiggestThanNeighbours(numbers));
        }
        static int ReturnIndexOfFirstBiggestThanNeighbours(int[] numbers)
        {
            int index = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (i > 0)
                {
                    if (numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1])
                    {
                        index = i;
                        break;
                    }
                    else
                    {
                        index = -1;
                    }
                }
            }
            return index;
        }
    }
}
