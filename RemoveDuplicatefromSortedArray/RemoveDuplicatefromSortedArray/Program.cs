using System;
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
            int[] nums = { 1,2,3,4 };
            int result = RemoveDuplicates(nums);
        }
  
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            List<int> list = new List<int>();

            int index = 0;
            list.Add(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[index] != nums[i])
                {
                    list.Add(nums[i]);
                        ++index;
                    //nums[++index] = nums[i];
                    //nums[i] = 0;
                }               
            }

            nums = list.ToArray();

            return index + 1;
        }
    }
}
