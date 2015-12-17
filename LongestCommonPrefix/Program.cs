using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str1 = { "1234", "1256", "1278" };
            string result = LongestCommonPrefix(str1);
        }
        public static string LongestCommonPrefix(string[] strs)
        {
            string res = "";
            if (strs == null || strs.Length == 0)
            {
                return res;
            }

            int firStrLen = strs[0].Length;
            for (int i = 0; i < firStrLen; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j].Length == i || strs[j][i] != strs[0][i])
                    {
                        return res;
                    }
                }

                res = res + (strs[0][i]);
            }

            return res;
        }
    }
}
