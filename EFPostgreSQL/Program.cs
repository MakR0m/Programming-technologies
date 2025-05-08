using EFPostgreSQL.Data;
using EFPostgreSQL.Migrations;
using EFPostgreSQL.Models;
using EFPostgreSQL.Services.Implementations;
using EFPostgreSQL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFPostgreSQL
{
    internal class Program
    {
        //В данном проекте PostgreSQL запускается в докер-контейнере.
        //PostgreSQL в Docker — это полноценная СУБД (система управления базами данных), запущенная в контейнере.

        #region PostgreSQL
        //PostgreSQL — это реляционная система управления базами данных (СУБД) с открытым исходным кодом.
        //Она используется для хранения структурированных данных, поддерживает транзакции, связи, индексы, расширенные типы данных (jsonb, enum, массивы и др.).
        //В данном проекте PostgreSQL работает в Docker-контейнере, порт 5432 проброшен наружу, база называется ef_demo.
        //pgAdmin — это официальная GUI-программа для администрирования PostgreSQL.
        //С её помощью можно:
        //- Подключаться к базе данных
        //- Просматривать таблицы, поля, индексы и связи
        //- Выполнять SQL-запросы
        //- Создавать и изменять объекты базы (таблицы, роли, функции и т.д.)

        //Данные подключения к PostgreSQL:
        //Host: localhost
        //Port: 5432
        //User: postgres
        //Password: postgres
        //Database: ef_demo

        //После подключения в pgAdmin структура базы доступна по пути:
        //Servers → Databases → ef_demo → Schemas → public → Tables
        #endregion


        #region Docker
        //Docker - инструмент, позволяющий запускать приложения в изолированной среде (контейнере). "Лёгкая виртуальная машина"
        //Запускаем Docker Desktop, чтобы демон работал в фоне.
        //Клонируем репозиторий проекта (например, из GitHub) с помощью команды: git clone https://github.com/docker/welcome-to-docker
        //Переходим в папку проекта в терминале.
        //Убедившись, что в проекте есть Dockerfile (или создаём свой), выполняем команду сборки: "docker build -t welcome-to-docker ." Это создаёт образ с именем welcome-to-docker
        //Открываем Docker Desktop, переходим на вкладку Images и находим образ welcome-to-docker.
        //Запускаем контейнер из образа, указав проброс порта (например, 3000:3000).(в программе) docker run -p 3000:3000 welcome-to-docker (в терминале)
        //Открываем браузер и переходим по адресу: http://localhost:3000
        #endregion
        #region Docker PostgreSQL

        #endregion
        #region EntityFramework (EF Core)
        //EF Core - это ORM (это ORM (Object-Relational Mapper) для .NET, разработанный Microsoft.
        //Он позволяет разработчику работать с базой данных через C#-объекты, а не вручную писать SQL-запросы.
        //[ Приложение C# ] ⇄ EF Core ⇄ PostgreSQL (СУБД)

        //| Компонент         | Назначение                                                             |
        //| ----------------- | -----------------------------------------------------------------------|
        //| DbContext         | Главный класс, представляющий сессию работы с БД(контекст)             |
        //| DbSet<T>          | Коллекция сущностей определённого типа(аналог таблицы в БД)            |
        //| Entity(сущность)  | Класс C#, описывающий структуру таблицы                                |
        //| Migration         | Механизм для пошагового изменения схемы БД(создание/обновление таблиц) |

        //CodeFirst - сначала модель c#, которая создает таблицы в бд посредством EF
        //DBFirst - сначала бд, а на ее основе EF генерирует классы из таблиц
        //Плюсы:
        //Работа с БД как с объектами
        //Инкапсуляция SQL
        //Поддержка асинхронности(async/await)
        //Поддержка миграций (это набор инструкций, которые говорят EF Core, как изменить структуру базы данных, чтобы она соответствовала текущим C#-моделям)
        //Кросс-платформенность и гибкость
        //Ограничения:
        //Не всё можно выразить через LINQ
        //Потенциально сложные запросы могут быть менее оптимальными, чем вручную написанный SQL
        //ORM добавляет слой абстракции и нужно понимать, что именно выполняется в SQL

        //Про миграции. Пример: добавление нового поля в класс на основе которого уже создана таблица.
        //EF сравнит текущие классы с предыдущим состоянием, создаст файл миграции с SQL-командами(например, ALTER TABLE) и будет готов применить их к базе

        //Подытог:
        //Модель — это C#-класс, описывающий структуру данных.
        //EF превращает этот класс в таблицу и LINQ-запросы в SQL.
        //Миграции фиксируют изменения моделей и применяют их к БД.
        //По умолчанию: одна модель = одна таблица, но есть гибкость при необходимости.
        #endregion

        #region DTO
        //DTO - это объект, предназначенный для передачи данных между слоями приложения (например, между контроллером и клиентом),
        //не совпадающий напрямую с моделью EF
        //Зачем?
        //Изоляция EF-моделей от внешнего мира (безопасность, устойчивость к изменениям).
        //Можно отдавать только нужные данные — не всё, что есть в модели.
        //Позволяет агрегировать или переименовывать поля, преобразовывать вложенные сущности.
        //Упрощает тестирование и читаемость кода.
        //| Сценарий                                            | Используем DTO?                 |
        //| ----------------------------------------------------| ------------------------------- |
        //| Работа внутри EF и БД                               | Необязательно                   |
        //| Передача данных из API                              | Да                              |
        //| Валидация входных данных(например, `UserCreateDto`) | Да                              |
        //| Хранение в БД                                       | Нет(используются только модели) |
        #endregion

        #region Миграция
        //Создание и применение миграции через консоль, находясь в папке проекта .csproj
        //Установка глобального инструмента: dotnet tool install --global dotnet-ef (Один раз)  (глобальный CLI-инструмент (dotnet-ef), позволяет вызывать миграции и обновлять базу через CLI)
        //dotnet ef migrations add Init  - создание миграции (появится папка Migrations)
        //dotnet ef database update      - применение миграции к БД
        //EF запрашивает таблицу _EFMigrationHistory, не находит ее (первый раз) создает, применяет миграцию и завершает процесс
        //После добавления класса Post, который связан с User используем миграцию для изменения таблицы User и добавления таблицы Post. (ключи настроены в AppDbContext)
        //dotnet ef migrations add AddPostEntity
        //dotnet ef database update

        //Изменение имени поля без потери данных. Меняем имя поле в классе. Добавляем новую миграцию: dotnet ef migrations add RenameTittleToTitle.
        //Открываем файл миграции в папке миграций, ищем методы Up() и Down() и меняем DropColumn|AddColumn на RenameColumn,
        //если изначально Rename то оставляем и применяем миграцию dotnet ef database update

        #endregion

        #region Связаные таблицы
        //Создать навигационные свойства в классах 
        //Это свойства, ссылающиеся на другие связанные сущности:
        //- Post.User — доступ к пользователю из поста
        //- User.Posts — доступ к списку постов из пользователя
        //В AppDbContext прописать связность 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.Posts)
        //        .WithOne(p => p.User)
        //        .HasForeignKey(p => p.UserId);
        //}
        #endregion

        #region Навигационные свойства и .Include
        //Допустим у нас Post имеет внешний ключ пользователя и навигационное свойство (сам объект User в свойстве). По умолчанию он null
        //EF Core по умолчанию НЕ загружает связанные объекты (навигационные свойства), чтобы повысить эффективность
        //Несмотря на то, что свойство User есть в классе, EF не загружает его содержимое пока явно не указать:
        //.Include(p => p.User)  -  когда будешь грузить Post, сразу подтяни User, связанный по его UserId
        //SELECT
        //p.Id, p.Title, p.Content, p.UserId,
        //u.Id, u.Name, u.Age
        //FROM Posts AS p
        //LEFT JOIN Users AS u ON p.UserId = u.Id
        //Если просто написать .Where(p => p.User.Id == 5) будет ошибка т.к. User null

        //.Include() работает с навигационными свойствами
        //EF автоматически связывает объекты по внешним ключам
        //результат — это граф объектов, а не анонимный тип

        #endregion

        #region Рефакторинг
        //Чтобы не вызывать логику работы с бд в program создал User и Post сервисы и интерфейсы для них.
        //Архитектура по DDD (Domain-Driven Design) или Clean Architecture предполагает, что у каждой предметной сущности есть свой сервис.
        #endregion

        #region Примечания
        //Если мы вытащили объект с помощью FindAsync(id), то для его изменения достаточно поменять значения свойств, без Update(T), т.к. EF отслеживает этот объект (Change Tracking)
        //Если объект не был получен из базы, то нужен Update(T). Можно создать post с айди который уже есть в базе, но с другими свойствами и вызвать апдейт, тогда в базе обновится пост с этим айди.

        #endregion



        static async Task Main(string[] args)
        {
            var db = new AppDbContext();
            IUserService userService = new UserService(db);
            IPostService postService = new PostService(db);
            await RunMenu(userService, postService);
        }

        static async Task RunMenu(IUserService userService, IPostService postService)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить пользователя");
                Console.WriteLine("2. Показать всех пользователей");
                Console.WriteLine("3. Обновить пользователя");
                Console.WriteLine("4. Удалить пользователя");
                Console.WriteLine("5. Добавить пост пользователю");
                Console.WriteLine("6. Показать посты всех пользователей");
                Console.WriteLine("7. Показать все посты пользователя");
                Console.WriteLine("8. Обновить пост");
                Console.WriteLine("9. Удалить пост");
                Console.WriteLine("10. Очистить базу данных");
                Console.WriteLine("11. Выход");
                Console.Write("Ваш выбор: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": await AddUserAsync(userService); break;
                    case "2": await ShowUsersAsync(userService); break;
                    case "3": await UpdateUserByIdAsync(userService); break;
                    case "4": await DeleteUserByIdAsync(userService); break;
                    case "5": await AddPostAsync(userService, postService); break;
                    case "6": await ShowPostsAsync(postService); break;
                    case "7": await ShowPostsByUser(userService, postService); break;
                    case "8": await UpdatePostByIdAsync(postService); break;
                    case "9": await DeletePostByIdAsync(postService); break;
                    case "10": await ClearDatabaseAsync(userService, postService); break;
                    case "11": return;
                    default: Console.WriteLine("Неверный ввод. Повторите попытку."); break;
                }
            }
        }

        static async Task AddUserAsync(IUserService userService)
        {
            Console.Write("Имя пользователя: ");
            var name = Console.ReadLine();
            Console.Write("Возраст: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Не удалось распарсить возраст");
                return;
            }
            await userService.AddAsync(name ?? string.Empty, age);
            Console.WriteLine("Добавлен");

        }

        static async Task ShowUsersAsync(IUserService userService)
        {
            var users = await userService.GetAllAsync();
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name}, {user.Age} лет");
        }

        static async Task UpdateUserByIdAsync(IUserService userService)
        {
            var user = await ReadAndCheckIdAsync("ID пользователя: ", userService.GetByIdAsync, "Пользователь не найден.");
            if (user == null) return;
            Console.Write("Новое имя: ");
            var newName = Console.ReadLine();
            Console.Write("Новый возраст: ");
            int.TryParse(Console.ReadLine(), out int newAge);
            var success = await userService.UpdateAsync(user.Id, newName ?? string.Empty, newAge);
            Console.WriteLine(success ? "Пользователь обновлён." : "Пользователь не найден.");
        }

        static async Task DeleteUserByIdAsync(IUserService userService)
        {
            var user = await ReadAndCheckIdAsync("ID пользователя: ", userService.GetByIdAsync, "Пользователь не найден.");
            if (user == null) return;
            var success = await userService.DeleteAsync(user.Id);
        }

        static async Task AddPostAsync(IUserService userService, IPostService postService)
        {
            var user = await ReadAndCheckIdAsync("ID пользователя, которому добавить пост: ", userService.GetByIdAsync, "Пользователь не найден.");
            if (user == null) return;
            
            Console.Write("Заголовок поста: ");
            var title = Console.ReadLine();
            Console.Write("Содержание поста: ");
            var content = Console.ReadLine();
            await postService.AddAsync(title ?? string.Empty, content ?? string.Empty,user.Id);
            Console.WriteLine("Пост добавлен.");

        }

        static async Task ShowPostsAsync(IPostService postService)
        {
            var posts = await postService.GetAllAsync();
            foreach (var p in posts)
                Console.WriteLine($"{p.Id}: {p.Title} ({p.User.Name})");
        }

        static async Task ShowPostsByUser(IUserService userService, IPostService postService)
        {
            var user = await ReadAndCheckIdAsync("ID пользователя: ", userService.GetByIdAsync, "Пользователь не найден.");
            if (user == null) return;

            var posts = await postService.GetByUserIdAsync(user.Id);
            if (posts.Count == 0)
            {
                Console.WriteLine("У этого пользователя нет постов.");
                return;
            }

            foreach (var p in posts)
                Console.WriteLine($"{p.Id}: {p.Title}");
        }

        static async Task UpdatePostByIdAsync(IPostService postService)
        {
            var post = await ReadAndCheckIdAsync("ID поста: ", postService.GetByIdAsync, "Пост не найден.");
            if (post == null) return;
            
            Console.Write("Новый заголовок: ");
            var newTitle = Console.ReadLine();
            Console.Write("Новое содержание: ");
            var newContent = Console.ReadLine();
            var success = await postService.UpdateAsync(post.Id, newTitle ?? string.Empty, newContent ?? string.Empty);
            Console.WriteLine(success ? "Пост обновлён." : "Пост не найден.");

        }

        static async Task DeletePostByIdAsync(IPostService postService)
        {
            var post = await ReadAndCheckIdAsync("ID поста: ", postService.GetByIdAsync, "Пост не найден.");
            if (post == null) return;
            await postService.DeleteAsync(post.Id);
        }

        static async Task ClearDatabaseAsync(IUserService userService, IPostService postService)
        {
            Console.Write("Вы уверены, что хотите удалить всех пользователей и посты? (y/n): ");
            var confirm = Console.ReadLine();
            if (confirm?.ToLower() != "y")
            {
                Console.WriteLine("Операция отменена.");
                return;
            }
            var allPosts = await postService.GetAllAsync();
            foreach (var p in allPosts)
                await postService.DeleteAsync(p.Id);

            var allUsers = await userService.GetAllAsync();
            foreach (var u in allUsers)
                await userService.DeleteAsync(u.Id);
            Console.WriteLine("База данных очищена.");
        }


        private static async Task<T?> ReadAndCheckIdAsync<T>(string prompt, Func<int, Task<T?>> fetchById, string notFoundMessage) // передаем ссылку на метод поиска по айди и сообщения в случае удачи и неудачи
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out int id))   //Вводим айди с консоли
            {
                Console.WriteLine("Неверный ввод ID.");
                return default;
            }

            var entity = await fetchById(id);     //Передаем айди в метод
            if (entity == null)
            {
                Console.WriteLine(notFoundMessage);
                return default;
            }

            return entity;
        }
    }
}
