using Raylib_cs;
using System.Numerics;

namespace Platformer
{
    public class Crate : GameObject
    {
        private Texture2D texture;

        public Crate(Vector2 _position, int _size) : base(_position, new Vector2(_size, _size), Color.WHITE)
        {
            texture = Raylib.LoadTexture("Assets/crate.png");
        }

        public override void Draw()
        {
            RaylibExt.DrawTexture(texture, position.X, position.Y, size.X, size.Y, Color);
        }
    }
}
