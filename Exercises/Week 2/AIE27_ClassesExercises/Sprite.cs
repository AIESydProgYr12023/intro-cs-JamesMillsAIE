using Raylib_cs;

using System.Numerics;

namespace AIE27_ClassesExercises
{
	public class Sprite
	{
		public Vector2 position;
		public Vector2 size = new Vector2(1, 1);
		public Vector2 origin = new Vector2(0.5f, 0.5f);
		public float rotation;
		public Color color = Color.WHITE;
		public Texture2D texture;

		public float rotationSpeed = 0.0f;

		public Sprite(Texture2D _texture, Vector2 _position, Vector2 _size)
		{
			texture = _texture;
			position = _position;
			size = _size;
		}

		public void Update()
		{
			rotation += rotationSpeed;
		}

		public void Draw()
		{
			RaylibExt.DrawTexture(texture,
				position.X, position.Y,
				size.X, size.Y,
				color, rotation,
				origin.X, origin.Y);
		}
	}
}
