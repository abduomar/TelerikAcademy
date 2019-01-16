using System;
using System.Numerics;

namespace HorsePath
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger[,] matrix = new BigInteger[n, n];
            int[] dRows = { -2, -2, -1, -1, +1,+1, +2, +2 };
            int[] dCols = { -1, +1, -2, +2, -2, +2, -1, +1 };
            FillTheMatrix(n, matrix, dRows, dCols);
            PrintTheMatrix(n, matrix);
        }
        static void FillTheMatrix(int n,BigInteger[,] matrix,int[]dRows, int[] dCols)
        {
            int counter = 1;
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {  
                    int r = rows;
                    int c = cols;
                    while (matrix[r,c]==0)
                    {
                        matrix[r, c] = counter;
                        counter++;
                        for (int direction = 0; direction < dRows.Length; direction++)
                        {
                            int nextRow = r + dRows[direction];
                            int nextCol = c + dCols[direction];
                            if(nextRow<0 || nextRow>n-1 ||nextCol<0 || nextCol>n-1)
                            {
                                continue;
                            }
                            if(matrix[nextRow,nextCol]!=0)
                            {
                                continue;
                            }
                            r = nextRow;
                            c = nextCol;
                            break;

                        }
                    }
                }
            }
        }
        static void PrintTheMatrix(int n,BigInteger[,] matrix)
        {
            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
