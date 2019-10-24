using Algorithms.Sorting;
using Algorithms.Tests.Asserts;
using Algorithms.Tests.Data;
using Xunit;

namespace Algorithms.Tests.Sorting
{
    public class CocktailShakerSortTests
    {
        [Theory]
        [ClassData(typeof(SortingTestData))]
        public void CocktailShakerSortTest(int[] array)
        {
            // Arrange
            // Act
            CocktailShakerSort.Sort(array);

            // Assert
            AssertEx.IsOrdered(array);
        }
    }
}