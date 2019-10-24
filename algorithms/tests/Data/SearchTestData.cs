using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Tests.Data
{
    public class SearchTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new[] {1, 2, 4, 5, 6, 7, 8, 9, 0}, 7, 5};
            yield return new object[] {new[] {5, 6, 8, 0, 5, -4, 34, 0, 0, 1}, 5, 0};
            yield return new object[] {new int[0], 87, -1};
            yield return new object[] {new[] {42}, 42, 0};
            yield return new object[] {new[] {1, 2, 3, 4, 5, 6, 7}, 7, 6};
            yield return new object[] {new[] {20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0}, 0, 20};
            yield return new object[] {new[] {1, 1, 1, 1, 1, 1, 1, 1}, 1, 0};
            yield return new object[] {new[] {int.MinValue, -1, int.MaxValue}, 9, -1};
            yield return new object[] {new[] {50, 0, 2}, -9, -1};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}