using Raylib_cs;
using System.Numerics;

namespace Pong
{
    public class Ball
    {
        public Vector2 position;
        public int size;
        public int speed;
        public Color color;
        public Vector2 direction;

        public Ball(int _size, int _speed)
        {
            position = new Vector2(Raylib.GetScreenWidth() / 2 - _size / 2, Raylib.GetScreenHeight() / 2 - _size / 2);
            size = _size;
            speed = _speed;
            color = new Color(74, 65, 42, 255);
            direction = new Vector2(1, -1);
        }

        public void Update(float _deltaTime)
        {
            position.X += speed * _deltaTime * direction.X;
            position.Y += speed * _deltaTime * direction.Y;
        }

        public void Draw()
        {
            Raylib.DrawRectangleV(position, new Vector2(size, size), color);
        }
    }
}
