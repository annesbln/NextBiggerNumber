using System;
using System.Linq;

namespace NextBiggerNumber
{
    public class Kata
    {
        public static long NextBiggerNumber(long number)
        {
            long[] digits = GetAllDigits(number);

            for (int i = digits.Length -1; i >= 1; i--)
            {
                long currentDigit = digits[i];
                long predecessorDigit = digits[i-1];

                if (currentDigit > predecessorDigit)
                {
                    long[] firstDigits = digits.Take(i).ToArray();
                    long[] lastDigits = digits.Skip(i).Take(digits.Length - 1).ToArray();

                    long nextMaxValue = GetNextMaxValue(predecessorDigit, lastDigits);

                    int maxIndex = lastDigits.ToList().LastIndexOf(nextMaxValue);

                    firstDigits[firstDigits.Length - 1] = nextMaxValue;
                    lastDigits[maxIndex] = predecessorDigit;

                    Array.Reverse(lastDigits);

                    long[] result = firstDigits.Concat(lastDigits).ToArray();

                    return GetNumberFromDigits(result);
                }
            }
            return -1;
        }

        private static long GetNumberFromDigits(long[] digits)
        {
            string result = string.Join("",digits);

            return Int64.Parse(result);
        }

        private static long[] GetAllDigits(long number)
        {
            long[] digits = new long[(int)Math.Log10(number) + 1];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[digits.Length - i - 1] = number % 10;
                number /= 10;
            }
            return digits;
        }
        private static long GetNextMaxValue(long digit, long[] digits)
        {
            long result = long.MaxValue;

            foreach (long number in digits)
            {
                if (number > digit && number < result)
                {
                    result = number;
                }
            }
            if (result.Equals(long.MaxValue))
            {
                return digit;
            }
            else
            {
                return result;
            }
        }
    }
}