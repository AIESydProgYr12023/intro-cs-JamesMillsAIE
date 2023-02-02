namespace AIE23_MinMax
{
    public static class Program
    {
        public static int[] FindMinMax(int[] _numbers)
        {
            int[] minMax = new int[2];
            minMax[0] = _numbers.Min();
            minMax[1] = _numbers.Max();

            return minMax;
        }

        public static void Main()
        {
            int[] numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            int[] minMax = FindMinMax(numbers);

            // Min: 1 - Max: 10
            Console.WriteLine($"Min: {minMax[0]} - Max: {minMax[1]}");
        }
    }
}