namespace AIE24_CheckArrayEquality
{
    public static class Program
    {
        public static bool CheckArrayEquality(int[] _array1, int[] _array2)
        {
            Array.Sort(_array1);
            Array.Sort(_array2);
            return _array1.SequenceEqual(_array2);
        }

        public static void Main()
        {
            int[] numbers1 = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            int[] numbers2 = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            int[] numbers3 = new int[] { 10, 3, 6, 6, 6, 8, 1, 7 };

            Console.WriteLine(CheckArrayEquality(numbers1, numbers2));
            Console.WriteLine(CheckArrayEquality(numbers2, numbers3));
        }
    }
}