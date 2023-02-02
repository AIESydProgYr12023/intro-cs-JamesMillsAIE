namespace AIE18_PrintSorted
{
    public static class Program
    {
        public static void PrintSorted(int[] _numbers)
        {
            int[] sorted = new int[_numbers.Length];
            _numbers.CopyTo(sorted, 0);
            Array.Sort(sorted);

            string sortedString = "{ " + string.Join(", ", sorted) + " }";
            Console.WriteLine(sortedString);
        }

        public static void Main()
        {
            int[] numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };

            string normal = "{ " + string.Join(", ", numbers) + " }";
            Console.WriteLine(normal);
            Console.WriteLine("\n------------------\n");
            PrintSorted(numbers);
        }
    }
}