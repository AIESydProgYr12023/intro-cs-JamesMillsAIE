namespace AIE11_PasswordPrompt
{
    public static class Program
    {
        public static void Main()
        {
            bool isSamePassword = false;

            do
            {
                Console.Write("Enter a password: ");
                string pwd1 = Console.ReadLine();
                Console.Write("Confirm password: ");
                string pwd2 = Console.ReadLine();

                if(pwd1 != pwd2)
                {
                    Console.WriteLine("Please try again.");
                }
                else
                {
                    isSamePassword = true;
                    Console.WriteLine("Passwords match.");
                }
            }
            while(isSamePassword == false);
        }
    }
}