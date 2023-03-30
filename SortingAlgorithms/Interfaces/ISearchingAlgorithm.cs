using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Interfaces
{
    interface ISearchingAlgorithm
    {
        /// <summary>
        /// This method searchs an item in given array.
        /// </summary>
        /// <typeparam name="T">Types of an array elements and searched item must be the same.</typeparam>
        /// <param name="array">An array in which to search.</param>
        /// <param name="item">An item that needs to be searched.</param>
        void Search<T>(T[] array, T item) where T : IComparable;
    }
}
