using SortingAlgorithms.Algorithms.Searching;
using SortingAlgorithms.Algorithms.Sorting;
using SortingAlgorithms.Helpers;
using SortingAlgorithms.Interfaces;

namespace SortingAlgorithms.Tests.SearchingAlgorithm
{
    public class BinarySearchTests
    {
        private ISearchingAlgorithm binarySearch = new BinarySearch(new MergeSort(), new ArrayValidator());

        [Fact]
        public void BinarySearch_InputIsEmptyIntArrayAndZero_ReturnsFalse()
        {
            int[] array = new int[0];

            bool result = binarySearch.Search(array, 0);

            Assert.False(result);
        }

        [Fact]
        public void BinarySearch_InputIsEmptyStringArrayAndEmptyString_ReturnsFalse()
        {
            string[] array = new string[0];

            bool result = binarySearch.Search(array, string.Empty);

            Assert.False(result);
        }

        [Fact]
        public void BinarySearch_InputIsEmptyGuidArrayAndEmptyGuid_ReturnsFalse()
        {
            Guid[] array = new Guid[0];

            bool result = binarySearch.Search(array, Guid.Empty);

            Assert.False(result);
        }

        [Theory]
        [InlineData(0, new int[] { 23, 956, 1, 584, 25, 2, 41, 368, 368, 251, 0, 0 })]
        [InlineData(8, new int[] { 8000, 888, 880, 88, 80, 81, 5, 8, 1, 5, 46, 8, 2, 1, 5, 8, 6, 1 })]
        [InlineData(1233, new int[] { 123, 124, 125, 1233, 12333, 123, 513, 1215, 123 })]
        [InlineData(-10, new int[] { 10, -10, 90, -90, 900, -56, 222 })]
        public void BinarySearch_InputIsIntArrayAndContainedInt_ReturnsTrue(int item, int[] array)
        {
            bool result = binarySearch.Search(array, item);

            Assert.True(result);
        }

        [Theory]
        [InlineData(-5, new int[] { 23, 956, 1, 584, 25, 2, 41, 368, 368, 251, 0, 0 })]
        [InlineData(0, new int[] { 8000, 888, 880, 88, 80, 81, 5, 8, 1, 5, 46, 8, 2, 1, 5, 8, 6, 1 })]
        [InlineData(12, new int[] { 123, 124, 125, 1233, 12333, 123, 513, 1215, 123 })]
        [InlineData(-100, new int[] { 10, -10, 90, -90, 900, -56, 222 })]
        public void BinarySearch_InputIsIntArrayAndUncontainedInt_ReturnsFalse(int item, int[] array)
        {
            bool result = binarySearch.Search(array, item);

            Assert.False(result);
        }

        [Theory]
        [InlineData("name", "name", "surname")]
        [InlineData("5 five", "6 six", "1 one", "0 zero", "3 three", "7 seven", "10 ten", "5 five", "2 two", "8 eight", "9 nine", "4 four")]
        [InlineData("", "", "", "")]
        [InlineData("Geor", "alex", "andrew", "george", "Jake", "jake", "Geor", "ANDrew", "Andrew", "ALEX", "GEORGE")]
        public void BinarySearch_InputIsStringArrayAndContainedString_ReturnsTrue(string item, params string[] array)
        {
            bool result = binarySearch.Search(array, item);

            Assert.True(result);
        }

        [Theory]
        [InlineData("Name", "name", "surname")]
        [InlineData("five", "6 six", "1 one", "0 zero", "3 three", "7 seven", "10 ten", "5 five", "2 two", "8 eight", "9 nine", "4 four")]
        [InlineData(" ", "", "", "")]
        [InlineData("Alex", "alex", "andrew", "george", "Jake", "jake", "Geor", "ANDrew", "Andrew", "ALEX", "GEORGE")]
        public void BinarySearch_InputIsStringArrayAndUncontainedString_ReturnsFalse(string item, params string[] array)
        {
            bool result = binarySearch.Search(array, item);

            Assert.False(result);
        }
    }
}
