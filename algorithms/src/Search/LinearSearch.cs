namespace Algorithms.Search
{
    public static class LinearSearch
    {
        public static int Search(int[] array, int toFind)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == toFind)
                    return i;
            }

            return -1;
        }
    }
}