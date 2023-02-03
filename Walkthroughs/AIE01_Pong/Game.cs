using Raylib_cs;
using System.Numerics;

namespace Pong
{
    public class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Pong";

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
                Raylib.ClearBackground(Color.BLACK);

                Draw();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
        #endregion

        public int lineHeight = 10;
        public int dotCount = 10;
        public int dotWidth = 10;
        public Color backgroundColor = new Color(200, 200, 200, 255);

        public int playerHeight = 75;
        public int playerSpeed = 150;
        public Color player1Color = Color.RED;
        public Color player2Color = Color.BLUE;
        public Paddle player1;
        public Paddle player2;

        public Ball ball;

        public void Load()
        {
            Vector2 playerSize = new Vector2(lineHeight, playerHeight);

            player1 = new Paddle(
                new Vector2(lineHeight, lineHeight),
                playerSize, 
                playerSpeed, 
                player1Color, 
                KeyboardKey.KEY_W, 
                KeyboardKey.KEY_S);

            player2 = new Paddle(
                new Vector2(windowWidth - lineHeight * 2, lineHeight),
                playerSize, 
                playerSpeed, 
                player2Color, 
                KeyboardKey.KEY_UP, 
                KeyboardKey.KEY_DOWN);

            ball = new Ball(lineHeight, (int)(playerSpeed * 1.5f));
        }

        public void CheckBallPlayerCollision(Paddle _paddle, Vector2 _bounceDirection)
        {
            Rectangle playerRect = new Rectangle(_paddle.position.X, _paddle.position.Y, _paddle.size.X, _paddle.size.Y);
            Rectangle ballRect = new Rectangle(ball.position.X, ball.position.Y, ball.size, ball.size);

            if(Raylib.CheckCollisionRecs(playerRect, ballRect))
            {
                ball.direction = _bounceDirection;
            }
        }

        public void CheckBallWallCollision(int _yPos, Vector2 _bounceDirection)
        {
            Rectangle wallRect = new Rectangle(0, _yPos, Raylib.GetScreenWidth(), lineHeight);
            Rectangle ballRect = new Rectangle(ball.position.X, ball.position.Y, ball.size, ball.size);

            if(Raylib.CheckCollisionRecs(wallRect, ballRect))
            {
                ball.direction = _bounceDirection;
            }
        }

        public void Update(float _deltaTime)
        {
            player1.Update(_deltaTime, lineHeight);
            player2.Update(_deltaTime, lineHeight);
            ball.Update(_deltaTime);

            CheckBallPlayerCollision(player1, new Vector2(1, ball.direction.Y));
            CheckBallPlayerCollision(player2, new Vector2(-1, ball.direction.Y));
            CheckBallWallCollision(0, new Vector2(ball.direction.X, 1));
            CheckBallWallCollision(windowHeight - lineHeight, new Vector2(ball.direction.X, -1));
        }

        public void Draw()
        {
            DrawBackground(lineHeight, dotCount, dotCount, backgroundColor);
            player1.Draw();
            player2.Draw();
            ball.Draw();
        }

        public void Unload()
        {

        }

        private void DrawBackground(int _lineHeight, int _dotAmount, int _dotWidth, Color _color)
        {
            Raylib.DrawRectangle(0, 0, windowWidth, _lineHeight, _color);
            Raylib.DrawRectangle(0, windowHeight - _lineHeight, windowWidth, _lineHeight, _color);

            int xPos = windowWidth / 2 - (_dotWidth / 2);
            int startY = _lineHeight;
            int dotHeight = (windowHeight - (_lineHeight * 2)) / (_dotAmount * 2);

            for (int i = 0; i <= _dotAmount; i++)
            {
                int yPos = startY;

                if(i > 0)
                {
                    yPos += dotHeight * (i * 2);
                }

                Raylib.DrawRectangle(xPos, yPos, _dotWidth, dotHeight, _color);
            }
        }
    }
}