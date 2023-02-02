namespace AIE05_HighLow
{
    public static class Program
    {
        public static void Main()
        {
            // Converts a given number from the console to double... Will crash if number not given
            Console.Write("Enter a number: ");
            double num = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("You entered: " + num);

            // If else statements based on number given
            if(num > 50)
            {
                Console.WriteLine(num + " is greater than 50.");
            }
            else if(num < 50)
            {
                Console.WriteLine(num + " is less than 50.");
            }
            else
            {
                Console.WriteLine("Your number is exactly 50.");
            }
        }
    }
}