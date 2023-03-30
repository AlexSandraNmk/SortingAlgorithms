using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public class ArrayValidator<T> where T : IComparable
    {
        private readonly T[] _array;

        /// <summary>
        /// Initializes a new instance of the ArrayValidator class.
        /// </summary>
        /// <param name="array">An array that will be validated.</param>
        public ArrayValidator(T[] array)
        {
            _array = array;
        }

        public bool IsSorted()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i].CompareTo(_array[i + 1]) > 0)
                {
                    return false;
                }
            }

           return true;
        }
    }
}
