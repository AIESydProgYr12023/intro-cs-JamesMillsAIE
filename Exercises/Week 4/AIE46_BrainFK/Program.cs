namespace AIE46_BrainFK
{
    public static class Program
    {
        public static void PrintBrainF(string _formula)
        {
            // > = Increment the data pointer
            // < = Decrement the data pointer
            // + = Increment the byte at the data pointer
            // - = Decrement the byte at the data pointer
            // . = Output the byte at the data pointer
            // , = Accept one byte of input, storing its value in the byte at the data pointer
            // [ = If the byte at the data pointer is 0, then instead of moving the instruction pointer forward to the next command
            // jump it forward to the command after the matching ] command.
            // ] = If the byte at the data pointer is non0, the instead of moving the instruction pointer foward to the next command,
            // jump it back to the command after the matching [ command.

            // Init a list with 1 starting value of 0
            List<int> stack = new List<int>() { 0 };
            int stackTracker = 0;
            int bracketTracker = 0;

            for (int i = 0; i < _formula.Length; i++)
            {
                switch(_formula[i])
                {
                    case '.':
                        Console.Write(char.ConvertFromUtf32(stack[stackTracker]));
                        break;

                    case '+':
                        stack[stackTracker]++;
                        break;

                    case '-':
                        if (stack[stackTracker] != 0)
                            stack[stackTracker]--;
                        break;

                    case '>':
                        if(stackTracker + 1 == stack.Count)
                            stack.Add(0);

                        stackTracker++;
                        break;

                    case '[':
                        if(stack[stackTracker] == 0)
                        {
                            bracketTracker++;
                            while (_formula[i] != ']' || bracketTracker != 0)
                            {
                                i++;
                                if (_formula[i] == '[')
                                {
                                    bracketTracker++;
                                }
                                else if (_formula[i] == ']')
                                {
                                    bracketTracker--;
                                }
                            }
                        }

                        break;

                    case ']':
                        if (stack[stackTracker] != 0)
                        {
                            bracketTracker++;
                            while (_formula[i] != '[' || bracketTracker != 0)
                            {
                                i--;
                                if (_formula[i] == ']')
                                {
                                    bracketTracker++;
                                }
                                else if (_formula[i] == '[')
                                {
                                    bracketTracker--;
                                }
                            }
                        }

                        break;

                    case '<':
                        if (stackTracker != 0)
                            stackTracker--;

                        break;
                }
            }
        }

        public static void Main()
        {
            string bfHelloWorld = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";
            PrintBrainF(bfHelloWorld);
        }
    }
}