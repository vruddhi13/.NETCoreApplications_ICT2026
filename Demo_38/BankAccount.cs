using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_38
{
    internal class BankAccount
    {
        public int AccountNumber;
        public String AccountHolderName;
        public Double Balance;

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if(amount<= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Display()
        {
            Console.WriteLine($"Account no. {AccountNumber}, Name: {AccountHolderName}, Balance: {Balance});
        }
    }
}
