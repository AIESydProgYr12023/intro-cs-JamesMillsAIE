namespace AIE01_FortuneTeller
{
    public static class Program
    {
        private static void Main()
        {
            // Variables
            int numOfChildren = 2;
            string partnersName = "Georgia";
            string location = "Sydney";
            string jobTitle = "\"Programming Teacher\"";

            // Output string with variables listed above
            Console.WriteLine("You will be a " + jobTitle + " in " + location + ", and married to " + partnersName + " with " + numOfChildren + " kids.");
        }
    }
}