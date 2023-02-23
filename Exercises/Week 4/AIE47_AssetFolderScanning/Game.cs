using Raylib_cs;

namespace AIE47_AssetFolderScanning
{
    public class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Asset Folder Scanning";

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
            Assets.Load();
        }

        public void Update(float _deltaTime)
        {
            // TODO:
            // Add game update logic here - this code will run 60 times per second
        }

        public void Draw()
        {
            Raylib.DrawTexture(Assets.Find("Textures/crate"), 0, 0, Color.WHITE);
            Raylib.DrawTexture(Assets.Find("Textures/Characters/goomba"), 0, 0, Color.WHITE);
        }

        public void Unload()
        {
            Assets.Unload();
        }
    }
}