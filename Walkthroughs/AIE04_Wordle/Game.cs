using Raylib_cs;
using System.Numerics;
using System.Text.RegularExpressions;

namespace RaylibStarter
{
    public class Game
    {
        public const int WINDOW_WIDTH = 500;
        public const int WINDOW_HEIGHT = 700;
        public const string WINDOW_TITLE = "Wordle -ish";

        #region Setup

        public Game()
        {
            Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, WINDOW_TITLE);
            Raylib.SetTargetFPS(10);
        }

        public void Run()
        {
            bool close = false;

            while (!close)
            {
                Load();

                while(!close && !Update(0))
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);

                    Draw();

                    Raylib.EndDrawing();

                    close = Raylib.WindowShouldClose();
                }

                while(!close && !Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);

                    GameOverScreen();

                    Raylib.EndDrawing();

                    close = Raylib.WindowShouldClose();
                }
            }

            Raylib.CloseWindow();
        }
        #endregion

        private const int GRID_SIZE_X = 5;
        private const int GRID_SIZE_Y = 6;

        private const int TITLE_FONT_SIZE = 50;

        private Color[] tileColors = { new(20, 20, 20, 255), new(120, 120, 120, 255), new(200, 180, 85, 255), new(100, 170, 100, 255) };

        private string[] validWords;
        private string[] playableWords;

        private Regex rgx = new("^[A-Z]+$");

        private string word;
        private bool complete;

        private string[,] inputs = new string[GRID_SIZE_Y, GRID_SIZE_X];
        private int[,] colorIndices = new int[GRID_SIZE_Y, GRID_SIZE_X];

        private int letterIndex;

        private static Vector2 offset = new(50, 170);
        private static Vector2 dim = new(400, 400);
        private static Vector2 grid = new(dim.X / GRID_SIZE_X, dim.Y / GRID_SIZE_X);

        public void Load()
        {
            validWords = File.ReadAllLines(@"Files\ValidWords.txt");
            playableWords = File.ReadAllLines(@"Files\PlayableWords.txt");

            complete = false;
            Random random = new Random();
            word = playableWords[random.Next(playableWords.Length)];
            letterIndex = 0;

            // Populates the Wordle Grid with the blank grey color index
            for (int x = 0; x < GRID_SIZE_X; x++)
            {
                for (int y = 0; y < GRID_SIZE_Y; y++)
                {
                    colorIndices[y, x] = 0;
                    inputs[y, x] = "";
                }
            }
        }

        public bool Update(float _deltaTime)
        {
            string key = Convert.ToString((char)Raylib.GetKeyPressed());

            if (rgx.IsMatch(key) && letterIndex < GRID_SIZE_X * GRID_SIZE_Y)
            {
                inputs[letterIndex / (GRID_SIZE_Y - 1), letterIndex % GRID_SIZE_X] = key.ToLower();
                letterIndex++;
            }

            if(letterIndex % GRID_SIZE_X == 0 && letterIndex > 0)
            {
                string result = "";
                for (int i = 0; i < GRID_SIZE_X; i++)
                {
                    result += inputs[(letterIndex / (GRID_SIZE_Y - 1)) - 1, i];
                }

                if(validWords.Contains(result))
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        colorIndices[(letterIndex / (GRID_SIZE_Y - 1)) - 1, i] = 
                            (word.Contains(result[i])) ? 2 : 1;

                        colorIndices[(letterIndex / (GRID_SIZE_Y - 1)) - 1, i] =
                            (word[i] == result[i]) ? 3 : colorIndices[letterIndex / GRID_SIZE_X - 1, i];
                    }

                    complete = true;
                    for (int i = 0; i < GRID_SIZE_X; i++)
                    {
                        // complete = complete && some_other_bool
                        complete &= colorIndices[letterIndex / (GRID_SIZE_Y - 1) - 1, i] == 3;
                    }

                    if(complete)
                    {
                        return true;
                    }
                }
                else
                {
                    for (int i = 0; i < GRID_SIZE_X; i++)
                    {
                        inputs[letterIndex / (GRID_SIZE_Y - 1) - 1, i] = "";
                    }

                    letterIndex -= GRID_SIZE_X;
                }
            }

            if(letterIndex > GRID_SIZE_X * GRID_SIZE_Y - 1)
            {
                complete = false;
                return true;
            }

            return false;
        }

        public void Draw()
        {
            Vector2 screenDimText = Raylib.MeasureTextEx(Raylib.GetFontDefault(), WINDOW_TITLE, TITLE_FONT_SIZE, 0f);

            Raylib.DrawText(
                WINDOW_TITLE,
                (int)((WINDOW_WIDTH * 0.5f) - (screenDimText.X * 0.6f)),
                (int)((WINDOW_HEIGHT * 0.1f) - (screenDimText.Y * 0.5f)),
                TITLE_FONT_SIZE,
                Color.RAYWHITE);

            for (int x = 0; x < GRID_SIZE_X; x++)
            {
                for (int y = 0; y < GRID_SIZE_Y; y++)
                {
                    Raylib.DrawRectangle(
                        x * (int)grid.X + (int)offset.X + (int)dim.X / 200,
                        y * (int)grid.Y + (int)offset.Y + (int)dim.Y / 200,
                        (int)grid.X - (int)dim.X / 100,
                        (int)grid.X - (int)dim.X / 100,
                        tileColors[colorIndices[y, x]]);

                    Vector2 gridTextDim = Raylib.MeasureTextEx(Raylib.GetFontDefault(), inputs[y, x], 40, 0f);

                    Raylib.DrawText(
                        inputs[y, x].ToUpper(),
                        (int)(x * grid.X + offset.X + (dim.X * 0.005f) + (grid.X - gridTextDim.X) * 0.5f),
                        (int)(y * grid.Y + offset.Y + (dim.Y * 0.005f) + (grid.Y - gridTextDim.Y) * 0.5f),
                        40,
                        Color.RAYWHITE);
                }
            }
        }

        public void GameOverScreen()
        {
            Draw();

            string endLine = complete ?
                $"Well done , you got it in {letterIndex / GRID_SIZE_X} turns!\nPress ENTER to play again." :
                $"Unlucky, the word was {word}.\nPress ENTER to play again.";

            Vector2 endTextDim = Raylib.MeasureTextEx(Raylib.GetFontDefault(), WINDOW_TITLE, TITLE_FONT_SIZE / 2, 0f);
            Raylib.DrawText(
                endLine,
                (int)((WINDOW_WIDTH * 0.35f) - endTextDim.X),
                (int)((WINDOW_HEIGHT * 0.15f) - (endTextDim.Y * 0.5f)),
                TITLE_FONT_SIZE / 2,
                complete ? Raylib.ColorFromHSV(Raylib.GetRandomValue(0, 360), 1, 1) : Color.RED);
        }
    }
}