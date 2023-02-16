namespace AIE05_Hangman
{
    public class WordManager
    {
        private readonly string[] words =
        {
            "hello",
            "goodbye",
            "welcome",
            "factory",
            "powerstation",
            "photosynthesis",
            "hippopotomonstrosesquipedaliophobia"
        };

        public string EncryptedWord { get { return encrypted; } }

        private List<char> guesses = new List<char>();
        private string hiddenWord = "";
        private string encrypted = "";

        public void GenerateWord()
        {
            Random random = new Random();
            hiddenWord = words[random.Next(words.Length)];

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                encrypted += '_';
            }
        }

        public bool CheckComplete()
        {
            return encrypted == hiddenWord;
        }

        public void UpdateEncrypted(char _letter)
        {
            encrypted = "";
            if(!guesses.Contains(_letter))
                guesses.Add(_letter);

            foreach (char letter in hiddenWord)
            {
                encrypted += guesses.Contains(letter) ? letter : '_';
            }
        }
    }
}
