using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatefromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] stringArray = { "aaa", "bbb", "aaa", "ccc", "bbb", "ddd", "ccc", "aaa", "bbb", "ddd" };
            int[] nums = { 1, 2, 2, 2, 3, 3, 3, 4, 4, 5 };

            int[] result1 = RemoveDuplicates1(nums);
            int[] result2 = RemoveDuplicates2(nums);
            int result3 = RemoveDuplicates3(nums);

            foreach (var num in result1)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            foreach (var num in result2)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.WriteLine(result3);
            foreach (var num in nums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 容易理解，直接判断List里面是否包含重复的数字，不包含就直接插入到List里面！
        /// 使用场景：对于数组比较小的情况下使用，去重比较快！
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] RemoveDuplicates1(int[] nums)
        {
            //return nums.GroupBy(p => p).Select(p => p.Key).ToArray();

            List<int> listString = new List<int>();
            //Array.Sort(nums);

            foreach (int num in nums)
            {
                if (!listString.Contains(num))
                    listString.Add(num);
            }

            return listString.ToArray();
        }

        /// <summary>
        /// 把数组中第一个元素插入List，然后进行相临的：i和ｉ－１两两比较，不相等就直接插入到List里面！
        /// 使用场景：对于大数据量，比如上万的数组，那么这样是非常快的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 0)
                return null;

            List<int> listString = new List<int>();
            //Array.Sort(nums);

            listString.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    listString.Add(nums[i]);
                }
            }

            return listString.ToArray();
        }

        /// <summary>
        /// 从第一位开始设置索引index,从第二位开始与第一位进行比较,如果不相等,那么就把值赋给++index，然后继续以index为索引进行比较,不相等就把值赋给++index
        /// 使用场景：在不改变原数组长度，并且不开辟新数组的情况下可以使用！需要返回index+1来获得具体有多少个不重复的数字，然后到原数组里面去取        
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates3(int[] nums)
        {
            int index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[index] != nums[i])
                    nums[++index] = nums[i];
            }

            return index + 1;
        }
    }
}
