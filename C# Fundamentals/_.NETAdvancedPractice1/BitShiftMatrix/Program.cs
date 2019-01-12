using System;
using System.Numerics;
using System.Linq;

namespace BitShiftMatrix
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());
            int[] lineOfMoves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BigInteger[,] matrix = new BigInteger[n, m];
            BigInteger sum = 0;

            int[] posiion = new int[] { n - 1, 0 };
            int coefficient = Math.Max(n, m);
            FillDiagonalMatrix(n, m, matrix);

            sum += matrix[posiion[0], posiion[1]];
            matrix[posiion[0], posiion[1]] = 0;

            foreach (var code in lineOfMoves)
            {
                int[] nextPosition = { code / coefficient, code % coefficient };
                int stepCol;
                int stepRow;
                if(posiion[1]<nextPosition[1])
                {
                    stepCol = 1;
                }
                else
                {
                    stepCol = -1;
                }
                if (posiion[0] < nextPosition[0])
                {
                    stepRow = 1;
                }
                else
                {
                    stepRow = -1;
                }

                while (posiion[1] != nextPosition[1] && posiion[1] >= 0 && posiion[1] < m)
                {
                    posiion[1] += stepCol;
                    sum += matrix[posiion[0], posiion[1]];
                    matrix[posiion[0], posiion[1]] = 0;
                    
                }
                while (posiion[0] != nextPosition[0] && posiion[0] >=0  && posiion[0]<n )
                {
                    posiion[0] += stepRow;
                    sum += matrix[posiion[0], posiion[1]];
                    matrix[posiion[0], posiion[1]] = 0;
                    
                }


            }
            Console.WriteLine(sum);
        }
        static void FillDiagonalMatrix(int row, int col, BigInteger[,] a)
        {
            int count = 0;
            for (int r = row - 1; r >= 0; r--)
            {
                int currentCount = count;
                for (int c = 0; c < col; c++)
                {
                    a[r, c] = BigInteger.Pow(2, currentCount);
                    currentCount++;
                }
                count++;
            }
        }

       

    }
}
