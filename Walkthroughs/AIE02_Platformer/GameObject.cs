using Raylib_cs;
using System.Numerics;

namespace Platformer
{
    public class GameObject
    {
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(position.X, position.Y, size.X, size.Y);
            }
        }

        public Vector2 Position => position;
        public Vector2 Size => size;
        public Color Color { get; protected set; }

        protected Vector2 position;
        protected Vector2 size;

        protected GameObject(Vector2 _position, Vector2 _size, Color _color)
        {
            position = _position;
            size = _size;
            Color = _color;
        }

        public virtual void Update(float _deltaTime)
        {

        }

        public virtual void Draw()
        {
            Raylib.DrawRectangleRec(Rectangle, Color);
        }
    }
}
