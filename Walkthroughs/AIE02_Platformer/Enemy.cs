using System.Numerics;
using Raylib_cs;

namespace Platformer
{
    public class Enemy : GameObject
    {
        private Texture2D texture;

        private int speed;
        private Vector2 positionRange;

        public Enemy(Vector2 _position, Vector2 _positionRange) : base(_position, new Vector2(25, 25), Color.WHITE)
        {
            texture = Raylib.LoadTexture("Assets/goomba.png");

            speed = 100;
            positionRange = _positionRange;
        }

        public override void Update(float _deltaTime)
        {
            position.X += speed * _deltaTime;

            if (!(position.X > positionRange.X && position.X < positionRange.Y))
                speed *= -1;
        }

        public override void Draw()
        {
            RaylibExt.DrawTexture(texture, position.X, position.Y, size.X, size.Y, Color);
        }
    }
}
