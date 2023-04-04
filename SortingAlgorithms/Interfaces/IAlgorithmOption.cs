using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Interfaces
{
    interface IAlgorithmOption
    {
        /// <summary>
        /// Async method that executes next interactive user level.
        /// </summary>
        Task ExecuteAsync();
    }
}
