namespace AIE_04_SumOfArray
{
    public static class Program
    {
        private static int SumNumbers(int[] _numbers)
        {
            return 0;
        }

        private static void Main()
        {
            Console.WriteLine(SumNumbers(new int[] { 1, 2, 3 }));   // Expected: 6
            Console.WriteLine(SumNumbers(new int[] { 1, 1, 1 }));   // Expected: 3
            Console.WriteLine(SumNumbers(new int[] { 5, -5, 5 }));  // Expected: 5
        }
    }
}