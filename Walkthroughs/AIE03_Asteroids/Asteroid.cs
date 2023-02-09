using System.Numerics;
using Raylib_cs;

namespace AIE03_Asteroids
{
    public class Asteroid : GameObject
    {
        public Vector2 direction;
        private Vector2[] shape;

        public float radius;
        private float max;

        public Asteroid(Spawner _spawner, Vector2 _position, Vector2 _direction) : base(_spawner)
        {
            position = _position;
            direction = _direction;

            float xPow = MathF.Pow(_direction.X, 2);
            float yPow = MathF.Pow(_direction.Y, 2);
            float absPowDiff = MathF.Abs(xPow - yPow);
            float sqrtDir = MathF.Sqrt(absPowDiff);

            rotation = 180f * MathF.Atan(sqrtDir) / MathF.PI;
        }

        public void Generate(int _divisions, float _radius)
        {
            radius = _radius;
            shape = new Vector2[_divisions];

            Random rand = new Random();

            for (int i = 0; i < _divisions; i++)
            {
                float x = rand.NextSingle() * 0.5f + 0.5f;
                float y = rand.NextSingle() * 0.5f + 0.5f;

                Vector2 randV = new Vector2(x, y);
                float randDist = Vector2.Distance(Vector2.Zero, randV);
                max = randDist > max ? randDist : max;

                shape[i] = randV;
            }

            radius *= max;
        }

        public override void Draw()
        {
            RaylibExt.DrawPolyLines(shape, rotation, position.X, position.Y, radius, Color.WHITE);
        }

        public override void Update()
        {
            position += direction;

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
