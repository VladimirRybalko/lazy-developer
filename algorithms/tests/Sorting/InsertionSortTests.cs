using Algorithms.Sorting;
using Algorithms.Tests.Asserts;
using Algorithms.Tests.Data;
using Xunit;

namespace Algorithms.Tests.Sorting
{
    public class InsertionSortTests
    {
        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void InsertionSortTest(int[] array)
        {
            // Arrange
            // Act
            InsertionSort.Sort(array);

            // Assert
            AssertEx.IsOrdered(array);
        }
    }
}