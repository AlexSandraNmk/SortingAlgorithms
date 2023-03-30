using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Algorithms.Sorting
{
    public class BubbleSort : ISortingAlgorithm
    {
        public void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i = 0)
            {
                bool swapped = false;

                for (int j = 1; j < array.Length; j++, i++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        (array[j], array[i]) = (array[i], array[j]);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
