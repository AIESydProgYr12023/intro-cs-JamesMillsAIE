namespace AIE29_ChessBoard
{
    public class PawnChessPiece : ChessPiece
    {
        private bool hasMoved;

        public PawnChessPiece(ChessBoard _board, ChessSide _side, int _row, int _col) 
            : base(_board, _side, ChessPieceType.Pawn, _row, _col)
        {

        }

        public override bool IsValidMove(int _row, int _col)
        {
            ChessPiece targetPiece = board.GetPiece(_row, _col);
            if (targetPiece != null && targetPiece.Side == Side)
                return false;

            if (_row != Row)
                return false;

            int direction = Side == ChessSide.White ? 1 : -1;

            if (hasMoved)
                return Column + direction == _col;

            return Column + direction == _col || Column + direction * 2 == _col;
        }

        public override void OnMove()
        {
            hasMoved = true;
        }
    }
}
