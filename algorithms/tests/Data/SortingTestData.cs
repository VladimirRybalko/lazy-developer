using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Tests.Data
{
    public class SortingTestData : IEnumerable<object[]>
    {
        private static readonly Random _random = new Random();
        
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new[] {1, 2, 4, 5, 6, 7, 8, 9, 0}};
            yield return new object[] {new[] {5, 6, 8, 0, 6 - 4, 34, 0, 0, 1}};
            yield return new object[] {new int[0]};
            yield return new object[] {new [] { 42 }};
            yield return new object[] {new[] {1, 2, 3, 4, 5, 6, 7}};
            yield return new object[] { new[] {20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0}};
            yield return new object[] {new[] {1, 1, 1, 1, 1, 1, 1, 1}};
            yield return new object[] {new[] {int.MinValue, -1, int.MaxValue}};
            yield return new object[] {new[] { 50, 0, 2}};
            yield return new object[] { Enumerable.Range(0, _random.Next(50)).Select(x => _random.Next()).ToArray()};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}