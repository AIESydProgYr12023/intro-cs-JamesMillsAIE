namespace AIE40_ValidateEmail
{
    public static class Program
    {
        private static bool ValidateEmail(string _email)
        {
            // 1. Must contain '@' AND '.'
            if (!_email.Contains('@') || !_email.Contains('.'))
                return false;

            // 2. Needs to have a character befor AND after '@'
            if (_email.IndexOf('@') == 0 || _email.IndexOf('@') == _email.Length)
                return false;

            // 3. The character after '@' CANNOT be '.'
            if (_email.IndexOf('@') + 1 == _email.IndexOf('.'))
                return false;

            // 4. Must have '.' AFTER the '@'
            return _email.IndexOf('@') <= _email.IndexOf('.');
        }

        public static void Main()
        {
            Console.WriteLine(ValidateEmail("@gmail.com")); // False
            Console.WriteLine(ValidateEmail("hello.gmail@com")); // False
            Console.WriteLine(ValidateEmail("gmail")); // False
            Console.WriteLine(ValidateEmail("hello@gmail")); // False
            Console.WriteLine(ValidateEmail("hello@gmail.com")); // True
            Console.WriteLine(ValidateEmail("hello@.gmail.com")); // False
        }
    }
}