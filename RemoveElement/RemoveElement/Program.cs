using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveElement
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int removeElement(int[] A, int elem)
        {
            if (A == null || A.Length == 0)
                return 0;

            int len = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != elem)
                {
                    if (A[len] != A[i])
                        A[len] = A[i];
                    len++;
                }
            }
            return len;
        }
    }
}
