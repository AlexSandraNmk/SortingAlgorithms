﻿using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public class ArrayValidator : IArrayValidator
    {
        /// <inheritdoc />
        public bool IsSorted<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i].CompareTo(arr[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
