using System;
using System.Threading;
namespace DeadLock
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Thread t1 = new Thread(t.test1);
            Thread t2 = new Thread(t.test2);

            t1.Start();
            t2.Start();

            Console.ReadLine();

        }
    }

    public class Test
    {
        private object resource1 = new object();
        private object resource2 = new object();

        public void test1()
        {
               
            Console.WriteLine(string.Format("test1:Thread{0} try to get resouce1", Thread.CurrentThread.ManagedThreadId.ToString()));
            lock(resource1)
            {
                Console.WriteLine(string.Format("test1:Thread{0} got resouce1", Thread.CurrentThread.ManagedThreadId.ToString()));
                Thread.Sleep(2000);
                Console.WriteLine(string.Format("test1:Thread{0} try to get resouce2", Thread.CurrentThread.ManagedThreadId.ToString()));
                
                lock (resource2)
                {
                    Console.WriteLine(string.Format("test1:Thread{0} got resouce2", Thread.CurrentThread.ManagedThreadId.ToString()));
                }
            }
        }

        public void test2()
        {
            Console.WriteLine(string.Format("test2:Thread{0} try to get resouce2", Thread.CurrentThread.ManagedThreadId.ToString()));
            lock (resource2)
            {
                Console.WriteLine(string.Format("test2:Thread{0} got resouce2", Thread.CurrentThread.ManagedThreadId.ToString()));
                Thread.Sleep(500);
                Console.WriteLine(string.Format("test2:Thread{0} try to get resouce1", Thread.CurrentThread.ManagedThreadId.ToString()));
                lock (resource1)
                {
                    Console.WriteLine(string.Format("test2:Thread{0} got resouce1", Thread.CurrentThread.ManagedThreadId.ToString()));
                }
            }
        }
    }
}
