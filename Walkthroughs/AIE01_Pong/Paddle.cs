using Raylib_cs;
using System.Numerics;

namespace Pong
{
    public class Paddle
    {
        public Vector2 position;
        public Vector2 size;
        public int speed;
        public Color color;
        public KeyboardKey up;
        public KeyboardKey down;

        public Paddle(Vector2 _position, Vector2 _size, int _speed, Color _color, KeyboardKey _up, KeyboardKey _down)
        {
            position = _position;
            size = _size;
            speed = _speed;
            color = _color;
            up = _up;
            down = _down;
        }

        public void Update(float _deltaTime, int _lineHeight)
        {
            if (Raylib.IsKeyDown(up))
                position.Y -= speed * _deltaTime;

            if (Raylib.IsKeyDown(down))
                position.Y += speed * _deltaTime;

            if (position.Y < _lineHeight)
                position.Y = _lineHeight;

            if (position.Y > Raylib.GetScreenHeight() - _lineHeight - size.Y)
                position.Y = Raylib.GetScreenHeight() - _lineHeight - size.Y;
        }

        public void Draw()
        {
            Raylib.DrawRectangleV(position, size, color);
        }
    }
}
