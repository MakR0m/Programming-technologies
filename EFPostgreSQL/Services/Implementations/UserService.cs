using EFPostgreSQL.Data;
using EFPostgreSQL.Models;
using EFPostgreSQL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPostgreSQL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<UserService> _logger;

        public UserService(AppDbContext db, ILogger<UserService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await (_db.Users.FindAsync(id));
        }

        public async Task AddAsync(string name, int age)
        {
            try
            {
                var user = new User { Name = name ?? string.Empty, Age = age };
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Добавлен пользователь: {Name}, возраст {Age}", name, age);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении пользователя: {Name}", name);
            }
        }

        public async Task UpdateAsync(int id, string name, int age)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null) return;
                user.Name = name;
                user.Age = age;
                await _db.SaveChangesAsync();
                _logger.LogInformation("Обновлён пользователь с ID {Id}: {Name}, возраст {Age}", id, name, age);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении пользователя с ID {Id}", id);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null) return;
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Удалён пользователь с ID {Id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении пользователя с ID {Id}", id);
            }
        }
    }
}
