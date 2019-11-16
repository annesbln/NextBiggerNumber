using System;
using System.Linq;

namespace NextBiggerNumber
{
    public class Kata
    {
        public static long NextBiggerNumber(long number)
        {
            long[] digits = GetAllDigits(number);

            long[] originalDigits = new long[digits.Length];

            digits.CopyTo(originalDigits, 0);

            for (int i = digits.Length -1; i >= 0; i--)
            {
                for (int j = i -1; j >= 0; j--)
                {
                    long currentDigit = digits[i];
                    long predecessorDigit = digits[j];

                    if (currentDigit > predecessorDigit)
                    {
                        digits[i] = predecessorDigit;
                        digits[j] = currentDigit;

                        long[] firstDigits = digits.Take(j + 1).ToArray();
                        long[] lastDigits = digits.Skip(j + 1).Take(digits.Length - 1).ToArray();
                        Array.Sort(lastDigits);

                        long[] result = firstDigits.Concat(lastDigits).ToArray();

                        return GetNumberFromDigits(result);
                    }
                    if (currentDigit == predecessorDigit && digits.Max() != currentDigit)
                    {
                        long[] firstDigits = digits.Take(j + 1).ToArray();
                        long[] lastDigits = digits.Skip(j + 1).Take(digits.Length - 1).ToArray();

                        long nextMaxValue = getNextMaxValue(currentDigit, lastDigits);
                        long[] maxValueArray = new long[] { nextMaxValue };
                        int maxIndex = lastDigits.ToList().IndexOf(maxValueArray[0]);

                        firstDigits[firstDigits.Length - 1] = maxValueArray[0];
                        lastDigits[maxIndex] = predecessorDigit;

                        Array.Reverse(lastDigits);

                        long[] result = firstDigits.Concat(lastDigits).ToArray();

                        return GetNumberFromDigits(result);
                    }
                }
            }
            return -1;
        }

        private static long getNextMaxValue(long digit, long[] digits)
        {
            long result = long.MaxValue;

            foreach(long number in digits)
            {
                if (number > digit && number < result)
                {
                    result = number;
                }
            }
            return result;
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
    }
}