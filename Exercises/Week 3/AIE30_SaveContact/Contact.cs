using System.IO;

namespace AIE30_SaveContact
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
				sw.WriteLine(name);
				sw.WriteLine(email);
				sw.WriteLine(phone);
			}
		}

		public void DeSerialize(string _filename)
		{
			//TODO use the streamReader to Read the name, email and phone from a file
			using (StreamReader sr = File.OpenText(_filename))
			{
				name = sr.ReadLine();
				email = sr.ReadLine();
				phone = sr.ReadLine();
			}
		}

		public void Print()
		{
			Console.WriteLine($"{name} {email} {phone}");
		}
	}
}
