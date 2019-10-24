using Algorithms.Sorting;
using Algorithms.Tests.Asserts;
using Algorithms.Tests.Data;
using Xunit;

namespace Algorithms.Tests.Sorting
{
    public class SelectionSortTests
    {
        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void SortTest(int[] array)
        {
            // Arrange
            // Act
            SelectionSort.Sort(array);

            // Assert
            AssertEx.IsOrdered(array);
        }
    }
}