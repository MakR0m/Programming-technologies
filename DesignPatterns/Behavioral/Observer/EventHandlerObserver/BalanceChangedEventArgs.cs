using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.EventHandlerObserver
{
    internal class BalanceChangedEventArgs : EventArgs  // Класс, содержащий нужные данные при уведомлении
    {
        public decimal NewBalance { get; }

        public BalanceChangedEventArgs(decimal newBalance)
        {
            NewBalance = newBalance;
        }
    }
}
