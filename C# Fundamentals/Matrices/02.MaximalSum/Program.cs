using System;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();

            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);

            long[,] matrix = new long[n, m];

            long sum = 0;
            long max = int.MinValue;

                for (int row = 0; row < n ; row++)
                {
                    var line = Console.ReadLine();
                    var split = line.Split(' ');
                    for (int col = 0; col < m ; col++)
                    {
                        matrix[row, col] = int.Parse(split[col]);

                    }

                }
            for (int row = 0; row < n-2; row++)
            {
                for (int col = 0; col < m-2; col++)
                {

                    sum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if(sum>=max)
                    {
                        max = sum;
                        sum = 0;
                    }
                    sum = 0;
                }

            }


            Console.WriteLine(max);
        }
    }
}
