using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Encapsulation
{
    internal class BankAccount
    {
        private static int count = 0;  // заглушка на сейчас, чтобы номер формировался автоматически, в реальности он будет считываться по запросы из базы данных.

        private string accountNumber;
        private decimal balance;

        public decimal Balance { get { return balance; } }

        public BankAccount()
        {
            count += 1;
            accountNumber = count.ToString("D6"); //нумерация с ведущими нулями (например, 000001)
            balance = 0;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"На счет внесено {amount}");
        }

        public void Withdraw(decimal amount)
        {
            if (balance < amount)
            {
                Console.WriteLine($"Недостаточно средств");
                return;
            }
            balance -= amount;
            Console.WriteLine($"С баланса снято {amount}");
        }

        public override string ToString()
        {
            return $"Счёт № {accountNumber}, баланс: {balance}";
        }
    }
}
