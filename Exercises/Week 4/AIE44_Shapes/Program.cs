namespace AIE44_Shapes
{
    public static class Program
    {
        public static void Main()
        {
            List<IShape> shapes = new List<IShape>();
            shapes.Add(new Rectangle(5f, 1f));
            shapes.Add(new Circle(1000f));
            shapes.Add(new Box(100f, 100f, 100f));

            foreach(IShape shape in shapes)
            {
                Console.WriteLine(shape.AsString());
            }
        }
    }
}