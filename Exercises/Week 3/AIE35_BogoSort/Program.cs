namespace AIE35_BogoSort
{
    public static class Program
    {
        private static int[] BogoSort(int[] _numbers)
        {
            Random random = new Random();
            while(!IsSorted(_numbers))
            {
                Shuffle(_numbers, random);
            }

            return _numbers;
        }

        private static void Shuffle(int[] _array, Random _random)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                int randomIndex = _random.Next(0, i + 1);

                int temp = _array[i];
                _array[i] = _array[randomIndex];
                _array[randomIndex] = temp;
            }
        }

        private static bool IsSorted(int[] _array)
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i] > _array[i + 1])
                    return false;
            }

            return true;
        }

        public static void Main()
        {
            int[] numbers = { 10, 3, 6, 6, 4, 8, 1, 7, 44, 2, 75 };

            int[] sorted = BogoSort(numbers);

            foreach (int number in sorted)
            {
                Console.WriteLine(number);
            }
        }
    }
}