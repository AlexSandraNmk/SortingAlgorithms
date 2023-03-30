using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Interfaces
{
    interface ISortingAlgorithm
    {
        /// <summary>
        /// This method sorts an array.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="array">An array that need to be sorted.</param>
        void Sort<T>(T[] array) where T : IComparable;
    }
}
