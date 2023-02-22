namespace AIE44_Shapes
{
    public class Circle : IShape
    {
        public float radius;

        public Circle(float _radius)
        {
            radius = _radius;
        }

        public float Area()
        {
            return MathF.PI * MathF.Pow(radius, 2);
        }

        public float[] Sizes()
        {
            return new float[] { radius };
        }

        public string AsString()
        {
            return $"Circle Data\n   Area: {Area()}\n   Radius: {radius}";
        }
    }
}
