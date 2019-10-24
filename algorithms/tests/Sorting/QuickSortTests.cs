using Algorithms.Sorting;
using Algorithms.Tests.Asserts;
using Algorithms.Tests.Data;
using Xunit;

namespace Algorithms.Tests.Sorting
{
    public class QuickSortTests
    {
        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void SortTest(int[] array)
        {
            // Arrange
            // Act
            QuickSort.Sort(array);

            // Assert
            AssertEx.IsOrdered(array);
        }
    }
}