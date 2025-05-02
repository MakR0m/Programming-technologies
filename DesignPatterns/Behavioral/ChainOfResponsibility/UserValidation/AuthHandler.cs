using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.UserValidation
{
    internal class AuthHandler : Handler    // Проверка авторизации
    {
        protected override bool Process(Request request)
        {
            if (!request.IsAuthenticated)
            {
                Console.WriteLine("[Auth] Пользователь не авторизован");
                return false;
            }
            Console.WriteLine("[Auth] Авторизация пройдена");
            return true;
        }
    }
}
