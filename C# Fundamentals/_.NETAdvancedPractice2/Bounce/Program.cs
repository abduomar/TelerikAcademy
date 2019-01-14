using System;
using System.Numerics;

namespace Bounce
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            BigInteger[,] matrix = new BigInteger[n, m];
            BigInteger sum = 0;
            FillMatrix(n, m, matrix);

            if(Math.Min(n,m)>1)
            {
                for (int rows = 0; rows < n; rows++)
                {
                    if(rows%2==0)
                    {
                        for (int cols = 0; cols < m; cols+=2)
                        {
                            if((rows>0 && rows<n-1) &&(cols>0 && cols<m-1))
                            {
                                sum += matrix[rows, cols] * 2;
                            }
                            else
                            {
                                sum += matrix[rows, cols];
                            }
                        }
                    }
                    else if(rows%2==1)
                    {
                        for (int cols = 1; cols < m; cols += 2)
                        {
                            if ((rows > 0 && rows < n - 1) && (cols > 0 && cols < m - 1))
                            {
                                sum += matrix[rows, cols] * 2;
                            }
                            else
                            {
                                sum += matrix[rows, cols];
                            }
                        }
                    }
                }
                Console.WriteLine(sum);
            }  
            else if(n==m)
            {
                for (int i = 0; i < n; i++)
                {
                    sum += matrix[i, i];
                }
                Console.WriteLine(sum);
            }
            else if(Math.Min(n,m)==1)
            {
                sum = 1;
                Console.WriteLine(sum);
            }

            
        }
        static void FillMatrix(int row, int col, BigInteger[,] matrix)
        {
            int count = 0;
            for (int rows = 0; rows < row; rows++)
            {
                int currentCount = count;
                for (int cols = 0; cols < col; cols++)
                {
                    matrix[rows, cols] = BigInteger.Pow(2, currentCount);
                    currentCount++;
                }
                count++;
            }
        }
    }
}

