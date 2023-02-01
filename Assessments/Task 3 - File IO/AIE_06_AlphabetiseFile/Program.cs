namespace AIE_06_AlphabetiseFile
{
    public static class Program
    {
        public static string[] LoadWords(string _filename)
        {
            return new string[1];
        }

        public static string[] SortWords(string[] _words)
        {
            return new string[1];
        }

        public static void SaveWords(string _filename, string[] _words)
        {
            
        }

        private static void Main()
        {
            string[] words = LoadWords("words.txt");
            string[] sortedWords = SortWords(words);
            SaveWords("Output.txt", sortedWords);
        }
    }
}