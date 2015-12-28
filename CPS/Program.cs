using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace CPS
//{
//    public static class CustomerMethod
//    {
//        public static void TestThis(this List<int> list, int num)
//        {
//            foreach (var item in list)
//            {
//                if (num <= 10)
//                {
//                    Console.WriteLine("{0}", item.ToString());
//                }
//            }
//        }
//    }

//    class Tax
//    {
//        public void CreateEntities(List<int> entities)
//        {
//            entities.TestThis(10);
//        }
//    }

//    public static class EnumerableHelpers
//    {
//        public static void AddRange1<T>(this List<T> collection, IEnumerable<T> items)
//        {
//            foreach (var item in items)
//            {
//                collection.Add(item);
//            }
//        }

//        public static string Reverse(this string target)
//        {
//            char[] parts = target.ToCharArray();
//            Array.Reverse(parts);
//            return parts.ToString();
//        }

//        public static string ToString(this string str, string abc)
//        {
//            str +=abc;
//            return str;
//        }

//        public static bool CompareNum(this int num1, int num2)
//        {
//            if (num1 > num2)
//                return true;
//            else
//                return false;
//        }

//        public static bool CompareNum(this string str1, string str2)
//        {
//            return true;
//        }
//    }

//    class MainClass
//    {
//        static void Main()
//        {
//            int num1 = 10;
//            bool result = num1.CompareNum(20);

//            string te = "abc";
//            te.CompareNum("bcd");


//            string reverse = "abcdef";
//            string newstring = reverse.Reverse();
//            string re2 = reverse.ToString("abde");

//            List<int> listn = new List<int>();

//            for (int i = 0; i <= 5; i++)
//            {
//                List<int> list = new List<int>();

//                list.Add(123);
//                list.Add(343);
//                list.Add(2343);

//                listn.AddRange1(list);
//            }

//            Tax tax = new Tax();
//            //tax.CreateEntities(listn);
//        }
//    }
//}

// Define an interface named IMyInterface.
namespace DefineIMyInterface
{
    public interface IMyInterface
    {
        void MethodB();
    }
}

namespace Extensions
{
    using System;
    using DefineIMyInterface;

    public static class Extension
    {
        public static void MethodA(this IMyInterface myInterface, int i)
        {
            Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, int i)");
        }

        public static void MethodA(this IMyInterface myInterface, string s)
        {
            Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, string s)");
        }

        public static void MethodB(this IMyInterface myInterface)
        {
            Console.WriteLine
                ("Extension.MethodB(this IMyInterface myInterface)");
        }
    }
}

namespace ExtensionMethodsDemo1
{
    using System;
    using Extensions;
    using DefineIMyInterface;

    class A : IMyInterface
    {
        public void MethodB()
        {
            Console.WriteLine("A.MethodB()");
        }
    }

    class B : IMyInterface
    {
        public void MethodB()
        {
            Console.WriteLine("B.MethodB()");
        }

        public void MethodA(int i)
        {
            Console.WriteLine("B.MethodA(int i)");
        }
    }

    class C : IMyInterface
    {
        public void MethodB()
        {
            Console.WriteLine("C.MethodB()");
        }
        public void MethodA(object obj)
        {
            Console.WriteLine("C.MethodA(object obj)");
        }
    }

    class ExtMethodDemo
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();

            a.MethodA(1);           // Extension.MethodA(object, int)
            a.MethodA("hello");     // Extension.MethodA(object, string)

            a.MethodB();            // A.MethodB()

            b.MethodA(1);           // B.MethodA(int)
            b.MethodB();            // B.MethodB()

            b.MethodA("hello");     // Extension.MethodA(object, string)

            c.MethodA(1);           // C.MethodA(object)
            c.MethodA("hello");     // C.MethodA(object)
            c.MethodB();            // C.MethodB()
        }
    }
}
/* Output:
    Extension.MethodA(this IMyInterface myInterface, int i)
    Extension.MethodA(this IMyInterface myInterface, string s)
    A.MethodB()
    B.MethodA(int i)
    B.MethodB()
    Extension.MethodA(this IMyInterface myInterface, string s)
    C.MethodA(object obj)
    C.MethodA(object obj)
    C.MethodB()
 */
