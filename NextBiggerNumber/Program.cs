using System;
using NextBiggerNumber;
using NextBiggerNumberBruteForce;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = { 9, 111, 531, 12, 513, 2017, 414, 144, 119451725, 534976, 218765, 59884848459853 };
            //long[] numbers = { 59884848459853 };

            foreach (long number in numbers)
            {
                long bruteForceResult = KataBruteForce.NextBiggerNumber(number);
                Console.WriteLine("Input: " + number + "; Output: " + bruteForceResult + " (Brute Force)");

                long result = Kata.NextBiggerNumber(number);
                Console.WriteLine("Input: " + number + "; Output: " + result);
            }
        }
    }
}
