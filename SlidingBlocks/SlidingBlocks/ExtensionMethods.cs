using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlidingBlocks
{
    public static class ExtensionMethods
    {
        public static Tuple<int, int> CoordinatesOf(this int[,] matrix, int value)
        {
            int rows = matrix.GetLength(0);
            //Console.WriteLine(rows);
            int cols = matrix.GetLength(1);
            //Console.WriteLine(cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j].Equals(value))
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return Tuple.Create(-1, -1);
        }

        public static int[] Swap(this int[] state, int idx1, int idx2)
        {
            int temp = state[idx1];
            state[idx1] = state[idx2];
            state[idx2] = temp;
            return state;
        }
    }
}
