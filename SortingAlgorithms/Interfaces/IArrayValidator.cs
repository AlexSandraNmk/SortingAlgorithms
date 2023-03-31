using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Interfaces
{
    public interface IArrayValidator
    {
        public bool IsSorted<T>(T[] arr) where T : IComparable;
    }
}
