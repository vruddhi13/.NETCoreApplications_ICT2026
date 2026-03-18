namespace Demo_38
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] accounts = new BankAccount[5];

            int count = 0;
            int choice;

            do
            {
                Console.WriteLine("\n1. Enter 5 Accounts");
                Console.WriteLine("\n2. Deposit");
                Console.WriteLine("\n3. Withdraw");
                Console.WriteLine("\n4. Highest Balance Account");
                Console.WriteLine("\n5. Display All");
                Console.WriteLine("\n6. Exit");
                Console.Write("Enter Choice: ");


                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        for(int i=0; i<5; i++)
                        {
                            accounts[i] = new BankAccount();
                            Console.WriteLine("Account number: ");
                            accounts[i].AccountNumber = int.Parse(Console.ReadLine());
                            Console.WriteLine("Name: ");
                            accounts[i].AccountHolderName = Console.ReadLine();
                            Console.WriteLine("Balance: ");
                            accounts[i].Balance = int.Parse(Console.ReadLine());
                            count++;
                        }
                        break;

                    case 2:
                        Console.Write("Enter Account number: ");
                        int accNo = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount: ");
                }

            }
               
                
        }
    }
}
