// <copyright file="NumberConverters.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task5_Lib
{
    using System;
    using System.Text;

    /// <summary>
    /// Class with number converters methods
    /// </summary>
    public static class NumberConverters
    {
        /// <summary>
        /// String values of all dozens
        /// </summary>
        private static readonly string[] Dozens =
        {
            string.Empty,
            string.Empty,
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };
        
        /// <summary>
        /// String values of all units
        /// </summary>
        private static readonly string[] Units =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        /// <summary>
        /// Converts number to string
        /// </summary>
        /// <param name="n">Value to convert</param>
        /// <returns>Converted string</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws when n value is less -999999999 or bigger than 999999999</exception>
        public static string IntToString(int n)
        {
            StringBuilder answer = new StringBuilder(100);
            if (n == 0)
            {
                answer.Append(Units[0]);
            }
            else if (n > 999999999 || n < -999999999)
            {
                throw new ArgumentOutOfRangeException();
            }

            bool wasAppendMade = false;

            if (n < 0)
            {
                n *= -1;
                answer.Append("minus");
                wasAppendMade = true;
            }

            int millions = n / 1000000;
            n -= millions * 1000000;
            int thousands = n / 1000;
            n -= thousands * 1000;
            int hundreds = n;
           
            if (millions != 0)
            {
                if (wasAppendMade)
                {
                    answer.Append(" ");
                }

                answer.Append(IntPartToString(millions).Trim() + " million");
                wasAppendMade = true;
            }

            if (thousands != 0)
            {
                if (wasAppendMade)
                {
                    answer.Append(" ");
                }

                answer.Append(IntPartToString(thousands).Trim() + " thousand");
                wasAppendMade = true;
            }

            if (hundreds != 0)
            {
                if (wasAppendMade)
                {
                    answer.Append(" ");
                }

                answer.Append(IntPartToString(hundreds).Trim());
            }

            return answer.ToString();
        }

        /// <summary>
        /// Converts a part of a number to a string
        /// </summary>
        /// <param name="n">Number to convert 1-999</param>
        /// <returns>Converted a part of a number</returns>
        private static string IntPartToString(int n)
        {
            StringBuilder answer = new StringBuilder(100);

            if (n != 0)
            {
                int hundreds_count = n / 100;
                int dozens_count = (n % 100) / 10;
                int units_count = n % 10;
                if (hundreds_count > 0)
                {
                    answer.Append(Units[hundreds_count] + " hundred");
                }

                if (n % 100 >= 1 && n % 100 <= 19)
                {
                    answer.Append(" " + Units[n % 100]);
                }
                else if (dozens_count > 1)
                {
                    if (answer.Length != 0)
                    {
                        answer.Append(" ");
                    }

                    answer.Append(Dozens[dozens_count]);
                    if (units_count != 0)
                    {
                        answer.Append(" " + Units[units_count]);
                    }
                }
            }

            return answer.ToString().Trim();
        }
    }
}
