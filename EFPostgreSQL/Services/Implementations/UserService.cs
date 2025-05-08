using EFPostgreSQL.Data;
using EFPostgreSQL.Models;
using EFPostgreSQL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task AddAsync(string name, int age)
        {
            try
            {
                var user = new User { Name = name ?? string.Empty, Age = age };
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении пользователя: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                if (user == null) return false;
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении пользователя: {ex.Message}");
                return false;
            }
        }


        public async Task<User?> GetByIdAsync(int id)
        {
            return await (_db.Users.FindAsync(id));
        }

        public async Task<bool> UpdateAsync(int id, string name, int age)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return false;
            user.Name = name;
            user.Age = age;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
