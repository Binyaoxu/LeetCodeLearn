using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RemoveDuplicatefromSortedArray2
{
    class Program
    {
        static void Main(string[] args)
        {

            var re = WebRequest.Create("http://www.baidu.com/img/baidu_logo.gif");
            var rel = re.GetResponse();

            //int[] nums = { 0,0,0,0,1,1,2,2,2, 2, 2,3, 3 ,4};
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int[] result = RemoveDuplicates1(nums);

            foreach (var num in result)
            {
                Console.Write(num + " ");
            }
        }

        /// <summary>
        ///  扩展性好，重复数出现次数根据需求改就好了，1是1次，2是2次内，3是3次内
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] RemoveDuplicates1(int[] nums)
        {
            if (nums.Length <= 2)
                return nums;

            int index = 2;

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[index - 2])
                {
                    nums[index++] = nums[i];
                }
            }

            nums = nums.Take(index).ToArray();
            Console.WriteLine("Count:{0}", index);
            return nums;
        }
    }
}
