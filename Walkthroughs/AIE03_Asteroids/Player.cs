using Raylib_cs;
using System.Numerics;

namespace AIE03_Asteroids
{
    public class Player : GameObject
    {
        private Vector2 size;

        private float rotationSpeed = 5.0f;

        private float accelerationSpeed = 0.1f;
        private Vector2 velocity;

        public Player(Spawner _spawner, Vector2 _position, Vector2 _size) : base(_spawner)
        {
            position = _position;
            size = _size;
        }

        public override void Draw()
        {
            Texture2D texture = Assets.ship;

            RaylibExt.DrawTexture(texture, position.X, position.Y, size.X, size.Y, Color.WHITE, rotation, 0.5f, 0.5f);
        }

        public override void Update()
        {
            rotation = -180f * MathF.Atan2(
                Raylib.GetMouseX() - position.X,
                Raylib.GetMouseY() - position.Y) / MathF.PI + 90;

            if(Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                velocity += Forward * accelerationSpeed;
            }

            if(Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                velocity -= Forward * accelerationSpeed;
            }

            if (position.X < 0)
                position.X = Game.WINDOW_WIDTH;

            if (position.X > Game.WINDOW_WIDTH)
                position.X = 0;

            if (position.Y < 0)
                position.Y = Game.WINDOW_HEIGHT;

            if (position.Y > Game.WINDOW_HEIGHT)
                position.Y = 0;

            position += velocity;

            if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                spawner.SpawnBullet(position, Forward);
            }
        }
    }
}
