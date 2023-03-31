using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Interfaces
{
    public interface IArrayValidator
    {
        /// <summary>
        /// Method checks if the given array is sorted or not.
        /// </summary>
        /// <param name="arr">An array that will be checked.</param>
        /// <returns>True if the array is sorted, otherwise returns false.</returns>
        public bool IsSorted<T>(T[] arr) where T : IComparable;
    }
}
