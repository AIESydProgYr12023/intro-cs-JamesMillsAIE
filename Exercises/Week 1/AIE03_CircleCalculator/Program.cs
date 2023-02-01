namespace AIE03_CircleCalculator
{
    public static class Program
    {
        public static void Main()
        {
            // Variables
            float radius = 69420.201f;

            // Storing results in variables
            double circumference = Math.Round(2 * Math.PI * radius, 2);
            double area = Math.Round(Math.PI * Math.Pow(radius, 2), 2);

            // Output variables
            Console.WriteLine("The circumference is: " + circumference);
            Console.WriteLine("The area is: " + area);
        }
    }
}