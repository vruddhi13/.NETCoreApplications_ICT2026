namespace GenericCollection
{


    internal class Program
    {
        static void Main()
        {
            var employees = new GenericCollection<Employees>();

            employees.Add(new Employees { Name = "Alice", Department = "IT" });
            employees.Add(new Employees { Name = "Bob", Department = "HR" });
            employees.Add(new Employees { Name = "Charlie", Department = "IT" });

            // String indexer
            Console.WriteLine("Search by name 'Bob':");
            var emp = employees["Bob"];
            Console.WriteLine(emp);

            // Multivalued indexer
            Console.WriteLine("\nSearch all in IT department:");
            var itEmployees = employees[e => e.Department == "IT"];
            foreach (var e in itEmployees)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
