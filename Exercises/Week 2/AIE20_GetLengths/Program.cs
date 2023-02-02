namespace AIE20_GetLengths
{
    public static class Program
    {
        public static int[] GetLengths(string[] _words)
        {
            // Create new array
            int[] lengths = new int[_words.Length];

            for (int i = 0; i < _words.Length; i++)
            {
                // Replace the current empty length with the length of this word
                lengths[i] = _words[i].Length;
            }

            return lengths;
        }

        public static void Main()
        {
            string[] words = new string[] { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            int[] lengths = GetLengths(words);

            Console.WriteLine("{");

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"  {words[i]} : {lengths[i]}");
            }

            Console.WriteLine("}");
        }
    }
}