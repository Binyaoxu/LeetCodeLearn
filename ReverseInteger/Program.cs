using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ReverseInteger
{
    class Program
    {
        /*Reverse digits of an integer.
            Example1: x = 123, return 321
            Example2: x = -123, return -321
            Discuss: 1.If the integer's last digit is 0, what should the output be? ie, cases such as 10, 100.
 　　　　             2.Reversed integer overflow.*/
        static void Main(string[] args)
        {
            //"-2147483648","2147483647",           
            //int x = 2147483647;
            int y = Reverse(100);
        }

        public static int Reverse(int x)
        {
            int result = 0;
            while (x != 0)
            {
                if (result * 10 / 10 != result)
                    return 0;

                //if (result > int.MaxValue / 10)
                //    return 0;
                //if (result < int.MinValue / 10)
                //    return 0;
                result = result * 10 + x % 10;
                x /= 10;
            }

            return result;
        }
    }
}
