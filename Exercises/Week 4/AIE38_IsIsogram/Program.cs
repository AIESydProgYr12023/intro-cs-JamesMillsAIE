namespace AIE38_IsIsogram
{
    public static class Program
    {
        private static bool IsIsogram(string _word)
        {
            // 1. Convert string to lowercase
            // 2. Loop through the lowercase string
            // 3. Loop through the lowercase string again but the letter next to the index (i + 1)
            // 4. If any are the same, return false, otherwise true

            string lowercase = _word.ToLower();
            for (int i = 0; i < lowercase.Length; i++)
            {
                for (int j = i + 1; j < lowercase.Length; j++)
                {
                    if(lowercase[i] == lowercase[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void Main()
        {
            Console.WriteLine(IsIsogram("Algorism")); // True
            Console.WriteLine(IsIsogram("pasSword")); // False
            Console.WriteLine(IsIsogram("Consecutive")); // False
        }
    }
}