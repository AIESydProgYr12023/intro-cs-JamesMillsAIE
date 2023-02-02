namespace AIE08_DayOfTheWeek
{
    public static class Program
    {
        public enum DayOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public static void Main()
        {
            Console.Write("What day is it (name): ");
            string day = Console.ReadLine()!.ToLower();

            Console.Write("Day number is: ");

            switch(day)
            {
                case "monday":
                    Console.WriteLine(1);
                    break;
                case "tuesday":
                    Console.WriteLine(2);
                    break;
                case "wednesday":
                    Console.WriteLine(3);
                    break;
                case "thursday":
                    Console.WriteLine(4);
                    break;
                case "friday":
                    Console.WriteLine(5);
                    break;
                case "saturday":
                    Console.WriteLine(6);
                    break;
                case "sunday":
                    Console.WriteLine(7);
                    break;
                default:
                    Console.WriteLine("That is not a day of the week dumb dumb");
                    break;
            }

            Console.Write("Enter the day of the week as a number: ");
            string dayNumber = Console.ReadLine()!.ToLower();
            DayOfWeek dayOfWeek = (DayOfWeek)Convert.ToInt32(dayNumber); // "1" -> 1 -> Monday

            switch(dayOfWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Monday");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("Tuesday");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("Wednesday");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Thursday");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Friday");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Saturday");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Not a valid day!");
                    break;
            }
        }
    }
}