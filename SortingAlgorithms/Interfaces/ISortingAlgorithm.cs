using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Interfaces
{
    interface ISortingAlgorithm
    {
        void Sort<T>(T[] array) where T : IComparable;
    }
}
