using Raylib_cs;
using System.Numerics;

namespace AIE42_TileMapEditor
{
    public class Tilemap
    {
        private static readonly Color[] tileColors =
        {
            Color.RED,
            Color.BLUE,
            Color.ORANGE,
            Color.GREEN,
            Color.VIOLET,
            Color.YELLOW,
            Color.BLACK,
            Color.PINK,
            Color.PURPLE,
            Color.MAGENTA
        };

        private int width;
        private int height;

        private float tileWidth;
        private float tileHeight;

        private Tile[,] tiles;

        public Tilemap(int _width, int _height)
        {
            width = _width;
            height = _height;
            tiles = new Tile[width, height];

            tileWidth = Game.WINDOW_WIDTH / (float)width;
            tileHeight = Game.WINDOW_HEIGHT / (float)height;
        }

        private float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public void Generate()
        {
            Random rand = new Random(8192);
            SimplexNoise.Noise.Seed = rand.Next(8192);
            float[,] noise = SimplexNoise.Noise.Calc2D(width, height, 0.05f);
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    int index = (int)Remap(noise[x, y], 0, 256, 0, tileColors.Length);
                    tiles[x, y] = new Tile(tileColors[index], 
                        new Vector2(x * tileWidth, y * tileHeight), 
                        new Vector2(tileWidth, tileHeight), index);
                }
            }
        }

        public void Draw()
        {
            foreach (Tile tile in tiles)
            {
                tile.Draw();
            }
        }

        public void Update()
        {
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    if (tiles[x,y].Contains(Raylib.GetMousePosition()) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        int index = tiles[x,y].index + 1;
                        if (index >= tileColors.Length)
                            index = 0;

                        tiles[x, y].index = index;
                        tiles[x, y].color = tileColors[index];

                        return;
                    }
                }
            }
        }
    }
}
