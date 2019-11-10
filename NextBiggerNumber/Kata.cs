using System;
using System.Linq;

namespace NextBiggerNumber
{
    public class Kata
    {
        public static int NextBiggerNumber(int number)
        {
            int[] digits = GetAllDigits(number);

            int[] originalDigits = new int[digits.Length];

            digits.CopyTo(originalDigits, 0);

            for (int i = digits.Length -1; i >= 0; i--)
            {
                for (int j = i -1; j >= 0; j--)
                {
                    int currentDigit = digits[i];
                    int predecessorDigit = digits[j];

                    if (currentDigit > predecessorDigit)
                    {
                        digits[i] = predecessorDigit;
                        digits[j] = currentDigit;
                    }
                    else
                    {
                        break;
                    }

                    bool equal = originalDigits.SequenceEqual(digits);

                    if (!equal)
                    {
                        int result = GetNumberFromDigits(digits);
                        return result;
                    }
                }
            }
            return -1;
        }

        private static int GetNumberFromDigits(int[] digits)
        {
            string result = string.Join("",digits);

            return Int32.Parse(result);
        }

        private static int[] GetAllDigits(int number)
        {
            int[] digits = new int[(int)Math.Log10(number) + 1];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[digits.Length - i - 1] = number % 10;
                number /= 10;
            }
            return digits;
        }
    }
}