﻿using System;

namespace TribonacciTriangle
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            Console.WriteLine(firstNumber);
            Console.WriteLine("{0} {1}", secondNumber, thirdNumber);
            if(lines>2)
            {
                for (int i = 3; i <= lines; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        int resultNumber = firstNumber + secondNumber + thirdNumber;
                        firstNumber = secondNumber;
                        secondNumber = thirdNumber;
                        thirdNumber = resultNumber;
                        Console.Write(resultNumber + " ");
                    }
                    Console.WriteLine();
                }
              
            }
        }       
    }
}
