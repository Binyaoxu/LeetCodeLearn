using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://www.cnblogs.com/binyao/p/5026406.html

namespace StringtoInteger
{
    //Implement atoi to convert a string to an integer
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = { string.Empty,null,""," ",
                            "0","1","123","000","001","-1","-001",
                            " 123","123 123","123 ",
                            " -123", " +123",
                            "-123", "+123","--123","++123","  -004500",
                            "*123","*abc","~123","123~",
                            "a123","12a3",
                            "12+3","12-3",
                            "-2147483648","2147483647",
                            "-214748364800","214748364700" };
            StringtoInteger(str);
        }

        public static void StringtoInteger(string[] str)
        {
            string a = "-2147483648";
            StringtoInteger1(a);
            Console.WriteLine("StringtoInteger Result is:");
            foreach (string s in str)
            {
                Console.Write("Test Data:{0}", s);
                Console.WriteLine("  Result:{0}", StringtoInteger1(s));
            }
        }

        public static int StringtoInteger1(string str)
        {
            bool sign = false;
            int i = 0;
            int result = 0;

            if (string.IsNullOrWhiteSpace(str))
            {
                return result;
            }

            string strnew = str.Trim();
            //while (str[i] == ' ')
            //    i++;

            if (strnew[i] == '+')
            {
                i++;
            }
            else if (strnew[i] == '-')
            {
                sign = true;
                i++;
            }

            while (i < strnew.Length && (strnew[i] >= '0' && strnew[i] <= '9'))
            {
                //if (result > int.MaxValue / 10)  input "2147483648" wrong answer  
                //expect =2147483647  actual= -2147483648
                //input 2147483649 will failure
                if (result > (int.MaxValue - (strnew[i] - '0')) / 10)
                {
                    return (sign ? int.MinValue : int.MaxValue);
                }

                result = result * 10 + strnew[i] - '0';
                i++;
            }

            return (sign ? -result : result);
        }

        public static int StringtoInteger2(string str)
        {
            int sign = 0;
            int i = 0;
            int result = 0;

            if (string.IsNullOrEmpty(str))
            {
                return result;
            }

            while (i < str.Length && ((str[i] >= '0' && str[i] <= '9') || str[i] == ' ' || str[i] == '-' || str[i] == '+'))
            {
                if (str[i] == ' ' && (result == 0 && sign == 0))
                {
                    i++;
                }
                else if (str[i] == '+' && (result == 0 && sign == 0))
                {
                    sign = 1;
                    i++;
                }
                else if (str[i] == '-' && (result == 0 && sign == 0))
                {
                    sign = -1;
                    i++;
                }
                else if (str[i] >= '0' && str[i] <= '9')
                {
                    if (result > (int.MaxValue - (str[i] - '0')) / 10)
                    {
                        if (sign == 0 || sign == 1)
                            return int.MaxValue;
                        return int.MinValue;
                    }

                    result = result * 10 + str[i] - '0';
                    i++;
                }
                else
                {
                    if (sign == 0)
                        return result;
                    return result * sign;
                }
            }

            if (sign == 0)
                return result;
            return result * sign;
        }
    }
}

