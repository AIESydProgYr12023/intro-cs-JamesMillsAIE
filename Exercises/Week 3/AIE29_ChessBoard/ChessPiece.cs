using Raylib_cs;
using System.Numerics;

namespace AIE29_ChessBoard
{
    public abstract class ChessPiece : GameObject
    {
        public ChessSide Side { get; private set; }
        public ChessPieceType Type { get; private set; }

        public int Row { get; private set; }
        public int Column { get; private set; }

        protected ChessBoard board;

        public ChessPiece(ChessBoard _board, ChessSide _side, ChessPieceType _piece, int _row, int _col) 
            : base(Vector2.Zero)
        {
            board = _board;
            Side = _side;
            Type = _piece;
            Row = _row;
            Column = _col;

            float xPos = _row * ChessBoard.TILE_SIZE + _board.position.X;
            float yPos = _col * ChessBoard.TILE_SIZE + _board.position.Y;

            position = new Vector2(xPos, yPos);
        }

        public abstract bool IsValidMove(int _row, int _col);

        public virtual void OnMove() { }

        public void MoveTo(int _row, int _col)
        {
            board.SetBoardPiece(Row, Column, null);
            Row = _row;
            Column = _col;
            board.SetBoardPiece(Row, Column, this);

            OnMove();
        }

        public override void Draw()
        {
            position.X = Row * ChessBoard.TILE_SIZE + board.position.X;
            position.Y = Column * ChessBoard.TILE_SIZE + board.position.Y;

            Rectangle src = Assets.GetSrcRect(Side, Type);
            Rectangle dst = new Rectangle(position.X, position.Y, ChessBoard.TILE_SIZE, ChessBoard.TILE_SIZE);

            Raylib.DrawTexturePro(Assets.GetChessPieceTexture(), src, dst, Vector2.Zero, 0, Color.WHITE);
        }
    }
}
