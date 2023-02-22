namespace AIE43_TemperatureCalculatorAdvanced
{
    public static class Program
    {
        public static void Main()
        {
            Temperature melbourne = new Temperature(18.5f);
            Temperature sydney = new Temperature(21f);

            Temperature temperature = melbourne + sydney;
            Console.WriteLine(temperature);
            Console.WriteLine(temperature.farenheit);

            Console.WriteLine($"Temperatures match? {melbourne == sydney}");
        }
    }
}