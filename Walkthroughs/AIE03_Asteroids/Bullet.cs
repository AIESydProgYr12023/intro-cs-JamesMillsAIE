using Raylib_cs;
using System.Numerics;

namespace AIE03_Asteroids
{
    public class Bullet : GameObject
    {
        private Vector2 direction;
        private float speed = 10f;

        public Bullet(Spawner _spawner, Vector2 _position, Vector2 _direction) : base(_spawner)
        {
            position = _position;
            direction = _direction;
        }

        public override void Draw()
        {
            Raylib.DrawLineV(position, position - direction * speed, Color.WHITE);
        }

        public override void Update()
        {
            position += direction * speed;

            if (position.X < 0)
                position.X = Game.WINDOW_WIDTH;

            if (position.X > Game.WINDOW_WIDTH)
                position.X = 0;

            if (position.Y < 0)
                position.Y = Game.WINDOW_HEIGHT;

            if (position.Y > Game.WINDOW_HEIGHT)
                position.Y = 0;
        }
    }
}
