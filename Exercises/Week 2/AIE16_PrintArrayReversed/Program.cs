namespace AIE16_PrintArrayReversed
{
    public static class Program
    {
        public static void PrintArrayReversed(int[] _number)
        {
            Console.Write("{ ");

            for (int i = _number.Length - 1; i >= 0; i--)
            {
                if (i > 0)
                {
                    Console.Write($"{_number[i]}, "); 
                }
                else
                {
                    Console.Write(_number[i]);
                }
            }

            Console.Write(" }");
        }

        public static void PrintArrayReversedAlt(int[] _numbers)
        {
            int[] reversed = new int[_numbers.Length];
            _numbers.CopyTo(reversed, 0);
            Array.Reverse(reversed);

            Console.Write("{ ");

            foreach (int number in reversed)
            {
                Console.Write($"{number}, ");
            }

            Console.Write("}");
        }

        public static void Main()
        {
            int[] numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };

            PrintArrayReversed(numbers);
            PrintArrayReversedAlt(numbers);
        }
    }
}