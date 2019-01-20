using System;
using System.Linq;
using System.Text;

namespace BitConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            string[] binaryNumbers = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                string currentBinary = Convert.ToString(currentNumber, 2).PadLeft(8, '0');
                binaryNumbers[i] = currentBinary;
            }
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < binaryNumbers.Length; i++)
            {
                string currentBinary = binaryNumbers[i];
                if(i%2==0)
                {
                    for (int j = 1; j < binaryNumbers[i].Length; j+=2)
                    {
                        char currentBinaryDigit = currentBinary[j];
                        result.Append(currentBinaryDigit);
                    }
                }
                if (i % 2 == 1)
                {
                    for (int j = 0; j < binaryNumbers[i].Length; j += 2)
                    {
                        char currentBinaryDigit = currentBinary[j];
                        result.Append(currentBinaryDigit);
                    }
                }
            }
            Console.WriteLine(result.ToString());
            
        }
    }
}
