using Raylib_cs;

using System.Numerics;

namespace AIE27_ClassesExercises
{
    public class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Class Exercises";

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

        private Sprite[] boxSprites;
        private Texture2D boxTexture;
        private Button button;

        public void Load()
        {
            boxTexture = Raylib.LoadTexture("./Assets/crate.png");

            button = new Button(new Vector2(200, 10), new Vector2(120, 45), "test");

            boxSprites = new Sprite[3];

            boxSprites[0] = new Sprite(boxTexture, new Vector2(400, 200), new Vector2(128, 128));
            boxSprites[0].rotationSpeed = 1;
            boxSprites[1] = new Sprite(boxTexture, new Vector2(200, 200), new Vector2(128, 128));
            boxSprites[1].rotationSpeed = 2;
            boxSprites[2] = new Sprite(boxTexture, new Vector2(600, 200), new Vector2(128, 128));
            boxSprites[2].rotationSpeed = 3;
        }

        public void Update(float _deltaTime)
        {
            foreach (Sprite box in boxSprites)
            {
                box.Update();
            }

            Vector2 mousePos = Raylib.GetMousePosition();
            button.Update((int)mousePos.X, (int)mousePos.Y);
        }

        public void Draw()
        {
            foreach (Sprite box in boxSprites)
            {
                box.Draw();
            }

            button.Draw();
        }

        public void Unload()
        {
            Raylib.UnloadTexture(boxTexture);
        }
    }
}
