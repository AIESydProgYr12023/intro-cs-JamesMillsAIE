using System.Numerics;

namespace Raylib_cs
{
    public static class RaylibExt
    {
        public static void DrawTexture(Texture2D _texture, float _xPos, float _yPos, float _width, float _height, Color _color,
            float _rotation = 0.0f, float _xOrigin = 0.0f, float _yOrigin = 0.0f)
        {
            Rectangle dst = new Rectangle(_xPos, _yPos, _width, _height);
            Rectangle src = new Rectangle(0, 0, _texture.width, _texture.height);
            Vector2 origin = new Vector2(_xOrigin * _width, _yOrigin * _height);
            Raylib.DrawTexturePro(_texture, src, dst, origin, _rotation, _color);
        }

        public static void DrawPolyLines(Vector2[] pointRatios, float rotation, float xPos, float yPos, float radius, Color color)
        {
            // Assigns preliminary variables
            int divisions = pointRatios.Length;
            Vector2[] points = new Vector2[divisions];

            // Iterates over the Polygons n amount of vertcies, generating a unit circle from the pre-calculated angle and array of offsets
            for (int i = 0, index = 0; index < divisions; i += 360 / divisions, index = i / (360 / divisions))
            {
                var x = MathF.Cos((i + rotation) * MathF.PI / 180) * radius;
                var y = MathF.Sin((i + rotation) * MathF.PI / 180) * radius;

                points[index] = new Vector2(xPos + x * pointRatios[index].X, yPos + y * pointRatios[index].Y);
            }

            for (int i = 0; i < divisions - 1; i++)
            {
                Raylib.DrawLine((int)(points[i].X), (int)(points[i].Y), (int)(points[i + 1].X), (int)(points[i + 1].Y), color);
            }

            Raylib.DrawLine((int)(points[points.Length - 1].X), (int)(points[points.Length - 1].Y), (int)(points[0].X), (int)(points[0].Y), color);
        }
    }
}