using Xunit;
using Algorithms.Sorting;
using Algorithms.Tests.Asserts;
using Algorithms.Tests.Data;

namespace Algorithms.Tests.Sorting
{
    public class MergeSortTests
    {
        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void SortTest(int[] array)
        {
            // Arrange
            // Act
            MergeSort.Sort(array);

            // Assert
            AssertEx.IsOrdered(array);
        }
    }
}