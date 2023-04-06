using SortingAlgorithms.Algorithms.Sorting;
using SortingAlgorithms.Helpers;
using SortingAlgorithms.Interfaces;

namespace SortingAlgorithms.Tests.SortingAlgorithms
{
    public class MergeSortTests
    {
        private ISortingAlgorithm mergeSort = new MergeSort();

        [Fact]
        public void MergeSort_InputIsEmptyIntArray_IntArrayIsEmpty()
        {
            int[] array = new int[0];

            mergeSort.Sort(array);

            Assert.Equal(Array.Empty<int>(), array);
        }

        [Fact]
        public void MergeSort_InputIsEmptyStringArray_StringArrayIsEmpty()
        {
            string[] array = new string[0];

            mergeSort.Sort(array);

            Assert.Equal(Array.Empty<string>(), array);
        }

        [Fact]
        public void MergeSort_InputIsEmptyGuidArray_GuidArrayIsEmpty()
        {
            Guid[] array = new Guid[0];

            mergeSort.Sort(array);

            Assert.Equal(Array.Empty<Guid>(), array);
        }
        
        [Fact]
        public void MergeSort_InputIsHelperGeneratedIntArray_IntArrayIsSorted()
        {
            int[] array = ArrayGenerator.GenerateIntArray(10000);
            int[] expected = array;

            Array.Sort(expected);
            mergeSort.Sort(array);

            Assert.Equal(expected, array);
        }
        
        [Fact]
        public void MergeSort_InputIsHelperGeneratedStringArray_StringArrayIsSorted()
        {
            string[] array = ArrayGenerator.GenerateStringArray(10000);
            string[] expected = array;

            Array.Sort(expected);
            mergeSort.Sort(array);

            Assert.Equal(expected, array);
        }
        
        [Fact]
        public void MergeSort_InputIsHelperGeneratedGuidArray_GuidArrayIsSorted()
        {
            Guid[] array = ArrayGenerator.GenerateGuidArray(10000);
            Guid[] expected = array;

            Array.Sort(expected);
            mergeSort.Sort(array);

            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new int[] { 23, 956, 1, 584, 25, 2, 41, 368, 368, 251, 0, 0 })]
        [InlineData(new int[] { 8000, 888, 880, 88, 80, 81, 5, 8, 1, 5, 46, 8, 2, 1, 5, 8, 6, 1 })]
        [InlineData(new int[] { 123, 124, 125, 1233, 12333, 123, 513, 1215, 123 })]
        [InlineData(new int[] { 10, -10, 90, -90, 900, -56, 222 })]
        public void MergeSort_InputIsUnsortedIntArray_IntArrayIsSorted(int[] array)
        {
            int[] expected = array;

            Array.Sort(expected);
            mergeSort.Sort(array);

            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData("name", "surname")]
        [InlineData("6 six", "1 one", "0 zero", "3 three", "7 seven", "10 ten", "5 five", "2 two", "8 eight", "9 nine", "4 four")]
        [InlineData("", "", "")]
        [InlineData("alex", "andrew", "george", "Jake", "jake", "Geor", "ANDrew", "Andrew", "ALEX", "GEORGE")]
        public void MergeSort_InputIsUnsortedStringArray_StringArrayIsSorted(params string[] array)
        {
            string[] expected = array;

            Array.Sort(expected);
            mergeSort.Sort(array);

            Assert.Equal(expected, array);
        }
    }
}
