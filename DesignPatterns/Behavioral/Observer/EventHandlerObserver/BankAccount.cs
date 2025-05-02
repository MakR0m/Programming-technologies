using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.EventHandlerObserver
{
    internal class BankAccount   // Класс с событием
    {
        public event EventHandler<BalanceChangedEventArgs> BalanceChanged;
        private decimal _balance;

        public void Deposit(decimal amount)
        {
            _balance += amount;
            Console.WriteLine($"[Счёт] Пополнение на {amount}, новый баланс: {_balance}");
            BalanceChanged?.Invoke(this, new BalanceChangedEventArgs(amount));

        }
    }
}
