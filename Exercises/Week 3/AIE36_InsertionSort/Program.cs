namespace AIE36_InsertionSort
{
    public static class Program
    {
        private static int[] InsertionSort(int[] _numbers)
        {
            for (int i = 0; i < _numbers.Length; i++)
            {
                // Key Value to start sort
                int keyValue = _numbers[i];
                int j = i - 1;

                // While index is greater than 0 and greater than the key value
                while (j >= 0 && _numbers[j] > keyValue)
                {
                    _numbers[j + 1] = _numbers[j];
                    j--;
                }

                // Assign the next value in array as key value
                _numbers[j + 1] = keyValue;
            }

            return _numbers;
        }

        public static void Main()
        {
            int[] numbers = { 10, 3, 6, 6, 4, 8, 1, 7 };

            int[] sorted = InsertionSort(numbers);

            foreach (int number in sorted)
            {
                Console.WriteLine(number);
            }
        }
    }
}