using System;

namespace Algorithms.Sorting
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }
        
        private static void Sort(int[] input, int left, int right)
        {
            if (left < right)
            {
                var middle = (left + right) / 2;
 
                Sort(input, left, middle);
                Sort(input, middle + 1, right);
 
                Merge(input, left, middle, right);
            }
        }    
        
        private static void Merge(int[] array, int left, int middle, int right)
        {
            var leftArray = new int[middle - left + 1];
            var rightArray = new int[right - middle];
 
            Array.Copy(array, left, leftArray, 0, middle - left + 1);
            Array.Copy(array, middle + 1, rightArray, 0, right - middle);
 
            var i = 0;
            var j = 0;
            for (var k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    array[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
            }
        }
    }
}