namespace AIE34_BubbleSort
{
    public static class Program
    {
        private static int[] BubbleSort(int[] _numbers)
        {
            bool isSorted = false;

            while(!isSorted)
            {
                // Assume the array is sorted
                isSorted = true;

                // Loop through the array
                // We need to subtract 1 because we assume the final is in place
                for (int i = 0; i < _numbers.Length - 1; i++)
                {
                    // If the current item is greater than the next, swap them
                    if (_numbers[i] > _numbers[i + 1])
                    {
                        // Temp variable to store current value
                        int temp = _numbers[i];
                        _numbers[i] = _numbers[i + 1];
                        _numbers[i + 1] = temp;

                        // Tell the loop the array isn't sorted
                        isSorted = false;
                    }
                }
            }

            return _numbers;
        }

        public static void Main()
        {
            int[] numbers = { 10, 3, 6, 6, 4, 8, 1, 7 };

            int[] sorted = BubbleSort(numbers);

            foreach (int number in sorted)
            {
                Console.WriteLine(number);
            }
        }
    }
}