namespace AIE28_FeedAnimals
{
    public class Person
    {
        public string name;

        public Person(string _name)
        {
            name = _name;
        }

        public void FeedAnimal(Animal _animal)
        {
            Console.WriteLine($"{name} is feeding: {_animal.name}");
            _animal.EatFood();
        }
    }
}
