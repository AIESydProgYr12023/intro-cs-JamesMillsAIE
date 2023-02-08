namespace AIE28_FeedAnimals
{
    public class Animal
    {
        public string name;

        protected Animal(string _name)
        {
            name = _name;
        }

        public virtual void EatFood()
        {
            MakeNoise();
        }

        protected virtual void MakeNoise()
        {
            Console.WriteLine($"{name}: makes noise.");
        }
    }
}
