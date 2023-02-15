using System.IO;

namespace AIE31_SaveContact
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

		public void Serialize(string _filename)
		{
			//Extra from Video:
			FileInfo fileInfo = new FileInfo(_filename);
			Directory.CreateDirectory(fileInfo.Directory.FullName);
			//TODO use the streamWriter to write the name, email and phone to a file
			using (StreamWriter sw = File.CreateText(_filename))
			{
				if (!string.IsNullOrWhiteSpace(name)) 
					sw.WriteLine($"name {name}");

				if (!string.IsNullOrWhiteSpace(email)) 
					sw.WriteLine($"email {email}");

				if (!string.IsNullOrWhiteSpace(phone)) 
					sw.WriteLine($"phone {phone}");
			}
		}

		public void DeSerialize(string _filename)
		{
			using (StreamReader sr = File.OpenText(_filename))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					string[] kvp = line.Split(" ");
					if (kvp[0] == "name") name = kvp[1];
					if (kvp[0] == "email") email = kvp[1];
					if (kvp[0] == "phone") phone = kvp[1];
				}
			}
		}

		public void Print()
		{
			Console.WriteLine($"{name} {email} {phone}");
		}
	}
}
