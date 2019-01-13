using System;
using System.Linq;

namespace AddingPolynomials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("  ");
            int n = int.Parse(Console.ReadLine());
            int[] firstPolynomial = new int[n];
            int[] secondPolynomial = new int[n];

            firstPolynomial = Console.ReadLine().Split().Select(int.Parse).ToArray();
            secondPolynomial = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(" ",SumTwoPolynomials(firstPolynomial, secondPolynomial)));
        }

        static int[] SumTwoPolynomials(int[] a,int[] b)
        {
            int[] sum = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                sum[i] = a[i] + b[i];
            }
            return sum;
        }
    }
}
