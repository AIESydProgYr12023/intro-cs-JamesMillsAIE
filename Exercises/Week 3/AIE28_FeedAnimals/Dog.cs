namespace AIE28_FeedAnimals
{
    public class Dog : Animal
    {
        public Dog() : base("Dog") { }

        public Dog(string _name) : base(_name) { }

        protected override void MakeNoise()
        {
            Console.WriteLine("WOOF WOOF WOOF This is dog");
        }
    }
}
