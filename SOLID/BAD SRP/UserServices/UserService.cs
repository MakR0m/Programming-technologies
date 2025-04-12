using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BAD_SRP.UserServices
{
    internal class UserService
    {
        // Данный сервис должен заниматься только процессом регистрации. Хеширование, сохранени и отправка писем должны быть делегированы в другие классы


        public void Register(string username, string password)
        {
            // Проверка пароля
            if (password.Length < 8)
                throw new ArgumentException("Слишком короткий пароль");

            // Хеширование пароля
            string hashed = HashPassword(password);

            // Сохранение в базу
            Console.WriteLine($"Сохраняем пользователя {username} с паролем {hashed}");

            // Отправка приветственного письма
            Console.WriteLine($"Отправлено письмо для {username}");
        }

        private string HashPassword(string password)
        {
            // Очень наивный хеш
            return password.GetHashCode().ToString();
        }
    }
}
