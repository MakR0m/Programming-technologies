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
    public class PostService : IPostService
    {
        private AppDbContext _db;

        public PostService(AppDbContext db)
        {
            _db = db;
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
            var userExists = await _db.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new InvalidOperationException("Пользователь с таким ID не существует.");

            var post = new Post { Title = title ?? string.Empty, Content = content ?? string.Empty, UserId = userId };
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, string title, string content)
        {
            var post = await _db.Posts.FindAsync(id);
            if (post == null) return false;
            post.Title = title;
            post.Content = content;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _db.Posts.FindAsync(id);
            if (post == null) return false;
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
