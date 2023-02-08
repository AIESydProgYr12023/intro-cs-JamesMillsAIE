using Raylib_cs;
using System.Numerics;

namespace AIE29_ChessBoard
{
    public class Game
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Chess";

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

        private ChessBoard chessBoard;

        public void Load()
        {
            Assets.Load();

            chessBoard = new ChessBoard();
        }

        public void Update(float _deltaTime)
        {
            if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                Vector2 mousePos = Raylib.GetMousePosition();
                int mouseXIndex = (int)((mousePos.X - chessBoard.position.X) / ChessBoard.TILE_SIZE);
                int mouseYIndex = (int)((mousePos.Y - chessBoard.position.Y) / ChessBoard.TILE_SIZE);

                if (mouseXIndex >= ChessBoard.GRID_SIZE || mouseYIndex >= ChessBoard.GRID_SIZE)
                    return;

                ChessPiece selected = chessBoard.GetSelectedPiece();
                if (selected != null && selected.IsValidMove(mouseXIndex, mouseYIndex))
                {
                    // Move the position
                    selected.MoveTo(mouseXIndex, mouseYIndex);
                }
                else
                {
                    chessBoard.SelectTile(mouseXIndex, mouseYIndex);
                }
            }
        }

        public void Draw()
        {
            chessBoard.Draw();
        }

        public void Unload()
        {
            Assets.Unload();
        }
    }
}