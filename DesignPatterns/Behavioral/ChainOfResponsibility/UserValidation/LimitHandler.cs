using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.UserValidation
{
    internal class LimitHandler : Handler // Проверка бизнес-ограничений
    {
        protected override bool Process(Request request)
        {
            if (!request.IsWithinLimit)
            {
                Console.WriteLine("[Limit] Превышен лимит");
                return false;
            }

            Console.WriteLine("[Limit] Всё в пределах лимита");
            return true;
        }
    }
}
