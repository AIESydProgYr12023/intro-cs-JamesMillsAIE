namespace AIE09_NineTimesTables
{
    public static class Program
    {
        public static void Main()
        {
            // F - First Value - aka iterator
            // O - Operator - aka when does the loop stop
            // R - Rate Of Change - aka how much does the iterator change per loop
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{i} * 9 = {i * 9}");
            }
        }
    }
}