using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.EventHandlerObserver
{
    internal class BalanceNotifier
    {
        public void OnBalanceChanged(object? sender, BalanceChangedEventArgs e)
        {
            Console.WriteLine($"[Уведомление] Новый баланс: {e.NewBalance} руб.");
        }
    }
}
