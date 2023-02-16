namespace AIE39_ScottishScreaming
{
    public static class Program
    {
        private static string ToScottishScreaming(string _word)
        {
            // 1. Create Vowel Array minus E
            // 2. Loop through the word
            // 3. Loop through the vowel array
            // 4. If vowel is found. Replace with E
            // 5. Return the word as uppercase

            char[] vowels = { 'a', 'i', 'o', 'u' };

            for (int i = 0; i < _word.Length; i++)
            {
                foreach (char vowel in vowels)
                {
                    if (_word[i] == vowel)
                    {
                        _word = _word.Replace(_word[i], 'e');
                    }
                }
            }

            return _word.ToUpper();
        }

        public static void Main()
        {
            Console.WriteLine(ToScottishScreaming("hello world")); // HELLE WERLD
            Console.WriteLine(ToScottishScreaming("Mr. Fox was very naughty.")); // MR. FEX WES VERY NEEGHTY.
            Console.WriteLine(ToScottishScreaming("Butterflies are beautiful.")); // BETTERFLEES ERE BEEETEFEL.
        }
    }
}