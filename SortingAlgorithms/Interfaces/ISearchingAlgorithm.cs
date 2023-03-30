﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Interfaces
{
    interface ISearchingAlgorithm
    {
        void Search<T>(T[] array, T item) where T : IComparable;
    }
}
