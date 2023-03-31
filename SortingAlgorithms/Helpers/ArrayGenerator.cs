using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public static class ArrayGenerator
    {
        public static int[] GenerateRandomArray(int sizeOfArray)
        {
            int[] array = new int[sizeOfArray];
            Random random = new Random();
            int maxNumber = 1000;

            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = random.Next(maxNumber + 1);
            }

            return array;
        }

        public static int[] GenerateSortedArray(int sizeOfArray)
        {
            int[] array = new int[sizeOfArray];

            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
