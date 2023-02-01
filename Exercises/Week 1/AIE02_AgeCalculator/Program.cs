namespace AIE02_AgeCalculator
{
    public static class Program
    {
        public static void Main()
        {
            // Variables
            int birthYear = 1996;
            int currentYear = 2023;

            // Calculate Age based on given variables
            Console.WriteLine("You are " + (currentYear - birthYear) + " years old.");
        }
    }
}