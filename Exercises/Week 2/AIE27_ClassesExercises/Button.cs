using Raylib_cs;

using System.Numerics;

namespace AIE27_ClassesExercises
{
	public class Button
	{
		public Vector2 pos = new Vector2();
		public Vector2 size = new Vector2();
		public string text;
		public Color color = Color.BLACK;

		public Button(Vector2 _pos, Vector2 _size, string _text)
		{
			pos = _pos;
			size = _size;
			text = _text;
		}

		public void Draw()
		{
			Raylib.DrawRectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y, color);
			Raylib.DrawText(text, (int)pos.X, (int)pos.Y, 10, Color.WHITE);
		}

		public void Update(int _mouseX, int _mouseY)
		{
			float top = pos.Y;
			float bottom = pos.Y + size.Y;
			float right = pos.X + size.X;
			float left = pos.X;

			if (_mouseY > top && _mouseY < bottom && _mouseX > left && _mouseX < right)
			{
				color = Color.BLUE;
			}
			else
			{
				color = Color.BLACK;
			}
		}
	}
}