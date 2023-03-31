using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.UserInteraction
{
    public class InputValidator
    {
        /// <summary>
        /// Asks user to write down a size array and checks for correct input.
        /// </summary>
        /// <returns>Int that can be used as array size.</returns>
        public int AskArraySize()
        {
            Console.Write("Number of items in array: ");
            string input = Console.ReadLine();

            int number;

            while (!int.TryParse(input, out number))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                input = Console.ReadLine();
            }

            return number;
        }

        /// <summary>
        /// Asks user to write down an element that will be searched in array.
        /// </summary>
        /// <returns>String.</returns>
        public string AskSearchedElement()
        {
            Console.Write("Element to search: ");
            return Console.ReadLine();
        }
    }
}
