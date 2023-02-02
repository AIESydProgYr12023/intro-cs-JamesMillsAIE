namespace AIE06_MaxOfThree
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please input 3 numbers:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int num3 = Convert.ToInt32(Console.ReadLine());
            int maxNumber = 0;

            if(num1 > maxNumber)
            {
                maxNumber = num1;
            }

            if(num2 > maxNumber)
            {
                maxNumber = num2;
            }

            if(num3 > maxNumber)
            {
                maxNumber = num3;
            }

            Console.WriteLine($"Largest number of {num1}, {num2} and {num3} is {maxNumber}");
        }
    }
}