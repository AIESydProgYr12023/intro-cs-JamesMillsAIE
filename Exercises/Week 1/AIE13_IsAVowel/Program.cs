namespace AIE13_IsAVowel
{
    public static class Program
    {
        public static bool IsAVowel(char _letter)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            foreach (char vowel in vowels)
            {
                if(char.ToLower(_letter) == vowel)
                {
                    return true;
                }
            }

            return false;
        }

        public static void Main()
        {
            Console.WriteLine(IsAVowel('a'));
            Console.WriteLine(IsAVowel('b'));
            Console.WriteLine(IsAVowel('A'));
        }
    }
}