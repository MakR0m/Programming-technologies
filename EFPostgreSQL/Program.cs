using EFPostgreSQL.Data;
using EFPostgreSQL.Migrations;
using EFPostgreSQL.Models;
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


        static async Task Main(string[] args)
        {
            await RunMenu();
        }

        static async Task RunMenu()
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
                Console.WriteLine("7. Обновить пост");
                Console.WriteLine("8. Удалить пост");
                Console.WriteLine("9. Очистить базу данных");
                Console.WriteLine("10. Выход");
                Console.Write("Ваш выбор: ");

                var input = Console.ReadLine();

                using var db = new AppDbContext();

                switch (input)
                {
                    case "1": await AddUserAsync(db); break;
                    case "2": await ShowUsersAsync(db); break;
                    case "3": await UpdateUserByIdAsync(db); break;
                    case "4": await DeleteUserByIdAsync(db); break;
                    case "5": await AddPostAsync(db); break;
                    case "6": await ShowPostsAsync(db); break;
                    case "7": await UpdatePostByIdAsync(db); break;
                    case "8": await DeletePostByIdAsync(db); break;
                    case "9": await ClearDatabaseAsync(db); break;
                    case "10": return;
                    default: Console.WriteLine("Неверный ввод. Повторите попытку."); break;
                }
            }
        }

        static async Task AddUserAsync(AppDbContext db)
        {
            Console.Write("Имя пользователя: ");
            var name = Console.ReadLine();
            Console.Write("Возраст: ");
            int.TryParse(name, out int age);
            var user = new User { Name = name ?? string.Empty, Age = age };
            db.Users.Add(user);
            await db.SaveChangesAsync();
            Console.WriteLine("Добавлен");

        }

        static async Task ShowUsersAsync(AppDbContext db)
        {
            var users = await db.Users.ToListAsync();
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name}, {user.Age} лет");
        }

        static async Task UpdateUserByIdAsync(AppDbContext db)
        {
            Console.Write("ID пользователя для обновления: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            var user = await db.Users.FindAsync(id);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            Console.WriteLine("New name:");
            user.Name = Console.ReadLine() ?? user.Name;
            Console.WriteLine("New age:");
            int.TryParse(Console.ReadLine(), out int newAge);
            user.Age = newAge;
            await db.SaveChangesAsync();
            Console.WriteLine("User updated");
        }

        static async Task DeleteUserByIdAsync(AppDbContext db)
        {
            Console.Write("ID пользователя для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            var user = await db.Users.FindAsync(id);
            if ( user == null)
            {
                Console.WriteLine("Пользователь не найден.");
                return;
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            Console.WriteLine("User was delete");
        }

        static async Task AddPostAsync(AppDbContext db)
        {
            Console.Write("ID пользователя, которому добавить пост: ");
            int.TryParse(Console.ReadLine(), out int userId);
            var user = await db.Users.FindAsync(userId);
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден.");
                return;
            }

            Console.Write("Заголовок поста: ");
            var title = Console.ReadLine();
            Console.Write("Содержание поста: ");
            var content = Console.ReadLine();

            var post = new Post { Title = title ?? string.Empty, Content = content ?? string.Empty, UserId = userId };
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            Console.WriteLine("Пост добавлен.");

        }

        static async Task ShowPostsAsync(AppDbContext db)
        {
            var users = await db.Users.Include(u => u.Posts).ToListAsync();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} ({user.Id}):");
                foreach (var post in user.Posts)
                {
                    Console.WriteLine($" - {post.Id}: {post.Title}: {post.Content}");
                }
            }
        }

        static async Task UpdatePostByIdAsync(AppDbContext db)
        {
            Console.Write("ID поста для обновления: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var post = await db.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
            {
                Console.WriteLine("Пост не найден.");
                return;
            }

            Console.Write("Новый заголовок: ");
            post.Title = Console.ReadLine() ?? post.Title;
            Console.Write("Новое содержание: ");
            post.Content = Console.ReadLine() ?? post.Content;
            await db.SaveChangesAsync();
            Console.WriteLine("Пост обновлён.");

        }

        static async Task DeletePostByIdAsync(AppDbContext db)
        {
            Console.Write("ID поста для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var post = await db.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
            {
                Console.WriteLine("Пост не найден.");
                return;
            }

            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            Console.WriteLine("Пост удалён.");

        }

        static async Task ClearDatabaseAsync(AppDbContext db)
        {
            Console.Write("Вы уверены, что хотите удалить всех пользователей и посты? (y/n): ");
            var confirm = Console.ReadLine();
            if (confirm?.ToLower() != "y")
            {
                Console.WriteLine("Операция отменена.");
                return;
            }

            db.Posts.RemoveRange(db.Posts);
            db.Users.RemoveRange(db.Users);
            await db.SaveChangesAsync();
            Console.WriteLine("База данных очищена.");

        }
    }
}
