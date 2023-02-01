namespace AIE04_TemperatureCalculator
{
    public static class Program
    {
        public static void Main()
        {
            // Variables
            float celcius = 32.5f;
            float fahrenheit = 40.5f;

            // Storing result in variables
            float convertedToFahrenheit = (celcius * 9 / 5 + 32);
            float convertedToCelcius = ((fahrenheit - 32) * 5 / 9);

            // Output variables
            Console.WriteLine(convertedToCelcius);
            Console.WriteLine(convertedToFahrenheit);
        }
    }
}