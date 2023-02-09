using System.Numerics;

namespace AIE03_Asteroids
{
    public abstract class GameObject
    {
        public Vector2 Forward
        {
            get
            {
                // convert rotation in degrees to rotation in radians
                float radians = (MathF.PI / 180f) * rotation;
                // Calculate the forward vector by using Cos for X, and Sin for Y
                return new Vector2(MathF.Cos(radians), MathF.Sin(radians));
            }
        }

        public Vector2 position;
        protected float rotation;
        protected Spawner spawner;

        protected GameObject(Spawner _spawner)
        {
            spawner = _spawner;
        }

        public abstract void Update();

        public abstract void Draw();
    }
}
