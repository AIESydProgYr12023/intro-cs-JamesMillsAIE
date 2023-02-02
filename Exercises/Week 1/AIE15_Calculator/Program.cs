namespace AIE15_Calculator
{
    public static class Program
    {
        public static double Calculate(double _a, double _b, char _operation)
        {
            switch(_operation)
            {
                case '+':
                    return _a + _b;
                case '-':
                    return _a - _b;
                case '*':
                    return _a * _b;
                case '/':
                    return _a / _b;
                case '%':
                    return _a % _b;
                default:
                    Console.WriteLine($"{_operation} is not a valid... operation.");
                    return 0;
            }
        }

        public static void Main()
        {
            Console.WriteLine(Calculate(4.5D, 3, '+'));
            Console.WriteLine(Calculate(5.5D, 12.321987D, '+'));
            Console.WriteLine(Calculate(4, 3, '-'));
            Console.WriteLine(Calculate(4, 3, '*'));
            Console.WriteLine(Calculate(4, 3, '/'));
            Console.WriteLine(Calculate(4, 3, '%'));

            Calculate(4, 3, ']');
        }
    }
}