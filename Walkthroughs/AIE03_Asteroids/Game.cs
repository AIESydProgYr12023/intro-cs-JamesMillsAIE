using Raylib_cs;

namespace AIE03_Asteroids
{
    public class Game
    {
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 800;
        public const string WINDOW_TITLE = "Asteroids";

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
                Raylib.ClearBackground(Color.BLACK);

                Draw();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
        #endregion

        public List<GameObject> gameObjects = new List<GameObject>();

        private Spawner spawner;

        public void Load()
        {
            Assets.Load();

            spawner = new Spawner(this);
            spawner.Load();
        }

        public void Update(float _deltaTime)
        {
            spawner.Update(_deltaTime);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                gameObject.Update();
            }
        }

        public void Draw()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw();
            }
        }

        public void Unload()
        {
            Assets.Unload();
        }
    }
}