using Raylib_cs;
using System.Numerics;

namespace Platformer
{
    public class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Budget Mario";

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
                Raylib.ClearBackground(Color.SKYBLUE);

                Draw();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
        #endregion

        public List<GameObject> gameObjects = new List<GameObject>();
        public Player player;

        public void Load()
        {
            int crateSize = 50;
            int crateCount = windowWidth / crateSize;
            for (int i = 0; i < crateCount; i++)
            {
                gameObjects.Add(new Crate(new Vector2(crateSize * i, windowHeight - crateSize), crateSize));
            }

            gameObjects.Add(new Crate(new Vector2(crateSize * 3, windowHeight - crateSize * 4), crateSize));

            GameObject goomba = new Enemy(
                new Vector2(windowWidth - 25, windowHeight - crateSize - 25),
                new Vector2(windowWidth - 150, windowWidth - 25));

            gameObjects.Add(goomba);

            player = new Player(windowHeight - crateSize * 2);
            gameObjects.Add(player);
        }

        public void Update(float _deltaTime)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(_deltaTime);
            }

            // Collision loop
            foreach(GameObject gameObject in gameObjects)
            {
                // If the object is the player, ignore this iteration
                if (gameObject == player)
                    continue;

                // If we successfully collided with something, end the loop early
                if (player.TryCollideWith(gameObject))
                    break;
            }
        }

        public void Draw()
        {
            Raylib.DrawFPS(0, 0);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw();
            }
        }

        public void Unload()
        {

        }
    }
}