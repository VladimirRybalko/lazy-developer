namespace Algorithms.Sorting
{
    public static class QuickSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (left >= right)
                return;

            var pivot = Partition(array, left, right);

            if (pivot > 1)
                Sort(array, left, pivot - 1);

            if (pivot + 1 < right)
                Sort(array, pivot + 1, right);
        }

        private static int Partition(int[] array, int left, int right)
        {
            var pivot = array[left];
            while (true)
            {
                while (array[left] < pivot)
                    left++;

                while (array[right] > pivot)
                    right--;

                if (left >= right)
                    return right;

                if (array[left] == array[right]) // array contains identical elements
                    return right;
                
                var temp = array[right];
                array[right] = array[left];
                array[left] = temp;
            }
        }
    }
}