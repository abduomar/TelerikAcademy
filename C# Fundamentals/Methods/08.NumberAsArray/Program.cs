using System;
using System.Linq;

namespace NumberAsArray
{
    class Program
    {
        static void Main()
        {
            string[] numbers =Console.ReadLine().Split();

            int n = int.Parse(numbers[0]);
            int m = int.Parse(numbers[1]);

            int[] nNumbers = new int[n];
            int[] mNumbers = new int[m];

            nNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            mNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(SumTwoArrays(nNumbers, mNumbers));
        }
        static string SumTwoArrays(int[]n,int[]m)
        {
            int longestArray = Math.Max(n.Length, m.Length);
            int[] sumOfTwoArrays = new int[longestArray];
            string result = string.Empty;
            for (int i = 0; i < longestArray; i++)
            {
                if(n.Length>=m.Length)
                {
                    if(i>m.Length-1)
                    {
                        sumOfTwoArrays[i] = n[n.Length - 1];
                        result += sumOfTwoArrays[i].ToString();
                    }
                    else
                    {
                        sumOfTwoArrays[i] += n[i] + m[i];

                        if (sumOfTwoArrays[i] >= 10)
                        {
                            sumOfTwoArrays[i] %= 10;
                            sumOfTwoArrays[i + 1] += 1;
                        }
                        result += sumOfTwoArrays[i].ToString() + " ";
                    }
                }
                if (m.Length > n.Length)
                {
                    if (i >n.Length-1)
                    {
                        sumOfTwoArrays[i] = m[m.Length - 1];
                        result += sumOfTwoArrays[i].ToString();
                    }
                    else
                    {
                        sumOfTwoArrays[i] += m[i] + n[i];
                        if(sumOfTwoArrays[i]>=10)
                        {
                            sumOfTwoArrays[i] %= 10;
                            sumOfTwoArrays[i + 1] += 1;
                        }
                        result += sumOfTwoArrays[i].ToString() + " ";
                    }
                }
            }
            return result;
        }
        
    }
}
