namespace AIE05_Hangman
{
    public class Hangman
    {
        private WordManager? wordManager = null;

        public void Run()
        {
            Load();

            if(wordManager == null)
            {
                Console.WriteLine("Word Manager is null!");
                return;
            }

            while(!wordManager.CheckComplete())
            {
                Draw();
                Check();
            }

            Draw();
            Console.WriteLine("Correct! You won!");
        }

        private void Load()
        {
            wordManager = new WordManager();
            wordManager.GenerateWord();
        }

        private void Draw()
        {
            Console.Clear();

            Console.WriteLine("Hangman");
            Console.WriteLine("------------------------");
            Console.WriteLine("Word:");
            Console.WriteLine($"\t{wordManager!.EncryptedWord}");
            Console.WriteLine("------------------------");
        }

        private void Check()
        {
            string? line = Console.ReadLine();

            if (line != null && line.Length == 1 && char.TryParse(line, out char letter))
            {
                wordManager!.UpdateEncrypted(letter);
            }
        }
    }
}
