using Raylib_cs;

namespace RaylibStarter
{
    public class Game
    {
        public int windowWidth = 400;
        public int windowHeight = 400;
        public string windowTitle = "Sorting Visualisation";

        #region Setup

        public Game()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);
        }

        public void Run()
        {
            Load();

            while (!Raylib.WindowShouldClose())
            {
                float dt = Raylib.GetFrameTime();
                Update(dt);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Draw();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
        #endregion

        private int[] values = new int[400];

        public void Load()
        {
            Random random = new Random();

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = random.Next(1, windowHeight);
                Raylib.DrawLine(i, windowHeight, i, windowHeight - values[i], Color.BLACK);
            }
        }

        public void Update(float _deltaTime) { }

        public void Draw()
        {
            for (int i = 0; i < values.Length; i++)
            {
                int keyValue = values[i];
                int j = i - 1;

                if(j >= 0 && values[j] > keyValue)
                {
                    Raylib.DrawLine(keyValue, windowHeight, keyValue, windowHeight - values[keyValue], Color.GREEN);
                    values[j + 1] = values[j];
                    j--;
                }

                values[j + 1] = keyValue;
                Raylib.DrawLine(i, windowHeight, i, windowHeight - values[i], Color.BLACK);
            }
        }

        public void Unload()
        {

        }
    }
}