namespace AIE22_CalculateAverage
{
    public static class Program
    {
        public static float CalculateAverage(int[] _numbers)
        {
            return _numbers.Sum() / (float)_numbers.Length;
        }

        public static void Main()
        {
            int[] numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            Console.WriteLine(CalculateAverage(numbers));
        }
    }
}