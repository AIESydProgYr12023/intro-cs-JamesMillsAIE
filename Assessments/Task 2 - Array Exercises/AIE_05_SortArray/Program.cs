namespace AIE_05_SortArray
{
    public static class Program
    {
        private static int[] SortDescending(int[] _inputArray)
        {
            return new int[1];
        }

        private static void PrintArray(int[] _arr)
        {
            Console.Write("{");
            foreach (int i in _arr)
            {
                Console.Write($"{i} ");
            }
            Console.Write("}\n");
        }

        private static void Main()
        {
            PrintArray(SortDescending(new int[] { 8, 10, 6, 6, 2, 9, 4, 1 }));
            PrintArray(SortDescending(new int[] { 0, 1, 0, 2, 998, 2, -1, -56 }));
            PrintArray(SortDescending(new int[] { }));
        }
    }
}