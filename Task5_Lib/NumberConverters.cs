using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Lib
{
    public static class NumberConverters
    {
        private static readonly string[] dozens =
            { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static readonly string[] units =
            { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
                "ten", "eleven", "twelve", "thirteen", "fourteen","fifteen",
                "sixteen","seventeen","eighteen","nineteen"};

        private static string[] Dozens { get => dozens; }
        private static string[] Units { get => units; }
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
                    answer += Units[hundreds_count] + " hundred";
                }

                if (n % 100 >= 1 && n % 100 <= 19)
                {
                    answer += " " + Units[n % 100];
                }
                else if (dozens_count > 1)
                {
                    if (answer.Length != 0)
                    {
                        answer += " ";
                    }

                    answer += Dozens[dozens_count];
                    if (units_count != 0)
                    {
                        answer += " " + Units[units_count];
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
            if (n > 999999999 || n < -999999999)
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

            if(thousands != 0)
            {
                if(wasAppendMade)
                {
                    answer.Append(" ");
                }
                answer.Append(IntPartToString(thousands).Trim() + " thousand");
                wasAppendMade = true;
            }

            if(hundreds != 0)
            {
                if (wasAppendMade)
                {
                    answer.Append(" ");
                }
                answer.Append(IntPartToString(hundreds).Trim());
            }

            return answer.ToString();
        }
    }
}
