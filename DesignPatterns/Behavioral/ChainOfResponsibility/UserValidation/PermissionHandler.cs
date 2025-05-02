using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.UserValidation
{
    internal class PermissionHandler : Handler  //Проверка  прав доступа
    {
        protected override bool Process(Request request)
        {
            if (!request.HasPermission)
            {
                Console.WriteLine("[Permission] Нет прав доступа");
                return false;
            }

            Console.WriteLine("[Permission] Доступ разрешён");
            return true;
        }
    }
}
