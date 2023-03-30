using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public class ArrayGenerator
    {
        private readonly int _sizeOfArray;

        /// <summary>
        /// Initializes a new instance of the ArrayGenerator class.
        /// </summary>
        /// <param name="sizeOfArray">Size of an arrays that will be created by this instance.</param>
        public ArrayGenerator(int sizeOfArray)
        {
            _sizeOfArray = sizeOfArray;
        }

        public int[] GenerateRandomArray()
        {
            int[] array = new int[_sizeOfArray];
            Random random = new Random();
            int maxNumber = 1000;

            for (int i = 0; i < _sizeOfArray; i++)
            {
                array[i] = random.Next(maxNumber + 1);
            }

            return array;
        }

        public int[] GenerateSortedArray()
        {
            int[] array = new int[_sizeOfArray];

            for (int i = 0; i < _sizeOfArray; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
