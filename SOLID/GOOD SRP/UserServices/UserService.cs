using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GOOD_SRP.UserServices
{
    internal class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailSender _emailSender;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _emailSender = emailSender;
        }

        public void Register  (string username, string password)
        {
            if (password.Length < 8)
                throw new ArgumentException("Пароль должен быть длиньше");
            string hashed = _passwordHasher.Hash(password);
            _userRepository.Save(new User(username, password));
            _emailSender.Send(username, "Welcome!");
        }

        // Таким образом сервис занимается только процессом регистрации.
        // Так же тут соблюдается принцип D (инверсии зависимостей) - UserService зависит от абстракций (IUserRepository, IEmailSender), а не от реализаций
        // А также О (закрыт/открыт) - можно подменить отправку email на лог в файл без переписывания UserService
    }
}
