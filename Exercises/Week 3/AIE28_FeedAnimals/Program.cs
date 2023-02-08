namespace AIE28_FeedAnimals
{
    public static class Program
    {
        public static void Main()
        {
            /*Animal dog = new Dog();
            Animal doggo = new Dog("Doggo");
            Animal cat = new Cat();*/

            Person bob = new Person("Bob");

            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog());
            animals.Add(new Dog("Doggo"));
            animals.Add(new Cat());

            Console.WriteLine("---------------------");

            foreach (Animal animal in animals)
            {
                bob.FeedAnimal(animal);
            }
            /*bob.FeedAnimal(dog);
            bob.FeedAnimal(doggo);
            bob.FeedAnimal(cat);*/

            Console.WriteLine("---------------------");
        }
    }
}