using EFPostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPostgreSQL.Data
{
    // Наследуемся от DbContext — базовый класс Entity Framework Core для работы с базой данных
    public class AppDbContext : DbContext
    {
        // DbSet<User> представляет таблицу "Users" в базе данных.
        // Каждый DbSet соответствует таблице, а тип T — это сущность (модель), строки которой мы храним.
        // Через него мы выполняем запросы, добавление, обновление и удаление данных.
        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Posts => Set<Post>();

        // Метод конфигурации контекста. Здесь указываем параметры подключения к базе.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Используем PostgreSQL в качестве провайдера базы данных.
            // Здесь задаём строку подключения к контейнеру PostgreSQL.
            options.UseNpgsql("Host=localhost;Port=5432;Database=ef_demo;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)                // Один User имеет много Post'ов
                .WithOne(p => p.User!)                // Каждый Post связан с одним User'ом
                .HasForeignKey(p => p.UserId);        // Внешний ключ — свойство UserId в Post
        }
    }
}
