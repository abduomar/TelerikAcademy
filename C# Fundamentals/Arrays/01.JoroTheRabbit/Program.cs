using System;
using System.Linq;

namespace JoroTheRabbit
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new char[]{',',' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(MovingIntoTheTerrain(numbers));

        }
        static int MovingIntoTheTerrain(int[] numbers)
        {
            int bestPath = 0;

            for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
            {
                for (int steps = 1; steps < numbers.Length; steps++)
                {
                    int index = startIndex;
                    int currentPath = 1;
                    int next = (index + steps) % numbers.Length;
                    while(numbers[index]<numbers[next])
                    {
                        currentPath++;
                        index = next;
                        next = (index + steps) % numbers.Length;
                    }
                    if(currentPath>bestPath)
                    {
                        bestPath = currentPath;
                    }
                }
            }
            return bestPath;
        }
    }
}
