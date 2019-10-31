namespace Algorithms.Sorting
{
    public static class ShellSort
    {
        public static void Sort(int[] array)
        {
            var interval = 1;
            while (interval < array.Length / 3)
                interval = interval * 3 + 1;

            while (interval > 0)
            {
                for (var outer = interval; outer < array.Length; outer++)
                {
                    var value = array[outer];
                    var inner = outer;

                    while (inner > interval - 1 && array[inner - interval] > value)
                    {
                        array[inner] = array[inner - interval];
                        inner -= interval;
                    }

                    array[inner] = value;
                }
                
                interval = (interval - 1) / 3;
            }
        }
    }
}