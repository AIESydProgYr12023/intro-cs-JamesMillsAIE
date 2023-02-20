using Raylib_cs;
using System.Numerics;

namespace AIE42_TileMapEditor
{
    public class Tile
    {
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            }
        }

        public Color color;
        private Vector2 position;
        private Vector2 size;
        public int index;

        public Tile(Color _color, Vector2 _position, Vector2 _size, int _index)
        {
            color = _color;
            position = _position;
            size = _size;
            index = _index;
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(Bounds, color);
        }

        public bool Contains(Vector2 _point)
        {
            return Raylib.CheckCollisionPointRec(_point, Bounds);
        }
    }
}
