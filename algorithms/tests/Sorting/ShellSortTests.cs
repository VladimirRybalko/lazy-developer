using Xunit;
using Algorithms.Sorting;
using Algorithms.Tests.Asserts;
using Algorithms.Tests.Data;

namespace Algorithms.Tests.Sorting
{
    public class ShellSortTests
    {
        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void SortTest(int[] array)
        {
            // Arrange
            // Act
            ShellSort.Sort(array);

            // Assert
            AssertEx.IsOrdered(array);
        }
    }
}