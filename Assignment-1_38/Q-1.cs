using Assignment_1_38.Q_2;
using Assignment_1_38.Q_3;

namespace Assignment_1_38
{
    class Person
    {
        protected string name;

        public virtual void GetData()
        {
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
        }

        public virtual void ShowData()
        {
            Console.WriteLine("Name: " + name);
        }
    }

    class Student : Person
    {
        protected int rollNo;

        public override void GetData()
        {
            base.GetData();
            Console.Write("Enter Roll No: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine("Roll No: " + rollNo);
        }
    }

    class CollegeStudent : Student
    {
        string course;

        public override void GetData()
        {
            base.GetData();
            Console.Write("Enter Course: ");
            course = Console.ReadLine();
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine("Course: " + course);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Question to Run:");
            Console.WriteLine("1. Question 1 (Inheritance)");
            Console.WriteLine("2. Question 2 (Interface Polymorphism)");
            Console.WriteLine("3. Question 3 (Generic Interface)");
            Console.Write("Enter choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            switch (choice)
            {
                case 1:
                    Main1();
                    break;
                case 2:
                    Main2();
                    break;
                case 3:
                    Main3();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        // ================= QUESTION 1 =================
        static void Main1()
        {
            List<Person> list = new List<Person>();
            int choice;

            do
            {
                Console.WriteLine("\n1. Add College Student");
                Console.WriteLine("2. Display All Records");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Person p = new CollegeStudent();   // Dynamic Polymorphism
                    p.GetData();
                    list.Add(p);
                }
                else if (choice == 2)
                {
                    foreach (Person p in list)
                    {
                        p.ShowData();
                        Console.WriteLine("----------------");
                    }
                }

            } while (choice != 3);
        }

        // ================= QUESTION 2 =================
        static void Main2()
        {
            IFileOpearation operation;

            Console.WriteLine("1. Read File");
            Console.WriteLine("2. Write File");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (choice == 1)
                operation = new ReadFile();
            else if (choice == 2)
                operation = new WriteFile();
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            operation.Execute();
        }

        // ================= QUESTION 3 =================
        static void Main3()
        {
            IRepository<string> repository;

            repository = new FileRepository<string>();
            repository.Save("document.txt");

            repository = new FileRepository<string>();
            repository.Save("image.png");
        }
    }
}
