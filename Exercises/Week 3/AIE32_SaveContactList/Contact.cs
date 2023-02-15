namespace AIE32_SaveContactList
{
	public class Contact
	{
		public string name = "";
		public string email = "";
		public string phone = "";

		public Contact() { }

		public Contact(string _name, string _email, string _phone)
		{
			name = _name;
			email = _email;
			phone = _phone;
		}

		public void Print()
		{
			Console.WriteLine($"{name} {email} {phone}");
		}
	}
}
