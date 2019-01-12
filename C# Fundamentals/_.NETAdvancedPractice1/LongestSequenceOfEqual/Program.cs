using System;

namespace LongestSequenceOfEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            int counter = 1;
            int max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    if (counter > max)
                    {
                        max = counter;
                    }
                }
                else
                {
                    counter = 1;
                }
            }
            Console.WriteLine(max);
        }
    }
}
