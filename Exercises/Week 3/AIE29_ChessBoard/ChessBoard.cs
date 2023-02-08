using Raylib_cs;
using System.Numerics;

namespace AIE29_ChessBoard
{
    public class ChessBoard : GameObject
    {
        public const float TILE_SIZE = 42;
        public const int GRID_SIZE = 8;

        private Dictionary<ChessSide, Color> sideColors = new Dictionary<ChessSide, Color>()
        {
            { ChessSide.White, new Color(254, 205, 158, 255) },
            { ChessSide.Black, new Color(208, 139, 69, 255) }
        };

        private ChessPiece[,] board = new ChessPiece[GRID_SIZE, GRID_SIZE];

        private ChessPiece selected;

        public ChessBoard() : base(new Vector2(24, 24))
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                board[i, 1] = new PawnChessPiece(this, ChessSide.White, i, 1);
            }

            for (int i = 0; i < GRID_SIZE; i++)
            {
                board[i, 6] = new PawnChessPiece(this, ChessSide.Black, i, 6);
            }
        }

        public void SelectTile(int _row, int _col)
        {
            ChessPiece piece = GetPiece(_row, _col);
            selected = piece;
        }

        public void SetBoardPiece(int _row, int _col, ChessPiece _piece)
        {
            if (_row < 0 || _col < 0 || _row >= GRID_SIZE || _col >= GRID_SIZE)
                return;

            board[_row, _col] = _piece;
        }

        public ChessPiece GetPiece(int _row, int _col)
        {
            if (_row < 0 || _col < 0 || _row >= GRID_SIZE || _col >= GRID_SIZE)
                return null;

            return board[_row, _col];
        }

        public ChessPiece GetSelectedPiece()
        {
            return selected;
        }

        public override void Draw()
        {
            int xPos = (int)position.X;
            int yPos = (int)position.Y;
            int ts = (int)TILE_SIZE;

            for (int y = 0; y < GRID_SIZE; y++)
            {
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    // cond ? true : false
                    // ? = if
                    // : = else
                    // ternary operator
                    Color color =
                        (y % 2 == 0 ?
                            // y is even        x is even                 x is odd
                            (x % 2 == 0 ? sideColors[ChessSide.White] : sideColors[ChessSide.Black]) :
                            // y is odd         x is even                 x is odd
                            (x % 2 == 0 ? sideColors[ChessSide.Black] : sideColors[ChessSide.White])
                        );

                    int cellX = xPos + x * ts;
                    int cellY = yPos + y * ts;
                    Raylib.DrawRectangle(cellX, cellY, ts, ts, color);
                }
            }

            DrawPieces();
            DrawSelectedPiece();
        }

        private void DrawPieces()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == null)
                        continue;

                    board[i, j].Draw();
                }
            }
        }

        private void DrawSelectedPiece()
        {
            if (selected == null)
                return;

            float xPos = position.X + selected.Row * TILE_SIZE;
            float yPos = position.Y + selected.Column * TILE_SIZE;

            Raylib.DrawRectangleLinesEx(new Rectangle(xPos, yPos, TILE_SIZE, TILE_SIZE), 3, Color.BLACK);

            for (int y = 0; y < GRID_SIZE; y++)
            {
                for(int x = 0; x < GRID_SIZE; x++)
                {
                    if(selected.IsValidMove(x, y))
                    {
                        xPos = position.X + x * TILE_SIZE + (TILE_SIZE / 2f);
                        yPos = position.Y + y * TILE_SIZE + (TILE_SIZE / 2f);
                        Raylib.DrawCircle((int)xPos, (int)yPos, 4, Color.BLACK);
                    }
                }
            }
        }
    }
}
