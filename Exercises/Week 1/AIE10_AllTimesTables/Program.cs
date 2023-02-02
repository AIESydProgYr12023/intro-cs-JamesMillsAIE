namespace AIE10_AllTimesTables
{
    public static class Program
    {
        public static void Main()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{i} Times Tables: ");
                for (int j = 0; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
            }
        }
    }
}