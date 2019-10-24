using Algorithms.Search;
using Algorithms.Tests.Data;
using Xunit;

namespace Algorithms.Tests.Search
{
    public class LinearSearchTests
    {
        [Theory]
        [ClassData(typeof(SearchTestData))]
        public void SearchTest(int[] array, int toFind, int index)
        {
            // Arrange
            // Act
            var result = LinearSearch.Search(array, toFind);
            
            // Assert
            Assert.Equal(index, result);
        }
    }
}