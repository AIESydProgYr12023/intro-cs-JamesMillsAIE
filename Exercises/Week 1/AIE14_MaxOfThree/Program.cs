namespace AIE14_MaxOfThree
{
    public static class Program
    {
        public static double MaxOfAny(double[] _numbers)
        {
            // Scoped variables
            double maxNumber = 0;

            foreach (double num in _numbers)
            {
                if(num > maxNumber)
                {
                    maxNumber = num;
                }
            }

            return maxNumber;
        }

        public static void Main()
        {
            Console.WriteLine(MaxOfAny(new double[] { 5, 8, 3, 1, 25, 19 }));
            Console.WriteLine(MaxOfAny(new double[] { 2, 1, 3, 17, 25, 50 }));
        }
    }
}