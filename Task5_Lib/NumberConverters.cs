using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_Lib
{
    public static class NumberConverters
    {
        private static readonly Dictionary<int, string> dozens =
            new Dictionary<int, string>()
            {
                {2, "twenty" },
                {3, "thirty" },
                {4, "forty" },
                {5, "fifty" },
                {6, "sixty" },
                {7, "seventy" },
                {8, "eighty" },
                {9, "ninety" }
            };
        private static readonly Dictionary<int, string> units =
            new Dictionary<int, string>()
            {
                {0, "zero" },
                {1, "one" },
                {2, "two" },
                {3, "three" },
                {4, "four" },
                {5, "five" },
                {6, "six" },
                {7, "seven" },
                {8, "eight" },
                {9, "nine" },
                {10, "ten" },
                {11, "eleven" },
                {12, "twelve" },
                {13, "thirteen" },
                {14, "fourteen" },
                {15, "fifteen" },
                {16, "sixteen" },
                {17, "seventeen" },
                {18, "eighteen" },
                {19, "nineteen" }
            };
        private static readonly Dictionary<int, string> keywords =
            new Dictionary<int, string>()
            {
                {0,string.Empty },
                {1,"thousand" },
                {2,"million" }
            };
        private static string IntPartToString(int n)
        {
            if (n < 0 || n > 999)
            {
                throw new ArgumentOutOfRangeException();
            }

            string answer = "";

            if (n != 0)
            {
                int hundreds_count = n / 100;
                int dozens_count = n % 100 / 10;
                int units_count = n % 10;
                if (hundreds_count > 0)
                {
                    answer += units[hundreds_count] + " hundred";
                }

                if (n % 100 >= 1 && n % 100 <= 19)
                {
                    answer += " " + units[n % 100];
                }
                else if (dozens_count > 1)
                {
                    if (answer.Length != 0)
                    {
                        answer += " ";
                    }

                    answer += dozens[dozens_count];
                    if (units_count != 0)
                    {
                        answer += " " + units[units_count];
                    }
                }
            }
            return answer.Trim();
        }

        public static string IntToString(int n)
        {
            StringBuilder answer = new StringBuilder(100);
            if (n == 0)
            {
                answer.Append("zero");
            }
            else if (n > 999999999 || n < -999999999)
            {
                throw new ArgumentOutOfRangeException();
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
                    answer.Insert(0,$"{IntPartToString(temp)} {keywords[i]} ");
                }
            }
            if(minusAppending)
            {
                answer.Insert(0, $"minus ");
            }
            return answer.ToString().Trim();
        }
    }
}
