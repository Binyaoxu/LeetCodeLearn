using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(Add(5, 6));

            Add(5, 6, (ret) => Print(ret));
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static void Print(int result)
        {
            Console.WriteLine("Result:{0}", result);
        }


        public static void Add(int a, int b, Action<int> continueWith)
        {
            continueWith(a + b);
        }
    }
}
