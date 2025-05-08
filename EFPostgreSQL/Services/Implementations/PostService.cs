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
    public class PostService : IPostService
    {
        private readonly AppDbContext _db;
        private readonly ILogger<PostService> _logger;

        public PostService(AppDbContext db, ILogger<PostService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _db.Posts.ToListAsync();        
        }

        public Task<Post?> GetByIdAsync(int id)
        {
            return _db.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Post>> GetByUserIdAsync(int userId)
        {
            return await _db.Posts
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(string title, string content, int userId)
        {
            try
            {
                var userExists = await _db.Users.AnyAsync(u => u.Id == userId);
                if (!userExists)
                    throw new InvalidOperationException("Пользователь с таким ID не существует.");

                var post = new Post { Title = title ?? string.Empty, Content = content ?? string.Empty, UserId = userId };
                _db.Posts.Add(post);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Добавлен пост: {Title} для пользователя ID {UserId}", title, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении поста: {Title}", title);
            }
        }

        public async Task UpdateAsync(int id, string title, string content)
        {
            try
            {
                var post = await _db.Posts.FindAsync(id);
                if (post == null) return;
                post.Title = title;
                post.Content = content;
                await _db.SaveChangesAsync();
                _logger.LogInformation("Обновлён пост ID {Id}: {Title}", id, title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении поста с ID {Id}", id);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var post = await _db.Posts.FindAsync(id);
                if (post == null) return;
                _db.Posts.Remove(post);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Удалён пост с ID {Id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при удалении поста с ID {Id}", id);
            }
        }

    }
}
