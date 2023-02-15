namespace AIE31_SaveContact
{
	public static class Program
	{
		private static void Main()
		{
			Contact person1 = new Contact("bob", "bob@email.com", "123456789");
			Contact person2 = new Contact("fred", "fred@email.com", "123456789");
			Contact person3 = new Contact("ted", "ted@email.com", "123456789");

			//Write each contact to a file
			person1.Serialize("./contacts/bob.txt");
			person2.Serialize("./contacts/fred.txt");
			person3.Serialize("./contacts/ted.txt");

			//Clear out the "contact" and load it back in from the file
			person1 = new Contact();
			person2 = new Contact();
			person3 = new Contact();

			person1.DeSerialize("./contacts/bob.txt");
			person2.DeSerialize("./contacts/fred.txt");
			person3.DeSerialize("./contacts/ted.txt");

			person1.Print();
			person2.Print();
			person3.Print();
		}
	}
}