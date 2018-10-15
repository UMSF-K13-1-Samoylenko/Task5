// <copyright file="NumberConverters.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task5_Lib
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class with methods for converting numbers to string view
    /// </summary>
    public static class NumberConverters
    {
        /// <summary>
        /// Dictionary with dozens
        /// </summary>
        private static readonly Dictionary<int, string> Dozens =
            new Dictionary<int, string>()
            {
                { 2, "twenty" },
                { 3, "thirty" },
                { 4, "forty" },
                { 5, "fifty" },
                { 6, "sixty" },
                { 7, "seventy" },
                { 8, "eighty" },
                { 9, "ninety" }
            };

        /// <summary>
        /// Dictionary with units
        /// </summary>
        private static readonly Dictionary<int, string> Units =
            new Dictionary<int, string>()
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" },
                { 13, "thirteen" },
                { 14, "fourteen" },
                { 15, "fifteen" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eighteen" },
                { 19, "nineteen" }
            };

        /// <summary>
        /// Dictionary with unique keywords like thousand, million etc
        /// </summary>
        private static readonly Dictionary<int, string> Keywords =
            new Dictionary<int, string>()
            {
                { 0, string.Empty },
                { 1, "thousand" },
                { 2, "million" }
            };

        /// <summary>
        /// Method for converting integer value to its string view
        /// </summary>
        /// <param name="n">Value to converting</param>
        /// <returns>String view of n</returns>
        public static string IntToString(int n)
        {
            StringBuilder answer = new StringBuilder(100);
            if (n == 0)
            {
                answer.Append("zero");
            }
            else if (n > 999999999 || n < -999999999)
            {
                throw new ArgumentOutOfRangeException("Please use value between -999999999 and 999999999");
            }

            bool minusAppending = false;
            if (n < 0)
            {
                n *= -1;
                minusAppending = true;
            }

            for (int i = 0; n != 0; ++i)
            {
                int temp = n % 1000;
                n /= 1000;
                if (temp != 0)
                {
                    answer.Insert(0, $"{IntPartToString(temp)} {Keywords[i]} ");
                }
            }

            if (minusAppending)
            {
                answer.Insert(0, $"minus ");
            }

            return answer.ToString().Trim();
        }

        /// <summary>
        /// Method for converting part of big value to string
        /// </summary>
        /// <param name="n">Integer value from 0 to 999</param>
        /// <returns>String view of n</returns>
        private static string IntPartToString(int n)
        {
            if (n < 0 || n > 999)
            {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder answer = new StringBuilder(string.Empty);

            if (n != 0)
            {
                int hundreds_count = n / 100;
                int dozens_count = (n % 100) / 10;
                int units_count = n % 10;
                if (hundreds_count > 0)
                {
                    answer.Append($"{Units[hundreds_count]} hundred");
                }

                if (n % 100 >= 1 && n % 100 <= 19)
                {
                    answer.Append($" {Units[n % 100]}");
                }
                else if (dozens_count > 1)
                {
                    if (answer.Length != 0)
                    {
                        answer.Append($" ");
                    }

                    answer.Append(Dozens[dozens_count]);
                    if (units_count != 0)
                    {
                        answer.Append($" {Units[units_count]}");
                    }
                }
            }

            return answer.ToString().Trim();
        }
    }
}
