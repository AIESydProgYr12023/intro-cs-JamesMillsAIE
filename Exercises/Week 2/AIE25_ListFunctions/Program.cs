namespace AIE25_ListFunctions
{
    public static class Program
    {
        public static void PrintList(List<int> _list)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($"List has: {_list.Count} values...");

            foreach (int item in _list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------");
        }

        public static void Main()
        {
            List<int> valueList = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                valueList.Add(i);
            }

            PrintList(valueList);

            Console.WriteLine($"Is 0 in the list? {valueList.Contains(0)}");
            Console.WriteLine($"Is 11 in the list? {valueList.Contains(11)}");

            for (int i = 0; i < 5; i++)
            {
                valueList.RemoveAt(i);
            }

            PrintList(valueList);

            valueList.Clear();

            PrintList(valueList);

            valueList.AddRange(new int[] { 11, 12, 13 });

            PrintList(valueList);
        }
    }
}