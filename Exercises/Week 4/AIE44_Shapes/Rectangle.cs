namespace AIE44_Shapes
{
    public class Rectangle : IShape
    {
        public float width;
        public float height;

        public Rectangle(float _width, float _height)
        {
            width = _width;
            height = _height;
        }

        public float Area()
        {
            return width * height;
        }

        public float[] Sizes()
        {
            return new float[] { width, height };
        }

        public string AsString()
        {
            return $"Rectangle Data:\n   Area: {Area()}";
        }
    }
}
