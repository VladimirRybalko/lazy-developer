namespace Algorithms.Sorting
{
    public static class CocktailShakerSort
    {
        public static void Sort(int[] array)
        {
            var isSwapped = true;
            var start = 0;
            var end = array.Length;

            while (isSwapped)
            {
                isSwapped = false;

                // From low to high.
                for (var i = start; i < end - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }

                // The array is sorted.
                if (isSwapped == false)
                    break;

                isSwapped = false;
                end--;

                // From high to low
                for (var i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }

                start++;
            }
        }
    }
}