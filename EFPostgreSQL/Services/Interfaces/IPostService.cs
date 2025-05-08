using EFPostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPostgreSQL.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<List<Post>> GetByUserIdAsync(int userId);
        Task<Post?> GetByIdAsync(int id);
        Task AddAsync(string title, string content, int userId);
        Task UpdateAsync(int id, string title, string content);
        Task DeleteAsync(int id);
    }
}
