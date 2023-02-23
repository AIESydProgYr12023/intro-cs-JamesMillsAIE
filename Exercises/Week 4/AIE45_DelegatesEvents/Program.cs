namespace AIE45_DelegatesEvents
{
    public static class Program
    {
        public static void OnClickedSpace(Button _button)
        {
            Console.WriteLine("Space was clicked!");
        }

        public static void Main()
        {
            Button quitButton = new Button(ConsoleKey.Escape, (char)27);
            Button spaceButton = new Button(ConsoleKey.Spacebar, ' ');

            spaceButton.RegisterClickCallback(OnClickedSpace);

            bool quit = false;

            quitButton.RegisterClickCallback((_button) =>
            {
                quit = true;
            });

            while(!quit)
            {
                quitButton.Update();
                spaceButton.Update();
            }
        }
    }
}