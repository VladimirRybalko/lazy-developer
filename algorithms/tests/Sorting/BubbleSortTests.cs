using Xunit;
using Algorithms.Sorting;
using Algorithms.Tests.Asserts;
using Algorithms.Tests.Data;

namespace Algorithms.Tests.Sorting
{
    public class BubbleSortTests
    {
        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void BubbleSortTest(int[] array)
        {
            // Arrange
            // Act
            BubbleSort.Sort(array);

            // Assert
            AssertEx.IsOrdered(array);
        }
    }
}