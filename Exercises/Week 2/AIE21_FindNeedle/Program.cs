namespace AIE21_FindNeedle
{
    public static class Program
    {
        public static int FindNeedle(string[] _words)
        {
            for (int i = 0; i < _words.Length; i++)
            {
                if (_words[i] == "needle")
                {
                    return i;
                }
            }

            return -1;
        }

        public static void Main()
        {
            string[] strings = new string[] { "hay", "junk", "hay", "hay", "moreJunk", "needle", "randomJunk" };
            int needleIndex = FindNeedle(strings);

            Console.WriteLine($"Found needle at {needleIndex}");
        }
    }
}