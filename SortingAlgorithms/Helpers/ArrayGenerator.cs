using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Helpers
{
    public static class ArrayGenerator
    {
        public static int[] GenerateRandomArray(int sizeOfArray)
        {
            _sizeOfArray = sizeOfArray;
        }

        /// <summary>
        /// Create int array of given size.
        /// </summary>
        /// <returns>Int array of given size.</returns>
        public int[] GenerateIntArray()
        {
            int[] array = new int[_sizeOfArray];
            Random random = new Random();
            int maxNumber = 1000;

            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = random.Next(maxNumber + 1);
            }

            return array;
        }

        /// <summary>
        /// Create string array of given size.
        /// </summary>
        /// <returns>String array of given size.</returns>
        public string[] GenerateStringArray()
        {
            string[] array = new string[_sizeOfArray];

            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = GenerateName();
            }

            return array;
        }

        /// <summary>
        /// Create Guid array of given size.
        /// </summary>
        /// <returns>Guid array of given size.</returns>
        public Guid[] GenerateGuidArray()
        {
            Guid[] array = new Guid[_sizeOfArray];

            for (int i = 0; i < _sizeOfArray; i++)
            {
                array[i] = Guid.NewGuid();
            }

            return array;
        }

        /// <summary>
        /// The method generates name-like string from consonants and vowels.
        /// </summary>
        /// <returns>Name-like string.</returns>
        private string GenerateName()
        {
            Random random = new Random();
            int length = random.Next(1, 8);
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            
            string Name = "";
            Name += consonants[random.Next(consonants.Length)].ToUpper();
            Name += vowels[random.Next(vowels.Length)];

            int i = 2;

            while (i < length)
            {
                Name += consonants[random.Next(consonants.Length)];
                i++;
                Name += vowels[random.Next(vowels.Length)];
                i++;
            }

            return Name;
        }
    }
}
