using System;
using System.Linq;

namespace IntegerCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(MinimumOfNumbers(numbers));
            Console.WriteLine(MaximumOfNumbers(numbers));
            Console.WriteLine("{0:F2}",AverageOfNumbers(numbers));
            Console.WriteLine(SumOfNumbers(numbers));
            Console.WriteLine(ProductOfNumbers(numbers));

        }
        static int MinimumOfNumbers(int[] numbers)
        {
            int minimum = int.MaxValue;
            foreach (var item in numbers)
            {
                if (item < minimum)
                {
                    minimum = item;
                }
            }
            return minimum;
        }
        static int MaximumOfNumbers(int[] numbers)
        {
            int maximum = int.MinValue;
            foreach (var item in numbers)
            {
                if (item > maximum)
                {
                    maximum = item;
                }
            }
            return maximum;
        }
        static double AverageOfNumbers(int[] numbers)
        {
            double average = 0;
            double sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }
            average = sum / numbers.Length;
            return average;
        }
        static int SumOfNumbers(int[] numbers)
        {
            int sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }
            return sum;
        }
        static int ProductOfNumbers(int[] numbers)
        {
            int product = 1;
            foreach (var item in numbers)
            {
                product *= item;
            }
            return product;
        }
        
    }
}
