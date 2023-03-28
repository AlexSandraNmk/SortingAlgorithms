using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public static class ArrayGenerator
    {
        public static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            int maxNumber = 1000;

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(maxNumber + 1);
            }

            return array;
        }

        public static int[] GenerateSortedArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
