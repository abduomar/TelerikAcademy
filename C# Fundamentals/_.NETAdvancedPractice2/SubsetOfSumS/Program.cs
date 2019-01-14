using System;
using System.Linq;

namespace SubsetOfSumS
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool[] values = new bool[s+1];
            values[0] = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = values.Length - 1; j >= 0; j--)
                {
                    if (values[j] == true)
                    {
                        if (j + numbers[i] > s)
                        {
                            continue;
                        }
                        else
                        {
                            values[j + numbers[i]] = true;
                        }
                    }
                }
            }
            if(values[s]==true)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
