using System;
using System.Collections.Generic;

namespace NextBiggerNumberBruteForce
{
    public class KataBruteForce
    {
        public static long NextBiggerNumber(long n)
        {
            long[] digits = GetAllDigits(n);

            SortedDictionary<long, int> digitCounts = CountUniqueDigits(digits);

            long resultNumber = n;

            long maximalValue = GetMaximalValue(digits);

            for (long i = 0; i <= maximalValue; i++)
            {
                resultNumber++;

                long[] comparableDigits = GetAllDigits(resultNumber);

                SortedDictionary<long, int> comparableDigitCounts = CountUniqueDigits(comparableDigits);

                bool equal = CompareDigitCounts(digitCounts, comparableDigitCounts);

                if (equal)
                {
                    return resultNumber;
                }

            }
            return -1;
        }

        private static long GetMaximalValue(long[] digits)
        {
            long[] copyDigits = new long[digits.Length];

            digits.CopyTo(copyDigits, 0);

            Array.Reverse(copyDigits);

            return Convert.ToInt64(string.Join("", copyDigits));
        }

        private static bool CompareDigitCounts(SortedDictionary<long, int> digitCounts, SortedDictionary<long, int> comparableDigitCounts)
        {
            bool equal = false;
            if (digitCounts.Count == comparableDigitCounts.Count)
            {
                equal = true;

                foreach (var digit in digitCounts)
                {
                    if (comparableDigitCounts.TryGetValue(digit.Key, out int count))
                    {
                        if (count != digit.Value)
                        {
                            equal = false;
                            break;
                        }
                    }
                    else
                    {
                        equal = false;
                        break;
                    }
                }
            }
            else
            {
                return equal;
            }
            return equal;
        }

        private static SortedDictionary<long, int> CountUniqueDigits(long[] digits)
        {
            SortedDictionary<long, int> digitCounts = new SortedDictionary<long, int>();

            foreach (long digit in digits)
            {
                if (digitCounts.ContainsKey(digit))
                {
                    digitCounts[digit] = digitCounts[digit] + 1;
                }
                else
                {
                    digitCounts.Add(digit, 1);
                }
            }
            return digitCounts;
        }

        public static long[] GetAllDigits(long n)
        {
            long[] digits = new long[(int)Math.Log10(n) + 1];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[digits.Length - i - 1] = n % 10;
                n /= 10;
            }
            return digits;
        }
    }
}