namespace Algorithms.Sorting
{
    public static class InsertionSort
    {
        public static void Sort(int[] array)
        {
            for (var i = 1; i < array.Length; ++i)
            {
                // Store the current value in a variable
                var currentValue = array[i];
                var pointer = i - 1;

                // While we are pointing to a valid value...
                // If the current value is less than the value we are pointing at...
                while (pointer >= 0 && array[pointer] > currentValue)
                {
                    // Then move the pointed-at value up one space, and store the current value at the pointed-at position.
                    array[pointer + 1] = array[pointer];
                    pointer--;
                }
                array[pointer + 1] = currentValue;
            }
        }
    }
}