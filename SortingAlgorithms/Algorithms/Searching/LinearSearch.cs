using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Algorithms.Searching
{
    class LinearSearch : ISearchingAlgorithm
    {
        public void Search(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    Console.WriteLine($"Number {number} was found at index {i}");
                    return;
                }
            }

            Console.WriteLine($"Number {number} was not found");
        }
    }
}
