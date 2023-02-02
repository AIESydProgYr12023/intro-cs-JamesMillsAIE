namespace AIE07_EvenOrOdd
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Input a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if(num % 2 == 0)
            {
                Console.WriteLine($"{num} is even!");
            }
            else
            {
                Console.WriteLine($"{num} is odd!");
            }
        }
    }
}