using Raylib_cs;

namespace AIE42_TileMapEditor
{
    public class Game
    {
        public const int WINDOW_WIDTH = 400;
        public const int WINDOW_HEIGHT = 400;
        public const string WINDOW_TITLE = "Tile Map Editor";

        private const int TILEMAP_WIDTH = 32;
        private const int TILEMAP_HEIGHT = 32;

        #region Setup

        public Game()
        {
            Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, WINDOW_TITLE);
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

        private Tilemap tilemap;

        public void Load()
        {
            tilemap = new Tilemap(TILEMAP_WIDTH, TILEMAP_HEIGHT);
            tilemap.Generate();
        }

        public void Update(float _deltaTime)
        {
            tilemap.Update();
        }

        public void Draw()
        {
            tilemap.Draw();
        }

        public void Unload()
        {

        }
    }
}