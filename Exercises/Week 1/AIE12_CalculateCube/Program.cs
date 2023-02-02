namespace AIE12_CalculateCube
{
    public static class Program
    {
        private static double CalculateCube(int _num)
        {
            return Math.Pow(_num, 3);
        }

        public static void Main()
        {
            Console.WriteLine(CalculateCube(5));
            Console.WriteLine(CalculateCube(10));
            Console.WriteLine(CalculateCube(420));
            Console.WriteLine(CalculateCube(69));
        }
    }
}