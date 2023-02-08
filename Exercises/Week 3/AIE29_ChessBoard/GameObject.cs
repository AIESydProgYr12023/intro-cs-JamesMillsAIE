using Raylib_cs;
using System.Numerics;

namespace AIE29_ChessBoard
{
    public abstract class GameObject
    {
        public Vector2 position;

        protected GameObject(Vector2 _position)
        {
            position = _position;
        }

        public abstract void Draw();
    }
}
