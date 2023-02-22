namespace AIE44_Shapes
{
    public class Box : IShape, IShape3D
    {
        public float width;
        public float height;
        public float depth;

        public Box(float _width, float _height, float _depth)
        {
            width = _width;
            height = _height;
            depth = _depth;
        }

        public float Area()
        {
            return 2 * (width * depth + height * depth + height * width);
        }

        public string AsString()
        {
            return $"Box Data:\n   Surface Area: {Area()}\n   Volume: {Volume()}\n   Sizes: {width}w x {height}h x {depth}d";
        }

        public float[] Sizes()
        {
            return new float[] { width, height, depth };
        }

        public float Volume()
        {
            return width * height * depth;
        }
    }
}
