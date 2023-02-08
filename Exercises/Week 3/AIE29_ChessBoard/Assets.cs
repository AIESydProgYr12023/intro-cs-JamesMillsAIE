using Raylib_cs;

namespace AIE29_ChessBoard
{
    public static class Assets
    {
        private static Texture2D chessPieceTexture;
        private static Dictionary<ChessSide, Dictionary<ChessPieceType, Rectangle>> chessPieceSrcRects 
            = new Dictionary<ChessSide, Dictionary<ChessPieceType, Rectangle>>();

        private static int spriteWidth;
        private static int spriteHeight;

        public static void Load()
        {
            chessPieceTexture = Raylib.LoadTexture("./Assets/chess_pieces.png");

            spriteWidth = chessPieceTexture.width / 6;
            spriteHeight = chessPieceTexture.height / 2;

            foreach (ChessPieceType piece in Enum.GetValues<ChessPieceType>())
            {
                foreach (ChessSide side in Enum.GetValues<ChessSide>())
                {
                    CreateSrcRect(side, piece);
                }
            }
        }

        public static Texture2D GetChessPieceTexture()
        {
            return chessPieceTexture;
        }

        public static Rectangle GetSrcRect(ChessSide _side, ChessPieceType _type)
        {
            if(chessPieceSrcRects.ContainsKey(_side))
            {
                if(chessPieceSrcRects[_side].ContainsKey(_type))
                {
                    return chessPieceSrcRects[_side][_type];
                }
            }

            return new Rectangle();
        }

        public static void Unload()
        {
            Raylib.UnloadTexture(chessPieceTexture);

            chessPieceSrcRects.Clear();
        }

        private static void CreateSrcRect(ChessSide _side, ChessPieceType _piece)
        {
            if (!chessPieceSrcRects.ContainsKey(_side))
                chessPieceSrcRects.Add(_side, new Dictionary<ChessPieceType, Rectangle>());

            int yOffset = (int)_side;
            int xOffset = (int)_piece;

            chessPieceSrcRects[_side].Add(_piece,
                new Rectangle(xOffset * spriteWidth, yOffset * spriteHeight,
                    spriteWidth, spriteHeight));
        }
    }
}
