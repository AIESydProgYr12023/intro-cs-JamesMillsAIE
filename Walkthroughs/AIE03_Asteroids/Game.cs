using Raylib_cs;

namespace AIE03_Asteroids
{
    public class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Raylib Starter";

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

        public void Load()
        {
            // TODO:
            // load game assets here
        }

        public void Update(float _deltaTime)
        {
            // TODO:
            // Add game update logic here - this code will run 60 times per second
        }

        public void Draw()
        {
            // TODO:
            // Add game drawing logic here - this code will run 60 times per second
        }

        public void Unload()
        {

        }
    }
}