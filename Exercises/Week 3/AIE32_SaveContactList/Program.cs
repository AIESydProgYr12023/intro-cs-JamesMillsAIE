using System.IO;

namespace AIE32_SaveContactList
{
	public static class Program
	{
		private static void Main(string[] _args)
		{
			List<Contact> contacts = new List<Contact>();
			contacts.Add(new Contact("bob", "bob@email.com", "123456789"));
			contacts.Add(new Contact("fred", "", ""));
			contacts.Add(new Contact("ted", "", "123456789"));

			//save to file
			SerializeContactList("contacts.txt", contacts);

			//clear them out
			contacts = new List<Contact>();

			//read from file
			DeSerializeContactList("contacts.txt", contacts);
		}

		private static void SerializeContactList(string _filename, List<Contact> _contacts)
		{
			FileInfo fileInfo = new FileInfo(_filename);
			Directory.CreateDirectory(fileInfo.Directory.FullName);
			//TODO Save all Contacts to file
			using (StreamWriter sw = File.CreateText(_filename))
			{
				foreach (Contact contact in _contacts)
				{
					if (!string.IsNullOrWhiteSpace(contact.name))
						sw.WriteLine($"name {contact.name}");

					if (!string.IsNullOrWhiteSpace(contact.email))
						sw.WriteLine($"email {contact.email}");

					if (!string.IsNullOrWhiteSpace(contact.phone))
						sw.WriteLine($"phone {contact.phone}");

					sw.WriteLine("");
				}
			}
		}

		private static void DeSerializeContactList(string _filename, List<Contact> _contacts)
		{
			//TODO load all contacts from file
			using (StreamReader sr = File.OpenText(_filename))
			{
				Contact contact = new Contact();

				string line;
				while ((line = sr.ReadLine()) != null)
				{
					if (string.IsNullOrWhiteSpace(line))
					{
						_contacts.Add(contact);
						contact = new Contact();
					}
					else
					{
						string[] kvp = line.Split(" ");
						if (kvp[0] == "name")
							contact.name = kvp[1];

						if (kvp[0] == "email")
							contact.email = kvp[1];

						if (kvp[0] == "phone")
							contact.phone = kvp[1];
					}
				}
			}
		}
	}
}