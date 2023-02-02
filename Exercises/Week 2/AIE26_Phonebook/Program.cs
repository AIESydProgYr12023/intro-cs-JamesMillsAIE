namespace AIE26_Phonebook
{
    public static class Program
    {
        public static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            phonebook.Add("Emergency Services", "0118 999 881 999 119 725 ... [long pause] 3.");
            phonebook.Add("Ghostbusters", "18005552368");
            phonebook.Add("AIE", "85148800");

            foreach (var phone in phonebook)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine();

            foreach (var phone in phonebook)
            {
                Console.WriteLine($"{phone.Key} : {phone.Value}");
            }

            Console.WriteLine(phonebook["Emergency Services"]);
        }
    }
}