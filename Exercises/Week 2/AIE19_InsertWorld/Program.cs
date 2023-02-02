namespace AIE12_CalculateCube
{
    public static class Program
    {
        public static int CountHellos(string[] _words)
        {
            int count = 0;

            for (int i = 0; i < _words.Length; i++)
            {
                if (_words[i] == "hello")
                {
                    count++;
                }
            }

            return count;
        }

        public static string[] InsertWorld(string[] _words, int _helloCount, int _resultLength)
        {
            string[] result = new string[_resultLength];
            int indexTracker = 0;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _words[i - indexTracker];
                if (result[i] == "hello")
                {
                    i++;
                    result[i] = "world";
                    indexTracker++;
                }
            }

            return result;
        }

        public static string[] InsertWorld(string[] _words)
        {
            int helloCount = CountHellos(_words);
            return InsertWorld(_words, helloCount, _words.Length + helloCount);
        }

        public static void Main()
        {
            string[] words1 = new string[] { "hello", "the", "quick", "brown", "fox", "hello", "something" };
            string[] words2 = InsertWorld(words1);

            Console.WriteLine("{ " + string.Join(", ", words1) + " }");
            Console.WriteLine("\n----------------------\n");
            // { hello, world, the, quick, brown, fox, hello, world, something }
            Console.WriteLine("{ " + string.Join(", ", words2) + " }");
        }
    }
}