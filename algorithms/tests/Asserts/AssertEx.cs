using Xunit;

namespace Algorithms.Tests.Asserts
{
    public static class AssertEx
    {
        public static void IsOrdered(int[] array)
        {
            var i = 0;
            while (i < array.Length - 1)
            {
                if (array[i] > array[i + 1])
                    Failed("An array is not ordered!");

                i++;
            }
        }

        public static void Failed(string? message = null)
        {
            Assert.True(false, message);
        }
    }
}