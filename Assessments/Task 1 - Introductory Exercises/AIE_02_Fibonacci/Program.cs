namespace AIE_02_Fibonacci
{
    public static class Program
    {
        private static int[] Fibonacci(int _range)
        {
            return new int[1];
        }

        private static void PrintArray(int[] _array)
        {
            Console.Write("{");
            foreach (int item in _array)
                Console.Write($" {item}");
            
            Console.Write(" } \n");
        }

        private static void Main()
        {
            // Tests
            try
            {
                PrintArray(Fibonacci(5));       // Expected: {0, 1, 1, 2, 3}
                PrintArray(Fibonacci(10));      // Expected: {0, 1, 1, 2, 3, 5, 8, 13, 21, 34}
                PrintArray(Fibonacci(0));       // Expected: { }
                PrintArray(Fibonacci(1));       // Expected: {0}
                PrintArray(Fibonacci(2));       // Expected: {0, 1}
                PrintArray(Fibonacci(-1));      // Expected: an exception will be thrown with message "Cannot create sequence of length -1";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
    }
}