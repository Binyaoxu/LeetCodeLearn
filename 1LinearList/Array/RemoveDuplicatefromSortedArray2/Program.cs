using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatefromSortedArray2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 2, 2, 3 };
            int result = RemoveDuplicates1(nums);
        }

        public static int RemoveDuplicates1(int[] nums)
        {            
            if (nums.Length <= 2)
                return nums.Length ;

            List<int> list = new List<int>();
            int index = 2;
            list.Add(nums[0]);

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] != nums[index - 2])
                {
                    list.Add(nums[i]);

                    //nums[index++] = nums[i];
                }
            }

            nums = list.ToArray();

            return index;
        }
    }
}
