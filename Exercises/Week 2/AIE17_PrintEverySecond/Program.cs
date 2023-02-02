namespace AIE17_PrintEverySecond
{
    public static class Program
    {
        public static void PrintEverySecond(int[] _numbers)
        {
            for (int i = 1; i < _numbers.Length; i += 2)
            {
                Console.WriteLine(_numbers[i]);
            }
        }

        public static void Main()
        {
            int[] numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };

            // 3 6 8 7
            PrintEverySecond(numbers);
        }
    }
}