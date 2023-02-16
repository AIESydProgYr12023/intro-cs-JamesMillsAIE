namespace AIE41_ReversePolishNotation
{
    public static class Program
    {
        private static double CalculateRpn(string _formula)
        {
            // 1. Split the formula into it's components by the space character
            string[] formula = _formula.Split(' '); // { "10", "20", "5", "*", "+", "2", "*" }

            // Initialise the final result
            double result = 0;

            // Create Stack
            Stack<double> stack = new Stack<double>();

            // 2. Loop through each number and operation
            foreach (string s in formula)
            {
                if(double.TryParse(s, out double num))
                {
                    // This 's' value is a number, so add the converted value to the top of the stack
                    stack.Push(num);
                }
                else
                {
                    // Remove the last 2 numbers from the stack and store them in temp variables
                    double num1 = stack.Pop();
                    double num2 = stack.Pop();

                    // Run the operation
                    switch (s)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num2 - num1;
                            break;
                        case "/":
                            result = num2 / num1;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                    }

                    // Store the result of this operation in the stack
                    stack.Push(result);
                }
            }

            return result;
        }

        public static void Main()
        {
            double test1 = CalculateRpn("10 20 +"); // 30
            double test2 = CalculateRpn("10 20 -"); // -10
            double test3 = CalculateRpn("10 20 *"); // 200
            double test4 = CalculateRpn("20 10 /"); // 2
            double test5 = CalculateRpn("10 20 5 * +"); // 110
            double test6 = CalculateRpn("10 20 5 * + 2 *"); // 220 -> ((5 * 20) + 10) * 2

            Console.WriteLine($"Test 1: {(test1 == 30 ? "success" : "fail")}");
            Console.WriteLine($"Test 2: {(test2 == -10 ? "success" : "fail")}");
            Console.WriteLine($"Test 3: {(test3 == 200 ? "success" : "fail")}");
            Console.WriteLine($"Test 4: {(test4 == 2 ? "success" : "fail")}");
            Console.WriteLine($"Test 5: {(test5 == 110 ? "success" : "fail")}");
            Console.WriteLine($"Test 6: {(test6 == 220 ? "success" : "fail")}");
        }
    }
}