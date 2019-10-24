using Algorithms.Search;
using Algorithms.Sorting;
using Xunit;

namespace Algorithms.Tests.Search
{
    public class BinarySearchTests
    {
        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 7, 7)]
        [InlineData(new[] { 0, 0, 0}, 0, 1)]
        [InlineData(new[] { 0, 1, 2, 3, 4, }, 7, -1)]
        [InlineData(new[] {-10, -2, 3, 7, 8, 99}, 7, 3)]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 0, 0)]
        [InlineData(new int[0], 7, -1)]
        [InlineData(new[] { 34, 99 }, 56, -1)]
        [InlineData(new[] { 1,2,7,10}, 10, 3)]
        public void SearchTest(int[] array, int toFind, int index)
        {
            // Arrange
            QuickSort.Sort(array);
            
            // Act
            var result = BinarySearch.Search(array, toFind);
            
            // Assert
            Assert.Equal(index, result);
        }
    }
}