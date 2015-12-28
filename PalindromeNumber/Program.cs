using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeNumber
{
    //Determine whether an integer is a palindrome. Do this without extra space.
    class Program
    {
        static void Main(string[] args)
        {
            bool result = isPalindrome(12321);
            Console.WriteLine("123");
            Console.ReadLine();
            Console.ReadLine();
        }

        public static bool isPalindrome(int x)
        {
            if (x < 0)
                return false;
            else if (x == 0)
                return true;

            int div = 1;            
            while (x / 10 >= div)
                div *= 10;

            while (x != 0)
            {
                int last = x % 10;
                int first = x / div;
                if (first != last)
                    return false;

                x = (x % div) / 10;
                div /= 100;
            }

            return true;
        }
    }
}
