namespace Algorithms.Search
{
    public static class BinarySearch
    {
        public static int Search(int[] array, int toFind)
        {
            var min = 0;
            var max = array.Length - 1; 
            while (min <=max)  
            {  
                var mid = (min + max) / 2;  
                if (array[mid] == toFind)  
                    return mid;
                
                if (toFind < array[mid]) 
                    max = mid - 1;
                else
                    min = mid + 1;
            }  
            
            return -1; 
        }
    }
}